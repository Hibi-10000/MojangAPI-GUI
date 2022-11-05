using System.Diagnostics;

namespace MojangAPI_GUI_dotnet
{
    public partial class DebugWindow : Form
    {   
        public DebugWindow()
        {
            InitializeComponent();
        }

        private void DebugWindow_Load(object sender, EventArgs e)
        {

        }

        MojangApiRest mojangApiRest = new MojangApiRest("6ffeb3a8-72d0-4da1-a2dc-4e4f0246430c");
        Process p = new Process();

        private void DebugWindow_SizeChanged(object sender, EventArgs e)
        {
            ShowResponceTextBox.Size = new Size(this.Size.Width - 40, this.Size.Height - 121);
        }

        private void MSAuthDevice_Click(object sender, EventArgs e)
        {
            ShowResponceTextBox.Text = mojangApiRest.MSAuthDevice();
        }

        private void ShowResponceTextBox_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo(e.LinkText);
            startInfo.UseShellExecute = true;
            Process.Start(startInfo);
        }

        private void MSAuthToken_Click(object sender, EventArgs e)
        {
            ShowResponceTextBox.Text = mojangApiRest.MSAuthToken();
        }

        private void XboxLiveToken_Click(object sender, EventArgs e)
        {
            ShowResponceTextBox.Text = mojangApiRest.XboxLiveToken();
        }

        private void XboxLiveXSTSToken_Click(object sender, EventArgs e)
        {
            ShowResponceTextBox.Text = mojangApiRest.XboxLiveXSTSToken();
        }

        private void MinecraftServicesAccessToken_Click(object sender, EventArgs e)
        {
            ShowResponceTextBox.Text = mojangApiRest.MinecraftServicesAccessToken();
        }

        private void MCProfile_Click(object sender, EventArgs e)
        {
            ShowResponceTextBox.Text = mojangApiRest.MinecraftProfile();
        }

        private void MCNameChangeInfo_Click(object sender, EventArgs e)
        {
            ShowResponceTextBox.Text = mojangApiRest.MinecraftNameChangeInfo();
        }
    }
}