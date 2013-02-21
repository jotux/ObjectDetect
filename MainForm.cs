/*
 * Created by SharpDevelop.
 * User: jotux
 * Date: 2/17/2013
 * Time: 8:27 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Threading;

using AForge;
using AForge.Imaging;
using AForge.Video;
using AForge.Video.VFW;
using AForge.Video.DirectShow;
using AForge.Vision;
using AForge.Imaging.Filters;

namespace test
{
	
	public partial class MainForm : Form
	{
		FilterInfoCollection videoDevices;
		private IVideoSource videoSource = null;
		
		public MainForm()
		{
			InitializeComponent();

			try
			{
                // enumerate video devices
                videoDevices = new FilterInfoCollection( FilterCategory.VideoInputDevice );

                if ( videoDevices.Count == 0 )
                    throw new ApplicationException( );

                devicesCombo.Items.Add("Select Source...");
                // add all devices to combo
                foreach ( FilterInfo device in videoDevices )
                {
                    devicesCombo.Items.Add( device.Name );
                }
            }
            catch ( ApplicationException )
            {
                devicesCombo.Items.Add( "No local capture devices" );
                devicesCombo.Enabled = false;
            }

            devicesCombo.SelectedIndex = 0;
		}
		
		private void OpenVideoSource( IVideoSource source )
        {
            this.Cursor = Cursors.WaitCursor;
            videoSourcePlayer.VideoSource = new AsyncVideoSource( source );
            videoSourcePlayer.Start( );
            fpsTimer.Start();
            videoSource = source;
            this.Cursor = Cursors.Default;
        }
		       
		private void CloseVideoSource( )
        {
            this.Cursor = Cursors.WaitCursor;
            videoSourcePlayer.SignalToStop( );

            for ( int i = 0; ( i < 50 ) && ( videoSourcePlayer.IsRunning ); i++ )
            {
                Thread.Sleep( 100 );
            }

            if ( videoSourcePlayer.IsRunning )
            {
                videoSourcePlayer.Stop( );
            }

            fpsTimer.Stop( );
            videoSourcePlayer.BorderColor = Color.Black;
            this.Cursor = Cursors.Default;
        }
		
		void FpsTimerTick(object sender, EventArgs e)
		{
            IVideoSource videoSource = videoSourcePlayer.VideoSource;
            if (videoSource != null)
            {
            	fpsText.Text = "FPS:" + videoSource.FramesReceived.ToString();
            }
		}
		
		void MainFormFormClosing(object sender, FormClosingEventArgs e)
		{
			CloseVideoSource();
		}
		
		void VideoSourcePlayerNewFrame(object sender, ref Bitmap image)
		{
			lock (this)
			{
				// process here
			}
		}
		
		void DevicesComboSelectedIndexChanged(object sender, EventArgs e)
		{
			if (devicesCombo.SelectedIndex == 0)
			{
				CloseVideoSource();
				fpsText.Visible = false;
				vidSettingsButton.Enabled = false;
			}
			else
            {				
				fpsText.Visible = true;
				vidSettingsButton.Enabled = true;
				VideoCaptureDevice videoSource = new VideoCaptureDevice(videoDevices[devicesCombo.SelectedIndex - 1].MonikerString);
                OpenVideoSource( videoSource );
            }
			
		}
		
		void VidSettingsButtonClick(object sender, EventArgs e)
		{
            if ( ( videoSource != null ) && ( videoSource is VideoCaptureDevice ) )
            {
                try
                {
                    ( (VideoCaptureDevice) videoSource ).DisplayPropertyPage( this.Handle );
                }
                catch ( NotSupportedException ex )
                {
                    MessageBox.Show( ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
                }
            }			
		}
	}
}
