﻿using System.Linq;
using System.Text;
using JetBrains.Annotations;
using NGM.OpenAuthentication.Providers.Facebook.Models;
using NGM.OpenAuthentication.Providers.Facebook.Services;
using NGM.OpenAuthentication.Services;
using Orchard.ContentManagement.Drivers;
using Orchard.Environment.Extensions;

namespace NGM.OpenAuthentication.Providers.Facebook.Drivers {
    [UsedImplicitly]
    [OrchardFeature("Authentication.Facebook")]
    public class FacebookConnectDriver : ContentPartDriver<FacebookConnectSignInPart> {
        private readonly IScopeProviderPermissionService _scopeProviderPermissionService;

        public FacebookConnectDriver(IScopeProviderPermissionService scopeProviderPermissionService) {
            _scopeProviderPermissionService = scopeProviderPermissionService;
        }

        protected override DriverResult Display(FacebookConnectSignInPart part, string displayType, dynamic shapeHelper) {
            var extendedPermissions = _scopeProviderPermissionService.Get(new FacebookAccessControlProvider()).Where(o => o.IsEnabled).Select(o => o.Scope);
            var stringBuilder = new StringBuilder();
            foreach (var extendedPermission in extendedPermissions) {
                stringBuilder.Append(extendedPermission);
                stringBuilder.Append(",");
            }
            if (stringBuilder.Length >= 1)
                stringBuilder.Remove(stringBuilder.Length - 1, 1);

            return ContentShape("FacebookConnectSignIn", () => shapeHelper.FacebookConnectSignIn(Model: part, Permissions: stringBuilder.ToString()));
        }
    }
}