using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace EmployeeMgt.Localization
{
    public static class EmployeeMgtLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(EmployeeMgtConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(EmployeeMgtLocalizationConfigurer).GetAssembly(),
                        "EmployeeMgt.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
