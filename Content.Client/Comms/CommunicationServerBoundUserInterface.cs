using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Robust.Client.GameObjects;
using Robust.Client.UserInterface;
using Robust.Shared.GameObjects;
using Content.Shared.Comms;
using JetBrains.Annotations;

namespace Content.Client.Comms
{
    [UsedImplicitly]
    public class CommunicationServerBoundUserInterface : BoundUserInterface
    {
        private CommunicationServerWindow? _commsWindow;
        public CommunicationServerBoundUserInterface(ClientUserInterfaceComponent owner, object key) : base(owner, key)
        {

        }

        protected override void Open()
        {
            _commsWindow = new CommunicationServerWindow();
            _commsWindow.OpenCentered();
            _commsWindow.OnClose += Close;

            _commsWindow.Toggle.OnPressed += _ => SendMessage(new CommsUserInterfaceMessage(CommsUIAction.Toggle));
            _commsWindow.CorruptLevel0.OnPressed += _ => SendMessage(new CommsUserInterfaceMessage(CommsUIAction.CorruptLevel0));
            _commsWindow.CorruptLevel1.OnPressed += _ => SendMessage(new CommsUserInterfaceMessage(CommsUIAction.CorruptLevel1));
            _commsWindow.CorruptLevel2.OnPressed += _ => SendMessage(new CommsUserInterfaceMessage(CommsUIAction.CorruptLevel2));

            base.Open();
        }
    }
}
