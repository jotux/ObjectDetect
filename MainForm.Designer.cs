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
			this.filterBox = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.threshTrack = new System.Windows.Forms.TrackBar();
			this.label2 = new System.Windows.Forms.Label();
			this.minSizeTrack = new System.Windows.Forms.TrackBar();
			this.filterBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.threshTrack)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.minSizeTrack)).BeginInit();
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
			// filterBox
			// 
			this.filterBox.Controls.Add(this.label2);
			this.filterBox.Controls.Add(this.minSizeTrack);
			this.filterBox.Controls.Add(this.label1);
			this.filterBox.Controls.Add(this.threshTrack);
			this.filterBox.Location = new System.Drawing.Point(658, 40);
			this.filterBox.Name = "filterBox";
			this.filterBox.Size = new System.Drawing.Size(241, 188);
			this.filterBox.TabIndex = 13;
			this.filterBox.TabStop = false;
			this.filterBox.Text = "Filters";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(6, 20);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(59, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "Threshold:";
			// 
			// threshTrack
			// 
			this.threshTrack.Location = new System.Drawing.Point(65, 16);
			this.threshTrack.Maximum = 255;
			this.threshTrack.Minimum = 1;
			this.threshTrack.Name = "threshTrack";
			this.threshTrack.Size = new System.Drawing.Size(164, 45);
			this.threshTrack.TabIndex = 0;
			this.threshTrack.TickStyle = System.Windows.Forms.TickStyle.None;
			this.threshTrack.Value = 1;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(11, 46);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(59, 23);
			this.label2.TabIndex = 3;
			this.label2.Text = "Min Size:";
			// 
			// minSizeTrack
			// 
			this.minSizeTrack.Location = new System.Drawing.Point(66, 42);
			this.minSizeTrack.Maximum = 200;
			this.minSizeTrack.Minimum = 1;
			this.minSizeTrack.Name = "minSizeTrack";
			this.minSizeTrack.Size = new System.Drawing.Size(164, 45);
			this.minSizeTrack.TabIndex = 2;
			this.minSizeTrack.TickStyle = System.Windows.Forms.TickStyle.None;
			this.minSizeTrack.Value = 1;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(911, 540);
			this.Controls.Add(this.filterBox);
			this.Controls.Add(this.fpsText);
			this.Controls.Add(this.vidSettingsButton);
			this.Controls.Add(this.devicesCombo);
			this.Controls.Add(this.videoSourcePlayer);
			this.Name = "MainForm";
			this.Text = "test";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
			this.filterBox.ResumeLayout(false);
			this.filterBox.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.threshTrack)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.minSizeTrack)).EndInit();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.TrackBar minSizeTrack;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TrackBar threshTrack;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox filterBox;
		private System.Windows.Forms.Label fpsText;
		private System.Windows.Forms.Button vidSettingsButton;
		private System.Windows.Forms.ComboBox devicesCombo;
		private System.Windows.Forms.Timer fpsTimer;
		private AForge.Controls.VideoSourcePlayer videoSourcePlayer;
	}
}
