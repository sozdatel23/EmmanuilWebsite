using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using EmmanuilWebsite.Service;

namespace EmmanuilWebsite
{
	public class Startup
	{
		public IConfiguration Configuration { get; }
		public Startup(IConfiguration configuration) => Configuration = configuration;

		[Obsolete]//может в коммент поместить???
		public void ConfigureServices(IServiceCollection services)
		{
			//подключение конфига из appsettings.json
			Configuration.Bind("Project", new Config());

			//добавление поддержки контроллеров и представлений(MVC)
			services.AddControllersWithViews()
				.SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Latest)
				.AddSessionStateTempDataProvider();
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			//отчеты ошибок
			if(env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseRouting();

			//поддержка css, js, и др.
			app.UseStaticFiles();

			//добавление маршрутов
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
