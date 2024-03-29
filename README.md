# simple-versioning-middleware
[![Build & Publish](https://github.com/guypritchard/simple-versioning-middleware/actions/workflows/publish.yml/badge.svg)](https://github.com/guypritchard/simple-versioning-middleware/actions/workflows/publish.yml)

Super simple service versioning middleware

This middleware simply returns the versioning information of (in all likelihood a webapi service) the micro-service you are interested in.

This can be useful if trying to track the deployed version of your service, particularly helpful for troubleshooting. 

Will ensure that versioning information is returned either by:

* An endpoint
  * /version (careful for clashes - can be changed in ServiceVersioningMiddlewareOptions)
* A header on each request.
  * 'X-Service-Version' and 'X-Service-Description'

e.g.  
Specify both header and endpoint versioning:

```
public void Configure(IApplicationBuilder app, IHostingEnvironment env)
{
...
    app.UseServiceVersioning(
                new ServiceVersioningMiddlewareOptions
                {
                    VersioningType = ServiceVersioningType.Header | ServiceVersioningType.Endpoint
                });
...
}
```

