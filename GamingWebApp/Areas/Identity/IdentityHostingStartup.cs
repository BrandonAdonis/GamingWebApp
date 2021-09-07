using System;
using GamingWebApp.Areas.Identity.Data;
using GamingWebApp.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(GamingWebApp.Areas.Identity.IdentityHostingStartup))]
namespace GamingWebApp.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<GamingWebDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("GamingWebDbContextConnection")));

                services.AddDefaultIdentity<GamingWebAppUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<GamingWebDbContext>();
            });
        }
    }
}