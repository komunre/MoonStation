using Robust.Client.Graphics;
using Robust.Shared.GameObjects;
using Robust.Shared.Serialization.Manager.Attributes;
using Robust.Client.ResourceManagement;
using Robust.Shared.IoC;
using Content.Shared.Gravity;

namespace Content.Client.Planet
{
    [RegisterComponent]
    [ComponentReference(typeof(SharedPlanetComponent))]
    class PlanetComponent : SharedPlanetComponent
    {

        [DataField("texture")]
        private string _texturePath = "/Textures/Effects/land.rsi";
        public Texture? LandTexture;

        protected override void Initialize()
        {
            base.Initialize();

            LandTexture = IoCManager.Resolve<IResourceCache>().GetResource<TextureResource>(_texturePath);
        }
    }
}
