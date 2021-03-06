using System;
using Robust.Shared.GameObjects;
using Robust.Shared.Serialization;

namespace Content.Shared.Pointing.Components
{
    public class SharedRoguePointingArrowComponent : Component
    {
        public sealed override string Name => "RoguePointingArrow";
    }

    [Serializable, NetSerializable]
    public enum RoguePointingArrowVisuals
    {
        Rotation
    }
}
