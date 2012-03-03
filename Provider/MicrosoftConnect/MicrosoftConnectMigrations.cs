using NGM.OpenAuthentication.Models;
using NGM.OpenAuthentication.Provider.MicrosoftConnect.Models;
using Orchard.ContentManagement.MetaData;
using Orchard.Core.Contents.Extensions;
using Orchard.Data.Migration;
using Orchard.Environment.Extensions;

namespace NGM.OpenAuthentication.Provider.MicrosoftConnect {
    [OrchardFeature("MicrosoftConnect")]
    public class MicrosoftConnectMigrations : DataMigrationImpl {
        public int Create() {
            ContentDefinitionManager.AlterPartDefinition(typeof(MicrosoftConnectSignInPart).Name, cfg => MetaDataExtensions.Attachable(cfg));

            ContentDefinitionManager.AlterTypeDefinition("MicrosoftConnectSignInWidget", cfg => cfg
                                                                                                    .WithPart("MicrosoftConnectSignInPart")
                                                                                                    .WithPart("WidgetPart")
                                                                                                    .WithPart("CommonPart")
                                                                                                    .WithSetting("Stereotype", "Widget"));

            return 1;
        }
    }
}