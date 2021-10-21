using System.Collections.Generic;
using System.Linq;
using Content.Server.Radio.Components;
using JetBrains.Annotations;
using Robust.Shared.GameObjects;
using Content.Server.Comms;
using Robust.Shared.IoC;
using Robust.Shared.Random;
using System.Text;

namespace Content.Server.Radio.EntitySystems
{
    [UsedImplicitly]
    public class RadioSystem : EntitySystem
    {
        private readonly List<string> _messages = new();

        public void SpreadMessage(IRadio source, IEntity speaker, string message, int channel)
        {
            if (_messages.Contains(message)) return;

            var canSend = false;
            var corruptLevel = 0;
            foreach (var server in EntityManager.EntityQuery<CommunicationServerComponent>())
            {
                if (server.Enabled)
                {
                    canSend = true;
                    corruptLevel = server.CorruptLevel;
                    break;
                }
            }

            if (!canSend) return;

            if (corruptLevel > 0)
            {
                var random = IoCManager.Resolve<IRobustRandom>();

                var builder = new StringBuilder(message);
                for (var i = 0; i < builder.Length; i++)
                {
                    if (random.Next(4) < corruptLevel)
                    {
                        builder[i] = '*';
                    }
                }
                message = builder.ToString();
            }

            _messages.Add(message);

            foreach (var radio in EntityManager.EntityQuery<IRadio>(true))
            {
                if (radio.Channels.Contains(channel))
                {
                    //TODO: once voice identity gets added, pass into receiver via source.GetSpeakerVoice()
                    radio.Receive(message, channel, speaker);
                }
            }

            _messages.Remove(message);
        }
    }
}
