using System;
using System.Windows.Forms;

namespace Clipper
{
    public partial class ClipperForm : Form
    {
        private readonly TrojanClipper TrojanClipper = new TrojanClipper();
        private bool ClipperIsEnabled = false;

        public ClipperForm()
        {
            InitializeComponent();
        }

        private async void ButtonEnable_Click(object sender, EventArgs e)
        {
            ClipperIsEnabled = !ClipperIsEnabled;

            if(ClipperIsEnabled)
            {
                await TrojanClipper.StartClipper();
                buttonEnable.BackgroundImage = Properties.Resources.enabled;
            }
            else
            {
                await TrojanClipper.StopClipper();
                buttonEnable.BackgroundImage = Properties.Resources.disabled;
            }
        }
    }
}
