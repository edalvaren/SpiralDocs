    using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SpiralDocs.Areas.Identity.Data;
using SpiralDocs.Models;

[assembly: HostingStartup(typeof(SpiralDocs.Areas.Identity.IdentityHostingStartup))]
namespace SpiralDocs.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<SpiralDocsContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("SpiralDocsContextConnection")));

                services.AddDefaultIdentity<SpiralDocsUser>()
                    .AddEntityFrameworkStores<SpiralDocsContext>();
            });
        }
    }
}