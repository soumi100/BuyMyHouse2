using DAL;
using Domain;
using Microsoft.Azure.Functions.Worker.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System.IO;
using System.Threading.Tasks;
using System;
using System.Configuration;
using BuyMyHouseAgenet.Service;
using BuyMyHouseAgenet.Auth;
using BuyMyHouseAgenet.Service.Interface;

namespace BuyMyHouseAgenet
{
    public class Program
    {
        public static async Task Main()
        {
           
            var host = new HostBuilder()
                .ConfigureFunctionsWorkerDefaults()
                .ConfigureServices(Configure)
                .Build();

            host.Run();
        }
        static void Configure(HostBuilderContext Builder, IServiceCollection Services)
        {
            Services.AddTransient<IHouseRepo, HouseRepo>();
            Services.AddTransient<IApplicantRepo, ApplicantRepo>();

            Services.AddTransient<IHouseService, HouseService>();
            Services.AddTransient<IApplicantService, ApplicantService>();
            // Services.AddTransient<IMortgageApplicationService, MortgageApplicationService>();

            Services.AddScoped<IJwtTokenUtils, JwtTokenTokenUtils>();
            //Services.AddScoped<IUserService, UserService>();
            Services.AddScoped<AuthorizationChecker>();

            Services.AddScoped<HouseService>();
            Services.AddScoped<ApplicantService>();
            Services.AddScoped<MortgageApplicationService>();
        }

    }
}