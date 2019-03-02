const path = require('path');
const cpx = require('cpx');
const rimraf = require('rimraf');
const packageConfig = require('../package.json');

const jssAppName = packageConfig.config.appName;
const distFrom = path.join(__dirname, '../build/**/*.*');
const distTo = path.join(
    __dirname,
    '../../node-headless-ssr-proxy/dist',
    jssAppName
);

console.log('rm -rf ', distTo);
rimraf(distTo, (err) => {
    if (err) { throw err; }
    console.log('cp ', distFrom, distTo);
    cpx.copy(distFrom, distTo)
});
