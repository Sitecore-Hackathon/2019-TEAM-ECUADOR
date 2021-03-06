# jss-application | Sitecore JSS React Starter Application

Consult the primary JSS documentation at https://jss.sitecore.net for the latest documentation on JSS.

## Setup

- Open a terminal
- Install the JSS CLI

    ```bash
    npm install -g @sitecore-jss/sitecore-jss-cli
    ```

- Run `npm install`

    ```bash
    cd src/Project/Website/jss-application
    npm install
    ```

## Deploying to Sitecore

* Add Sitecore instance `hostname` to your `hosts` file. For example:

    ```bash
    172.16.81.157 hackathon2019.sc
    ```

* Use `jss setup` to configure the connection to a local Sitecore installation

    ```bash
    cd src/Project/Website/jss-application
    jss setup
    ```

    Example:
    ```bash
    - Is your Sitecore instance on this machine or accessible via network share? [y/n]: **Y**
    - Path to the Sitecore folder (e.g. c:\inetpub\wwwroot\my.siteco.re): **/Volumes/wwwroot/Hackathon2019.sc**
    - Sitecore hostname (e.g. http://myapp.local.siteco.re; see /sitecore/config; ensure added to hosts): **http://hackathon2019.sc**
    - Sitecore import service URL [http://hackathon2019.sc/sitecore/api/jss/import]:
    - Sitecore API Key (ID of API key item): **{C3B3D601-1188-4413-963F-0EFAAC0CDB91}**
    ```

* Review the file `src/Project/Website/jss-application/scjssconfig.json` to ensure that it is configured appropriately for your Sitecore installation. 

    Example
    ```json
        {
            "sitecore": {
                "instancePath": "/Volumes/wwwroot/Hackathon2019.sc",
                "apiKey": "{C3B3D601-1188-4413-963F-0EFAAC0CDB91}",
                "deploySecret": "8pw0kveq8metdor9olrycp7c7mbm7gcv3tfsb1ojz",
                "deployUrl": "http://hackathon2019.sc/sitecore/api/jss/import",
                "layoutServiceHost": "http://hackathon2019.sc"
            }
        }
    ```
* Use `jss build:headless` to generate the application js/css bundles.

    ```bash
    cd src/Project/Website/jss-application
    jss build:headless
    ```

* Use `jss deploy:headless` to copy the build folder to the `node-headless-ssr-proxy/dist` folder.

    ```bash
    cd src/Project/Website/jss-application
    jss deploy:headless
    ```


## Optional 

> **If a manual `jss deploy config` needs to be performed, make sure to remote the deploy secret file from `\App_Config\Include\Foundation\jss-application.deploysecret` in the Sitecore Server Instance. Then, you can proceed with the jss deploy following the steps below.**

* Open the file `src/Project/Website/jss-application/sitecore/config/jss-application.config` and update the `hostName` and `targetHostName` attributes.

    ```xml
    <site name="website"
        hostName="[SITECORE_HOSTNAME]"
        targetHostName="[SITECORE_HOSTNAME]"
        rootPath="/sitecore/content/jss-application"
        startItem="/home"
        database="master"
        xdt:Transform="SetAttributes" 
        xdt:Locator="Match(name)"/>
    ```

* Use `jss deploy config` to deploy the Sitecore config patch files to the Sitecore instance (you may 
need to add the `hostName` to your `hosts` file)

    ```bash
    cd src/Project/Website/jss-application
    jss deploy config
    ```

* Use `jss deploy items -c -d` to deploy the sample to Sitecore

    ```bash
    cd src/Project/Website/jss-application
    jss deploy items -c -d
    ```

