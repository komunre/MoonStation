using Robust.Shared.GameObjects;
using Content.Shared.Gravity;

namespace Content.Server.Gravity
{
    [RegisterComponent]
    [ComponentReference(typeof(SharedPlanetComponent))]
    class PlanetComponent : SharedPlanetComponent
    {
        
    }
}
