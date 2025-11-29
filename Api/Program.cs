using minimal_api;

IHostBuilder CreaterHostBuiler(string[] args)
{
  return Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder => {
    webBuilder.UseStartup<Startup>();
  });
}

CreaterHostBuiler(args).Build().Run();