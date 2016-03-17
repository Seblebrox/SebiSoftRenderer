using System;
using System.Drawing;
using System.Windows.Forms;
using SebiSoft.SoftwareRenderer;

namespace SebiSoft
{
	public class TestApplication : Form

	{
		RenderBuffer rb;
		PictureBox pbx;
		private Timer tmr1;
		Bitmap bmp;

		Vector3 v1;
		Vector3 v2;
		Vector3 v3;
		Vector3 v4;
		double tx;
		double ty;
		double tz;
		double rx;
		double ry;
		double rz;

		int fpsCount;
		DateTime fpsBegin;
		DateTime fpsEnd;


		Boolean KEY_ESC_PRESSED = false;

		public TestApplication ()
		{
			v1 = new Vector3 (-10, 0, -10);
			v2 = new Vector3 (10, 0, -10);
			v3 = new Vector3 (0, 0, 10);
			v4 = new Vector3 (0, 20, 0);

			tx = 50.0f;
			ty = 40.0f;
			tz = 40.0f;
			rx = 0.0f;
			ry = 0.0f;
			rz = 0.0f;

			this.Width = 500;
			this.Height = 500;
			this.Text = "Hallo Welt";
			bmp = new Bitmap (500, 500);
			pbx = new PictureBox ();
			pbx.Dock = DockStyle.Fill;
			pbx.SizeMode = PictureBoxSizeMode.StretchImage;
			pbx.Image = bmp;
			Controls.Add (pbx);
			rb = new RenderBuffer (bmp);
			rb.Clear ();
			rb.Unlock();
			pbx.Invalidate ();

			tmr1 = new Timer ();
			tmr1.Interval = 1;
			tmr1.Enabled = true;
			tmr1.Tick += new System.EventHandler (this.tm1_Tick);
			this.KeyPress += new KeyPressEventHandler (this.MainForm_KeyPress);

		}

		public static void Main()
		{
			Application.Run (new TestApplication ());
		}

		private void tm1_Tick(object sender, System.EventArgs e)
		{
			//while (KEY_ESC_PRESSED==false) {
				if (fpsCount == 0) {
					fpsBegin = DateTime.Now;
				}
				fpsCount++;


				rx += 0.03; 
				if (rx > Math.PI * 2)
					rx -= (Math.PI * 2);
				ry += 0.03;
				if (ry > Math.PI * 2)
					ry -= (Math.PI * 2);
				rz += 0.03;
				if (rz > Math.PI * 2)
				rz -= (Math.PI * 2);

				Matrix4 tm = Matrix4.CreateRotationMatrix (rx, ry, rz) * 
				             Matrix4.CreateTranslationMatrix (tx, ty, tz) *
							 Matrix4.CreatePerspectiveMatrixFOV (Math.PI/1.5, 1, 20, 500);
				Vector3 tv1 = tm * v1;
				Vector3 tv2 = tm * v2;
				Vector3 tv3 = tm * v3;
				Vector3 tv4 = tm * v4;

				rb.Clear ();
				rb.DrawLine ((int)tv1.X, (int)tv1.Y, (int)tv2.X, (int)tv2.Y, Color.Red);
				rb.DrawLine ((int)tv2.X, (int)tv2.Y, (int)tv3.X, (int)tv3.Y, Color.Green);
				rb.DrawLine ((int)tv3.X, (int)tv3.Y, (int)tv1.X, (int)tv1.Y, Color.Blue);
				rb.DrawLine ((int)tv1.X, (int)tv1.Y, (int)tv4.X, (int)tv4.Y, Color.White);
				rb.DrawLine ((int)tv2.X, (int)tv2.Y, (int)tv4.X, (int)tv4.Y, Color.Coral);
				rb.DrawLine ((int)tv3.X, (int)tv3.Y, (int)tv4.X, (int)tv4.Y, Color.Chartreuse);
				rb.Unlock ();
				pbx.Refresh ();

				if (fpsCount==100) {
					fpsCount = 0;
					fpsEnd = DateTime.Now;
					double fps = 100.0f/(fpsEnd - fpsBegin).TotalSeconds;
					this.Text = "FPS: " + fps;
				}
			//}
		}

		private void MainForm_KeyPress(object sender, KeyPressEventArgs e)
		{

			KEY_ESC_PRESSED = (e.KeyChar == (char)Keys.Escape);
		}

	}
}

