using System;
using System.Collections.Generic;
using System.Text;
using Robust.Shared.GameObjects;
using Content.Server.Power.Components;
using Content.Shared.Interaction;
using Robust.Shared.ViewVariables;
using Robust.Server.GameObjects;
using Content.Shared.Comms;
using Content.Server.UserInterface;
using System.Threading.Tasks;

namespace Content.Server.Comms
{
    [RegisterComponent]
    [ComponentReference(typeof(IActivate))]
    [ComponentReference(typeof(IInteractUsing))]
    public class CommuncationServerComponent : Component, IActivate, IInteractUsing
    {
        public override string Name => "CommunicationServer";
        [ViewVariables]
        public byte CorruptLevel = 0;
        [ViewVariables]
        public bool Enabled = true;
        public BoundUserInterface? UserInterface => Owner.GetUIOrNull(CommsUiKey.Key);

        protected override void Initialize()
        {
            base.Initialize();

            if (UserInterface != null)
            {
                UserInterface.OnReceiveMessage += OnReceiveUiMessage;
            }
        }
        public bool ReceiveMessage()
        {
            if (!Enabled || !Owner.TryGetComponent<ApcPowerReceiverComponent>(out var receiver) || !receiver.Powered) return false;

            return true;
        }

        void IActivate.Activate(ActivateEventArgs eventArgs)
        {
            if (!eventArgs.User.TryGetComponent(out ActorComponent? actor))
            {
                return;
            }

            UserInterface?.Open(actor.PlayerSession);
        }

        async Task<bool> IInteractUsing.InteractUsing(InteractUsingEventArgs eventArgs)
        {
            if (!eventArgs.User.TryGetComponent(out ActorComponent? actor))
            {
                return false;
            }

            UserInterface?.Open(actor.PlayerSession);
            return true;
        }

        private void OnReceiveUiMessage(ServerBoundUserInterfaceMessage obj)
        {
            if (obj.Session.AttachedEntity == null) return;

            var msg = (CommsUserInterfaceMessage) obj.Message;

            switch (msg.Action)
            {
                case CommsUIAction.Toggle:
                    Enabled = !Enabled;
                    break;
                case CommsUIAction.CorruptLevel0:
                    CorruptLevel = 0;
                    break;
                case CommsUIAction.CorruptLevel1:
                    CorruptLevel = 1;
                    break;
                case CommsUIAction.CorruptLevel2:
                    CorruptLevel = 2;
                    break;
            }
        }
    }
}
