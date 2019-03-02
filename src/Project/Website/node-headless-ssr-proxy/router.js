const express = require('express');
const qs = require('querystring');
const request = require('request');
const url = require('url');
const axios = require('axios');
const config = require('./config');

const pattern = /^((http|https):\/\/)/;

let router = express.Router();

init();

function init() {
    getRedirects().catch(err => {
        console.error('Error getting redirects', err.stack);
    });
}

function getRedirects() {
    const url = `${config.apiHost}${config.apiRedirects}`;
    return axios.get(url).then(res => {
        console.log('-------------------------')
        console.log('Redirect Manager')
        console.log('-------------------------')
        console.log(new Date())
        console.log('-------------------------')
        console.log(res.data);
        loadRoutes(res.data);
        console.log('-------------------------')
    });
}

function getRouter() {
    return router;
}

function loadRoutes(routes) {
    router = express.Router();
    router.get('/cache', cleanCache);
    routes.forEach(r => loadRoute(r));
}

function cleanCache(req, res) {
    console.log('host', req.get('host'), req.hostname);
    router = express.Router();
    getRedirects()
        .then(res.json({ success: true }))
        .catch(err => {
            console.error('Error getting redirects', err.stack);
            res.status(500).json({ success: false });
        });
}

function loadRoute(route) {
    switch (route.Type) {
        case '301':
            router
                .route(new RegExp(route.OldUrl))
                .all((req, res) => doPermanentRedirect(route, req, res));
            break;

        case '302':
            router
                .route(new RegExp(route.OldUrl))
                .all((req, res) => doTemporalRedirect(route, req, res));
            break;

        default:
            router
                .route(new RegExp(route.OldUrl))
                .all((req, res) => doServerTransfer(route, req, res));
    }
}

function doPermanentRedirect(route, req, res) {
    doRedirect(301, route, req, res);
}

function doTemporalRedirect(route, req, res) {
    doRedirect(302, route, req, res);
}

function doRedirect(status, route, req, res) {
    let url = route.NewUrl;
    if (route.KeepParams) {
        const params = qs.stringify(req.query);
        if (params) {
            url = `${url}?${params}`;
        }
    }
    res.status(status).redirect(url);
}

function doServerTransfer(route, req, res) {
    const method = req.method.toLowerCase();
    let requestUrl;
    if (pattern.test(route.NewUrl)) {
        requestUrl = route.NewUrl;
    } else {
        requestUrl = url.format({
            protocol: req.protocol,
            host: req.get('host'),
            pathname: route.NewUrl
        });
    }
    req.pipe(request[method](requestUrl)).pipe(res);
}

module.exports = getRouter;
