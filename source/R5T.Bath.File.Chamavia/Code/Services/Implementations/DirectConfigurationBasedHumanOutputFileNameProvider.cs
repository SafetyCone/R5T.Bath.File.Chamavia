using System;

using Microsoft.Extensions.Configuration;

using R5T.Bath.File.Default;

using R5T.T0064;


namespace R5T.Bath.File.Chamavia
{
    [ServiceImplementationMarker]
    public class DirectConfigurationBasedHumanOutputFileNameProvider : IHumanOutputFileNameProvider, IServiceImplementation
    {
        public const string ConfigurationKey = "HumanOutputFileName";


        private IConfiguration Configuration { get; }


        public DirectConfigurationBasedHumanOutputFileNameProvider(
            IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public string GetHumanOutputFileName()
        {
            var humanOutputFileName = this.Configuration[DirectConfigurationBasedHumanOutputFileNameProvider.ConfigurationKey];
            return humanOutputFileName;
        }
    }
}
