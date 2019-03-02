# Headless server-side rendering on top of node.js and Express.

Characteristics:
- Rendering performed by server (SSR by Node-as-a-service provider, i.e. Azure App Service, Netlify, Heroku, etc)
- Data comes from Sitecore CD server via LayoutService API (HTTP calls)
- Full Sitecore marketing/personalization engine support
- Usages: decoupling rendering of the JSS app from Sitecore, multichannel API usage

![Headless server-side rendering mode](https://jss.sitecore.com/assets/img/mode-headless.svg)

The setup is using `sitecore-jss-proxy` that enables request proxying to Sitecore CD along with the http cookies to enable tracking, personalization and contact identification.

You can use this as a starting point to unlock deployment of your JSS apps to any managed node.js hosting environment (Azure App Service, Heroku, IBM BlueMix, you name it).

## Environment Variables

The following environment variables can be set to configure the proxy instead of modifying `config.js`, for environments where this is more desirable like containers:

| Parameter                              | Description                                                   |
| -------------------------------------- | ------------------------------------------------------------- |
| `SITECORE_API_HOST`                    | Sitecore instance host name. Should be HTTPS in production.   |
| `SITECORE_API_IP`                      | Sitecore instance IP that is the backend for JSS.             |
| `SITECORE_JSS_APP_NAME`                |  The JSS application name defaults to providing part of the bundle path as well as the dictionary service endpoint   |
| `NODE_SSR_PROXY_HOST`                  | Node SSR Proxy Host(Network interface).                       |
| `NODE_SSR_PROXY_PORT`                  | Node SSR Proxy Port.                                          |

## Setup

- Rename `.env-example` file to `.env` and change the environment variables:

    ```env
    SITECORE_API_HOST=http://hackathon2019.sc
    SITECORE_API_IP=172.16.81.157
    SITECORE_JSS_APP_NAME=jss-application
    NODE_SSR_PROXY_HOST=172.16.81.250
    NODE_SSR_PROXY_PORT=8080
    ```

## Build & deploy `jss-application`

- Build your JS app bundle with `jss build:headless`.

    ```bash
    cd src/Project/Website/jss-application
    ```
    **Follow the jss-application [installation guide](../jss-application)**


- Deploy the build artifacts from your app (`/build` within the app) to the `sitecoreDistPath` set in your app's `package.json` under the proxy root path. Most apps use `/dist/${jssAppName}`, for example `$proxyRoot/dist/${jssAppName}`.

    ```bash
    cd src/Project/Website/jss-application
    jss deploy:headless
    ```

## Build & run

- Run `npm install`

    ```bash
    cd src/Project/Website/node-headless-ssr-proxy
    npm install
    ```

- Run `npm start`

    ```bash
    cd src/Project/Website/node-headless-ssr-proxy
    npm start
    ```

You should be able to see the following message:
`server listening on ${host}:${port}` and see all the communication between this server and your Sitecore CD instance in the console.

More info on this setup can be found [here](https://jss.sitecore.net/#/application-modes?id=headless-server-side-rendering-mode).
