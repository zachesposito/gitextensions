﻿using System.ComponentModel.Composition;
using GitExtensions.Plugins.ProxySwitcher.Properties;
using GitUIPluginInterfaces;
using ResourceManager;

namespace GitExtensions.Plugins.ProxySwitcher
{
    [Export(typeof(IGitPlugin))]
    public class ProxySwitcherPlugin : GitPluginBase
    {
        public readonly StringSetting Username = new("Username", string.Empty);
        public readonly StringSetting Password = new("Password", string.Empty);
        public readonly StringSetting HttpProxy = new("HTTP proxy", string.Empty);
        public readonly StringSetting HttpProxyPort = new("HTTP proxy port", "8080");

        public ProxySwitcherPlugin() : base(true)
        {
            Name = "Proxy Switcher";
            Translate();
            Icon = Resources.IconProxySwitcher;
        }

        public override System.Collections.Generic.IEnumerable<ISetting> GetSettings()
        {
            yield return Username;
            yield return Password;
            yield return HttpProxy;
            yield return HttpProxyPort;
        }

        public override bool Execute(GitUIEventArgs args)
        {
            using var form = new ProxySwitcherForm(this, Settings, args);
            form.ShowDialog(args.OwnerForm);

            return false;
        }
    }
}
