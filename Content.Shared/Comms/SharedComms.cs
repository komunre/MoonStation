using Robust.Shared.GameObjects;
using Robust.Shared.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content.Shared.Comms
{
    [Serializable, NetSerializable]
    public enum CommsUiKey
    {
        Key,
    }

    public enum CommsUIAction
    {
        CorruptLevel0,
        CorruptLevel1,
        CorruptLevel2,
        Toggle,
    }

    [Serializable, NetSerializable]
    public class CommsUserInterfaceMessage : BoundUserInterfaceMessage
    {
        public CommsUIAction Action;
        public CommsUserInterfaceMessage(CommsUIAction action)
        {
            Action = action;
        }
    }
}
