using Content.Server.Atmos.EntitySystems;
using Content.Server.Atmos.Reactions;

namespace Content.Server.Atmos
{
    public interface IGasReactionEffect
    {
        ReactionResult React(GasMixture mixture, IGasMixtureHolder? holder, AtmosphereSystem atmosphereSystem);
    }
}
