namespace MojangAPI_GUI_dotnet
{
    partial class DebugWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MSAuthDevice = new System.Windows.Forms.Button();
            this.ShowResponceTextBox = new System.Windows.Forms.RichTextBox();
            this.MSAuthToken = new System.Windows.Forms.Button();
            this.XboxLiveToken = new System.Windows.Forms.Button();
            this.XboxLiveXSTSToken = new System.Windows.Forms.Button();
            this.MinecraftServicesAccessToken = new System.Windows.Forms.Button();
            this.MCProfile = new System.Windows.Forms.Button();
            this.MCNameChangeInfo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // MSAuthDevice
            // 
            this.MSAuthDevice.Location = new System.Drawing.Point(12, 12);
            this.MSAuthDevice.Name = "MSAuthDevice";
            this.MSAuthDevice.Size = new System.Drawing.Size(93, 23);
            this.MSAuthDevice.TabIndex = 0;
            this.MSAuthDevice.Text = "MSAuthDevice";
            this.MSAuthDevice.UseVisualStyleBackColor = true;
            this.MSAuthDevice.Click += new System.EventHandler(this.MSAuthDevice_Click);
            // 
            // ShowResponceTextBox
            // 
            this.ShowResponceTextBox.AcceptsTab = true;
            this.ShowResponceTextBox.Location = new System.Drawing.Point(12, 70);
            this.ShowResponceTextBox.Name = "ShowResponceTextBox";
            this.ShowResponceTextBox.Size = new System.Drawing.Size(676, 363);
            this.ShowResponceTextBox.TabIndex = 1;
            this.ShowResponceTextBox.Text = "";
            this.ShowResponceTextBox.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.ShowResponceTextBox_LinkClicked);
            // 
            // MSAuthToken
            // 
            this.MSAuthToken.Location = new System.Drawing.Point(111, 12);
            this.MSAuthToken.Name = "MSAuthToken";
            this.MSAuthToken.Size = new System.Drawing.Size(89, 23);
            this.MSAuthToken.TabIndex = 2;
            this.MSAuthToken.Text = "MSAuthToken";
            this.MSAuthToken.UseVisualStyleBackColor = true;
            this.MSAuthToken.Click += new System.EventHandler(this.MSAuthToken_Click);
            // 
            // XboxLiveToken
            // 
            this.XboxLiveToken.Location = new System.Drawing.Point(206, 12);
            this.XboxLiveToken.Name = "XboxLiveToken";
            this.XboxLiveToken.Size = new System.Drawing.Size(94, 23);
            this.XboxLiveToken.TabIndex = 3;
            this.XboxLiveToken.Text = "XboxLiveToken";
            this.XboxLiveToken.UseVisualStyleBackColor = true;
            this.XboxLiveToken.Click += new System.EventHandler(this.XboxLiveToken_Click);
            // 
            // XboxLiveXSTSToken
            // 
            this.XboxLiveXSTSToken.Location = new System.Drawing.Point(306, 12);
            this.XboxLiveXSTSToken.Name = "XboxLiveXSTSToken";
            this.XboxLiveXSTSToken.Size = new System.Drawing.Size(119, 23);
            this.XboxLiveXSTSToken.TabIndex = 4;
            this.XboxLiveXSTSToken.Text = "XboxLiveXSTSToken";
            this.XboxLiveXSTSToken.UseVisualStyleBackColor = true;
            this.XboxLiveXSTSToken.Click += new System.EventHandler(this.XboxLiveXSTSToken_Click);
            // 
            // MinecraftServicesAccessToken
            // 
            this.MinecraftServicesAccessToken.Location = new System.Drawing.Point(431, 12);
            this.MinecraftServicesAccessToken.Name = "MinecraftServicesAccessToken";
            this.MinecraftServicesAccessToken.Size = new System.Drawing.Size(175, 23);
            this.MinecraftServicesAccessToken.TabIndex = 5;
            this.MinecraftServicesAccessToken.Text = "MinecraftServicesAccessToken";
            this.MinecraftServicesAccessToken.UseVisualStyleBackColor = true;
            this.MinecraftServicesAccessToken.Click += new System.EventHandler(this.MinecraftServicesAccessToken_Click);
            // 
            // MCProfile
            // 
            this.MCProfile.Location = new System.Drawing.Point(612, 12);
            this.MCProfile.Name = "MCProfile";
            this.MCProfile.Size = new System.Drawing.Size(76, 23);
            this.MCProfile.TabIndex = 6;
            this.MCProfile.Text = "MCProfile";
            this.MCProfile.UseVisualStyleBackColor = true;
            this.MCProfile.Click += new System.EventHandler(this.MCProfile_Click);
            // 
            // MCNameChangeInfo
            // 
            this.MCNameChangeInfo.Location = new System.Drawing.Point(12, 41);
            this.MCNameChangeInfo.Name = "MCNameChangeInfo";
            this.MCNameChangeInfo.Size = new System.Drawing.Size(127, 23);
            this.MCNameChangeInfo.TabIndex = 7;
            this.MCNameChangeInfo.Text = "MCNameChangeInfo";
            this.MCNameChangeInfo.UseVisualStyleBackColor = true;
            this.MCNameChangeInfo.Click += new System.EventHandler(this.MCNameChangeInfo_Click);
            // 
            // DebugWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 445);
            this.Controls.Add(this.MCNameChangeInfo);
            this.Controls.Add(this.MCProfile);
            this.Controls.Add(this.MinecraftServicesAccessToken);
            this.Controls.Add(this.XboxLiveXSTSToken);
            this.Controls.Add(this.XboxLiveToken);
            this.Controls.Add(this.MSAuthToken);
            this.Controls.Add(this.ShowResponceTextBox);
            this.Controls.Add(this.MSAuthDevice);
            this.MinimumSize = new System.Drawing.Size(716, 150);
            this.Name = "DebugWindow";
            this.Text = "MojangAPI-GUI DebugForm";
            this.Load += new System.EventHandler(this.DebugWindow_Load);
            this.SizeChanged += new System.EventHandler(this.DebugWindow_SizeChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private Button MSAuthDevice;
        private RichTextBox ShowResponceTextBox;
        private Button MSAuthToken;
        private Button XboxLiveToken;
        private Button XboxLiveXSTSToken;
        private Button MinecraftServicesAccessToken;
        private Button MCProfile;
        private Button MCNameChangeInfo;
    }
}