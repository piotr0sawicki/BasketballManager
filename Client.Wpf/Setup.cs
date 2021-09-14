using Client.Core.Api;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.Platforms.Wpf.Core;
using MvvmCross.Platforms.Wpf.Views;
using MvvmCross.Views;
using Serilog;
using Serilog.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Wpf.Views
{
    public class Setup : MvxWpfSetup<Core.App>
    {
        protected override ILoggerProvider CreateLogProvider()
        {
            return new SerilogLoggerProvider();
        }

        protected override ILoggerFactory CreateLogFactory()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .CreateLogger();

            return new SerilogLoggerFactory();
        }
        protected override void InitializeLastChance(IMvxIoCProvider iocProvider)
        {


            Mvx.IoCProvider.RegisterSingleton(AddConfiguration());
            Mvx.IoCProvider.RegisterSingleton<IApiHelper>(new ApiHelper(Mvx.IoCProvider.Resolve<IConfiguration>()));
            Mvx.IoCProvider.RegisterSingleton<IGameEndpoint>(new GameEndpoint(Mvx.IoCProvider.Resolve<IApiHelper>()));

            base.InitializeLastChance(iocProvider);

        }

        private IConfiguration AddConfiguration()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory());
            var r = Directory.GetCurrentDirectory();
            builder.AddJsonFile("appsettings.json");

            return builder.Build();
        }
    }
}
