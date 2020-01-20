using System;

using Microsoft.Extensions.Configuration;

using R5T.Lombardy;


namespace R5T.Bath.File.Chamavia
{
    public class DirectConfigurationBasedHumanOutputFilePathProvider : IHumanOutputFilePathProvider
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
