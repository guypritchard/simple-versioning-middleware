# simple-versioning-middleware
Super simple service versioning middleware

Will ensure that versioning information is returned either by:

* An endpoint
  * /version (careful for clashes - can be changed in ServiceVersioningMiddlewareOptions)
* A header on each request.
  * 'X-Service-Version' and/or 'X-Service-Description'

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

