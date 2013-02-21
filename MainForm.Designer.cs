/*
 * Created by SharpDevelop.
 * User: jotux
 * Date: 2/17/2013
 * Time: 8:27 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace test
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.videoSourcePlayer = new AForge.Controls.VideoSourcePlayer();
			this.fpsTimer = new System.Windows.Forms.Timer(this.components);
			this.devicesCombo = new System.Windows.Forms.ComboBox();
			this.vidSettingsButton = new System.Windows.Forms.Button();
			this.fpsText = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// videoSourcePlayer
			// 
			this.videoSourcePlayer.Location = new System.Drawing.Point(12, 40);
			this.videoSourcePlayer.Name = "videoSourcePlayer";
			this.videoSourcePlayer.Size = new System.Drawing.Size(640, 480);
			this.videoSourcePlayer.TabIndex = 0;
			this.videoSourcePlayer.Text = "videoSourcePlayer1";
			this.videoSourcePlayer.VideoSource = null;
			this.videoSourcePlayer.NewFrame += new AForge.Controls.VideoSourcePlayer.NewFrameHandler(this.VideoSourcePlayerNewFrame);
			// 
			// fpsTimer
			// 
			this.fpsTimer.Interval = 1000;
			this.fpsTimer.Tick += new System.EventHandler(this.FpsTimerTick);
			// 
			// devicesCombo
			// 
			this.devicesCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.devicesCombo.FormattingEnabled = true;
			this.devicesCombo.Location = new System.Drawing.Point(12, 12);
			this.devicesCombo.Name = "devicesCombo";
			this.devicesCombo.Size = new System.Drawing.Size(250, 21);
			this.devicesCombo.TabIndex = 10;
			this.devicesCombo.SelectedIndexChanged += new System.EventHandler(this.DevicesComboSelectedIndexChanged);
			// 
			// vidSettingsButton
			// 
			this.vidSettingsButton.Location = new System.Drawing.Point(271, 11);
			this.vidSettingsButton.Name = "vidSettingsButton";
			this.vidSettingsButton.Size = new System.Drawing.Size(75, 23);
			this.vidSettingsButton.TabIndex = 11;
			this.vidSettingsButton.Text = "Settings";
			this.vidSettingsButton.UseVisualStyleBackColor = true;
			this.vidSettingsButton.Click += new System.EventHandler(this.VidSettingsButtonClick);
			// 
			// fpsText
			// 
			this.fpsText.BackColor = System.Drawing.SystemColors.Control;
			this.fpsText.ForeColor = System.Drawing.SystemColors.ControlText;
			this.fpsText.Location = new System.Drawing.Point(592, 523);
			this.fpsText.Name = "fpsText";
			this.fpsText.Size = new System.Drawing.Size(60, 15);
			this.fpsText.TabIndex = 12;
			this.fpsText.Text = "FPS:";
			this.fpsText.Visible = false;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(665, 540);
			this.Controls.Add(this.fpsText);
			this.Controls.Add(this.vidSettingsButton);
			this.Controls.Add(this.devicesCombo);
			this.Controls.Add(this.videoSourcePlayer);
			this.Name = "MainForm";
			this.Text = "test";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Label fpsText;
		private System.Windows.Forms.Button vidSettingsButton;
		private System.Windows.Forms.ComboBox devicesCombo;
		private System.Windows.Forms.Timer fpsTimer;
		private AForge.Controls.VideoSourcePlayer videoSourcePlayer;
	}
}
