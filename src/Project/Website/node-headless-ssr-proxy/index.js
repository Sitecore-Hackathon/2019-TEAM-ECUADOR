// load .env file
require('dotenv').config()

const express = require('express');
const compression = require('compression');
const scProxy = require('@sitecore-jss/sitecore-jss-proxy').default;
const config = require('./config');
const router = require('./router');

const port = process.env.NODE_SSR_PROXY_PORT || 3000;
const host = process.env.NODE_SSR_PROXY_HOST || 'localhost';

const server = express();

// enable gzip compression for appropriate file types
server.use(compression());

// enable redirect manager rules
server.use('/', function(req, res, next) {
  router()(req, res, next);
});

// turn off x-powered-by http header
server.settings['x-powered-by'] = false;

// Serve static app assets from local /dist folder
server.use(
  '/dist',
  express.static('dist', {
    fallthrough: false, // force 404 for unknown assets under /dist
  })
);

// For any other requests, we render app routes server-side and return them
server.use('*', scProxy(config.serverBundle.renderView, config, config.serverBundle.parseRouteUrl));

server.listen(port, host, () => {
  console.log(`server listening on http://${host}:${port}`);
});
