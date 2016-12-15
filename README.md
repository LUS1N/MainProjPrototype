# MainProjPrototype

To run the Angular app with Angular CLI you need to install it first. 

`npm install -g angular-cli`

Then install node_modules in the Web directory

`npm install`

Build the app 

`ng build --prod`

And a dist folder will be generated, which you can use to host the app on IIS. To do that copy the web.config file from `/Web` to `/dist`to add the url rewrite.

Or you can run the app on the localhost without building it with

`ng server`

This will not work properly on Chrome, because it doesn't allow CORS, works fine with firefox though.
