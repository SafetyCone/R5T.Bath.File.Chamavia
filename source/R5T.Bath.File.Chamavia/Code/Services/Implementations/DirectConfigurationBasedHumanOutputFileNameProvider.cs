using System;

using Microsoft.Extensions.Configuration;


namespace R5T.Bath.File.Chamavia
{
    public class DirectConfigurationBasedHumanOutputFileNameProvider : IHumanOutputFileNameProvider
    {
        public const string ConfigurationKey = "HumanOutputFileName";


        private IConfiguration Configuration { get; }


        public DirectConfigurationBasedHumanOutputFileNameProvider(IConfiguration configuration)
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
