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
				Bitmap img_copy = new Bitmap(image);
				Grayscale gray_filter = new Grayscale(0.2125, 0.7154, 0.0721);
				img_copy = gray_filter.Apply(img_copy);
				Threshold thresh = new Threshold(50);
				img_copy = thresh.Apply(img_copy);
				BlobCounter bc = new BlobCounter(img_copy);
				Rectangle[] rects = bc.GetObjectsRectangles();
				
				Graphics g = videoSourcePlayer.CreateGraphics();
				using (Pen p = new Pen(Color.Red))
				{
					foreach (Rectangle r in rects)
					{
						if (r.Width > 50 && r.Width < 100 && r.Height > 50 && r.Height < 100)
						{
							g.DrawRectangle(p,r);
						}
					}
				}
				
				image = img_copy;
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
