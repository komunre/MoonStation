using Content.Server.Chemistry.Components;
using JetBrains.Annotations;
using Robust.Shared.GameObjects;
using Robust.Shared.Serialization.Manager.Attributes;

namespace Content.Server.Chemistry.ReactionEffects
{
    [UsedImplicitly]
    [DataDefinition]
    public class FoamAreaReactionEffect : AreaReactionEffect
    {
        protected override SolutionAreaEffectComponent? GetAreaEffectComponent(IEntity entity)
        {
            return entity.GetComponentOrNull<FoamSolutionAreaEffectComponent>();
        }
    }
}
