using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stormancer;
using Stormancer.Plugins.Relay;

namespace Stormancer.Plugins
{
    public class RelayPlugin : IClientPlugin
    {
        public const string METADATA_KEY = "stormancer.relay";

        public void Build(PluginBuildContext ctx)
        {
            ctx.SceneCreated += SceneScreated;
        }

        private void SceneScreated(Scene scene)
        {
            if (scene.GetHostMetadata(METADATA_KEY) == "enabled")
            {
                var service = new RelayService(scene);
                scene.DependencyResolver.RegisterComponent(service);
            }
        }
    }
}
