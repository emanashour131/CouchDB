WebApplicationBuilder webApplicationBuilder = WebApplication.CreateBuilder(args);

webApplicationBuilder.Services.AddControllers();

CouchDBBaseRepository<Book> bookRepository = await CouchDbUtilities<Book>.InitializeCouchClientInstanceAsync();
webApplicationBuilder.Services.AddSingleton(bookRepository);
webApplicationBuilder.Services.AddHttpClient();

WebApplication webApplication = webApplicationBuilder.Build();

if (webApplication.Environment.IsDevelopment())
    webApplication.UseWebAssemblyDebugging();
else
    webApplication.UseHsts();

webApplication.UseHttpsRedirection();

webApplication.UseBlazorFrameworkFiles();
webApplication.UseStaticFiles();

webApplication.UseRouting();


webApplication.MapControllers();
webApplication.MapFallbackToFile("index.html");

webApplication.Run();
