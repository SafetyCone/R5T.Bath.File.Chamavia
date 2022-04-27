using System;

using Microsoft.Extensions.Configuration;

using R5T.Lombardy;

using R5T.T0064;


namespace R5T.Bath.File.Chamavia
{
    [ServiceImplementationMarker]
    public class DirectConfigurationBasedHumanOutputFilePathProvider : IHumanOutputFilePathProvider, IServiceImplementation
    {
        public const string ConfigurationKey = "HumanOutputFilePath";


        private IConfiguration Configuration { get; }
        private IStringlyTypedPathOperator StringlyTypedPathOperator { get; }


        public DirectConfigurationBasedHumanOutputFilePathProvider(IConfiguration configuration, IStringlyTypedPathOperator stringlyTypedPathOperator)
        {
            this.Configuration = configuration;
            this.StringlyTypedPathOperator = stringlyTypedPathOperator;
        }

        public string GetHumanOutputFilePath()
        {
            var rawHumanOutputFilePath = this.Configuration[DirectConfigurationBasedHumanOutputFilePathProvider.ConfigurationKey];

            var humanOutputFilePath = this.StringlyTypedPathOperator.EnsureDirectorySeparator(rawHumanOutputFilePath);
            return humanOutputFilePath;
        }
    }
}
