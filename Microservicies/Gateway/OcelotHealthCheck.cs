		// add to pipline
		var conf = new OcelotPipelineConfiguration()
                {
                    PreErrorResponderMiddleware = async (ctx, next) =>
                    {
                        if (ctx.HttpContext.Request.Path.Equals(new PathString("/")))
                        {
                            await ctx.HttpContext.Response.WriteAsync("ok");
                        }
                        else
                        {
                            await next.Invoke();
                        }
                    }
                };
                app.UseOcelot(conf).Wait();
