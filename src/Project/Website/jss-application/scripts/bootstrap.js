const configGenerator = require('./generate-config');
const path = require('path');

/*
  BOOTSTRAPPING
  The bootstrap process runs before build, and generates JS that needs to be
  included into the build - specifically, the component name to component mapping,
  and the global config module.
*/

const disconnected = process.argv.some((arg) => arg === '--disconnected');
const proxy = process.argv.some((arg) => arg === '--proxy');

/*
  CONFIG GENERATION
  Generates the /src/temp/config.js file which contains runtime configuration
  that the app can import and use.
*/
const port = process.env.PORT || 3000;
let configOverride = disconnected ? { sitecoreApiHost: `http://localhost:${port}` } : null;

if (proxy) {
    // load node-headless-ssr-proxy/.env file
    require('dotenv').config({ 
        path: path.join(__dirname, '../../node-headless-ssr-proxy/.env')
    });
    const proxyHost = process.env.NODE_SSR_PROXY_HOST || 'localhost';
    const proxyPort = process.env.NODE_SSR_PROXY_PORT || '3000';
    configOverride = proxy ? { sitecoreApiHost: `http://${proxyHost}:${proxyPort}`} : configOverride;
}

configGenerator(configOverride);

/*
  COMPONENT FACTORY GENERATION
*/
require('./generate-component-factory');
