using System;

using Microsoft.Extensions.Configuration;

using R5T.Bath.File.Default;
using R5T.Lombardy;

using R5T.T0064;


namespace R5T.Bath.File.Chamavia
{
    [ServiceImplementationMarker]
    public class DirectConfigurationBasedHumanOutputFileDirectoryPathProvider : IHumanOutputFileDirectoryPathProvider, IServiceImplementation
    {
        public const string ConfigurationKey = "HumanOutputFileDirectoryPath";


        private IConfiguration Configuration { get; }
        private IStringlyTypedPathOperator StringlyTypedPathOperator { get; }


        public DirectConfigurationBasedHumanOutputFileDirectoryPathProvider(
            IConfiguration configuration,
            IStringlyTypedPathOperator stringlyTypedPathOperator)
        {
            this.Configuration = configuration;
            this.StringlyTypedPathOperator = stringlyTypedPathOperator;
        }

        public string GetHumanOutputFileDirectoryPath()
        {
            var rawHumanOutputFileDirectoryPath = this.Configuration[DirectConfigurationBasedHumanOutputFileDirectoryPathProvider.ConfigurationKey];

            var humanOutputFileDirectoryPath = this.StringlyTypedPathOperator.EnsureDirectorySeparator(rawHumanOutputFileDirectoryPath);
            return humanOutputFileDirectoryPath;
        }
    }
}
