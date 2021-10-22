using Robust.Client.UserInterface.CustomControls;
using Robust.Client.UserInterface.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content.Client.Comms
{
    class CommunicationServerWindow : SS14Window
    {
        public Button Toggle;
        public Button CorruptLevel0;
        public Button CorruptLevel1;
        public Button CorruptLevel2;
        public CommunicationServerWindow()
        {
            Title = "Communications Server";
            Contents.AddChild(new BoxContainer()
            {
                Children = {
                    new Label()
                    {
                        Text = "Corrupt level: ",
                    },
                    new BoxContainer()
                    {
                        Orientation = BoxContainer.LayoutOrientation.Horizontal,
                        Children =
                        {
                            (CorruptLevel0 = new Button() {
                                Text = "0",
                            }),
                            (CorruptLevel1 = new Button()
                            {
                                Text = "1",
                            }),
                            (CorruptLevel2 = new Button()
                            {
                                Text = "2",
                            })
                        },
                    },
                    new Label() {
                        Text = "Power: ",
                    },
                    (Toggle = new Button()),

                }
            });
        }
    }
}
