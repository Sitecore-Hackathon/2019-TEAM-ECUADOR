## Summary

**Category:** JSS

We had leveraged the JSS architecture ([Headless server-side rendering mode](https://jss.sitecore.com/docs/fundamentals/application-modes)) to Implement a Redirect Manager module in a Node server by extending the Out-Of-The-Box characteristics. This is the architecture recommended by Sitecore for high traffic production sites because it provides better scalability and lower hosting costs. The purpose of the JSS Redirect Manager is to allow Content Authors of sites created using JSS, with a Node server on top of the Sitecore server, to create redirects that would otherwise be imposible with the current Redirect Managers in the market. 

## Pre-requisites


Node [NodeJSv.10.15.1](https://nodejs.org/dist/latest-v10.x/)

JSS [11.0](https://dev.sitecore.net/Downloads/Sitecore_JavaScript_Services/110/Sitecore_JavaScript_Services_1100.aspx)

## Installation

1. Use the Sitecore Installation wizard to install the [package](/sc.package/JSSRedirectManager-20190302.5.zip)
2. Perform a full site publish.
3. Follow the [Sitecore JSS proxy installation guide](/src/Project/Website/node-headless-ssr-proxy)

## Configuration

1. Sample redirects have been provided under /sitecore/content/JSS Redirects. New items can be created (via insert options of the mentioned folder) to demonstrate the benefits of the JSS Redirect Manager. 

2. In order to interact with JSS applications, an Api Key is needed. In the installed package, an Api Key was included for ease-of-installation purposes. If, by any case, the Api Key needs to be different please refer to [Sitecore JSS proxy installation guide](/src/Project/Website/node-headless-ssr-proxy) to update the Api Key ID

3. Go to App_Config/Include/Foundation/Foundation.RedirectManager.JSSSettings.config and modify the JSS.RedirectManager.ClearNodeCacheUrl setting with the host of your Node server

```
<configuration xmlns:patch="http://www.sitecore.net/xmlconfig/" xmlns:set="http://www.sitecore.net/xmlconfig/set/">
    <sitecore>
        <settings>
            <setting name="JSS.RedirectManager.RedirectTemaplateID" value="D641E449-3250-4AF7-B380-709D5134916C"/>
            <setting name="JSS.RedirectManager.ClearNodeCacheUrl" value="http://172.16.81.250:8080/cache"/>
        </settings>
    </sitecore>
</configuration>
```

## Usage

The JSS Redirect Module comes with:
1. A sample JSS application (Demo application).
2. A Node server.
3. A few redirect examples.

Users can create redirects anywhere under /sitecore/content (preferrably under /sitecore/content/JSS Redirects). The Node server will retrieve these redirects from Sitecore and will cache them. This cache gets invalidated when any redirect item is published so that the Node server has always the most up-to-date information from Sitecore.

Redirects have the following fields: 
![Redirect Fields](https://raw.githubusercontent.com/Sitecore-Hackathon/2019-TEAM-ECUADOR/master/documentation/images/redirect.PNG)

1. Redirect Type: The redirect options are 301, 302 and Server transfer.
2. Preserve Query String: If chequed, when performin a redirect, the query string will be preserved. If not checked, the query string will be lost after the redirect.
3. Old Url: Specify the url you would like to redirect from (Accepts regular expressions)
4. New Url: Specify the url you would like to go to (Accepts regular expressions)

After a new redirect has been created, make sure to publish so that the Node server gets the latest data from Sitecore. Whenever a request that matches one of your redirect rules come, the Node server will be in charge of performing the redirect and serving the right page. 

The demo JSS application was included as part of this module so that redirects can be tested. Some pages were added: /styleguide, /graphql and /styleguide 2. You can create new redirects to this pages or just test the sample redirects that come with the application. 


## Video

Please provide a video highlighing your Hackathon module submission and provide a link to the video. Either a [direct link](https://www.youtube.com/watch?v=EpNhxW4pNKk) to the video, upload it to this documentation folder or maybe upload it to Youtube...

[![Sitecore Hackathon Video Embedding Alt Text](https://img.youtube.com/vi/EpNhxW4pNKk/0.jpg)](https://www.youtube.com/watch?v=EpNhxW4pNKk)
