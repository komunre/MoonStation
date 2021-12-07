using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Content.Client.Parallax;
using Robust.Client.Graphics;
using Robust.Client.Player;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;

namespace Content.Client.Planet
{
    class PlanetSystem : EntitySystem
    {
        [Dependency] private readonly IPlayerManager _playerManager = default!;
        [Dependency] private readonly IOverlayManager _overlayManager = default!;
        private bool _space = true;
        public override void Initialize()
        {
            
        }

        public override void Update(float frameTime)
        {
            base.Update(frameTime);

            foreach (var planet in EntityManager.EntityQuery<PlanetComponent>())
            {
                if (planet.Owner.Transform.MapID == _playerManager.LocalPlayer?.ControlledEntity?.Transform.MapPosition.MapId)
                {
                    _space = false;
                    var parallax = _overlayManager.GetOverlay<ParallaxOverlay>();
                    parallax.Slowness = -1.5f;
                    parallax.ParallaxTexture = planet.LandTexture;
                    return;
                }
            }

            if (!_space)
            {
                _space = true;
                var paral = _overlayManager.GetOverlay<ParallaxOverlay>();
                paral.Slowness = 0.5f;
                paral.SetToDefaultTex();
            }
        }
    }
}
