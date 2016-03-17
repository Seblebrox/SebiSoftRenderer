/// <summary>
/// RenderBuffer
/// Stellt ein Objekt zur Verfügung, mit dem sich direkt die Pixeldaten eines gebundenen Quell-Objekts (Bitmap)
/// manipulieren lassen. Dazu wird das Bitmap mit LockBits gesperrt und der direkte Zugriff auf die Daten ermöglicht.
/// Dies geht wesentlich schneller, als über die Funktion SetPixel auf einer Bitmap zu arbeiten.
/// 
/// Zukunftsmusik:
///   - bilineare, trilinieare Interpolationen
///   - Tiefenpuffer
///   - Post-Render-Effekte
///   - Clipping-Areas
/// </summary>
using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;


namespace SebiSoft.SoftwareRenderer
{

	unsafe public class RenderBuffer
	{
		int width;
		int height;
		bool locked;
		byte* lastBitmapPointer;

		Bitmap bitmap;
		BitmapData bitmapData;
		byte* bitmapPointer;
		PixelFormat bitmapPixelFormat;
		int bitmapBytePerPixel;
		int bitmapBufferSize;


		/// <summary>
		/// Gibt die Breite des Render-Buffers (in Pixeln) zurück.
		/// Die Breite ergibt sich aus dem gebundenen Quell-Objekt (Bitmap).
		/// </summary>
		/// <value>Die Breite</value>
		public int Width {
			get {
				return width;
			}
		}

		/// <summary>
		/// Gibt die Höhe des Render-Buffers (in Pixeln) zurück.
		/// Die Höhe ergibt sich aus dem gebundenen Quell-Objekt (Bitmap).
		/// </summary>
		/// <value>Die Höhe</value>
		public int Height {
			get {
				return height;
			}
		}

		public Bitmap Bmp {
			get {
				return bitmap;
			}
		}

		public bool Locked {
			get {
				return locked;
			}
		}

		/// <summary>
		/// Erzeugt ein Render-Buffer-Objekt und bindet es an eine übergebene Bitmap. Die Bitmap wird sofort gesperrt.
		/// </summary>
		/// <param name="bmp">Bitmap</param>
		public RenderBuffer(Bitmap bmp)
		{
			this.bitmap = bmp;
			width = bmp.Width;
			height = bmp.Height;
			Lock ();
		}


		/// <summary>
		/// Sperrt das gebundene Quell-Objekt (Bitmap) und kopiert den Inhalt der Bitmap in den Render-Buffer
		/// </summary>
		public void Lock() {
			if (!locked) {
				bitmapPixelFormat = PixelFormat.Format24bppRgb;
				Rectangle bmpRect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
				bitmapData = bitmap.LockBits (bmpRect, ImageLockMode.ReadWrite, bitmapPixelFormat);
				bitmapPointer = (byte*)bitmapData.Scan0.ToPointer();
				bitmapBytePerPixel = GetBitsPerPixel (bitmapPixelFormat)/8;
				bitmapBufferSize = bitmapData.Height * bitmapData.Stride;
				locked = true;
			}
		}

		/// <summary>
		/// Kopiert den Inhalte des Render-Buffers in das gebundene Quell-Objekt (Bitmap)
		/// und entsperrt die Bitmap.
		/// </summary>
		public void Unlock()
		{
			if (locked) {
				bitmap.UnlockBits (bitmapData);
				locked = false;
			}
		}



		/// <summary>
		/// Setzt einen Punkt im Render-Buffer OHNE Grenzen und ggf. vorhandene Clipping-Areas zu berücksichtigen
		/// </summary>
		/// <param name="x">x-Koordinate</param>
		/// <param name="y">y-Koordinate</param>
		/// <param name="col">Farbe (Color)</param>
		public void PutPixel(int x, int y, Color col)
		{
			Lock ();
			byte* data = bitmapPointer + y * bitmapData.Stride + x*bitmapBytePerPixel;
			data [0] = col.B;
			data [1] = col.G;
			data [2] = col.R;
			lastBitmapPointer = data;
		}

		public void PutNextPixel(Color col)
		{
			Lock ();
			lastBitmapPointer += 3;
			lastBitmapPointer [0] = col.B;
			lastBitmapPointer [1] = col.G;
			lastBitmapPointer [2] = col.R;
		}

		/// <summary>
		/// Setzt einen Punkt im Render-Buffer unter Berücksichtigung der Grenzen und ggf. vorhandener
		/// Clipping-Areas
		/// </summary>
		/// <param name="x">x-Koordinate</param>
		/// <param name="y">y-Koordinate</param>
		/// <param name="col">Farbe (Color)</param>
		public void DrawPixel(int x, int y, Color col) 
		{
			if (y<0 || y>height-1 || x<0 || x>width-1) {
				//TODO Fehlermeldung für falsche Koordinaten
				throw new ArgumentException ("sdfsdf");
			}
			PutPixel (x, y, col);
		}

		/// <summary>
		/// Löscht den Render-Buffer (Farbe Schwarz = 0)
		/// </summary>
		public void Clear()
		{
			Lock ();
			for (int i = 0; i < bitmapBufferSize; i++) {
				bitmapPointer [i] = 0;
			}
		}


		public void DrawLineEFLA(int x, int y, int x2, int y2, Color col) {

			bool yLonger = false;
			int incrementVal, endVal;

			int shortLen = y2 - y;
			int longLen = x2 - x;
			if (Math.Abs (shortLen) > Math.Abs (longLen)) {
				int swap = shortLen;
				shortLen = longLen;
				longLen = swap;
				yLonger = true;
			}

			endVal = longLen;
			if (longLen < 0) {
				incrementVal = -1;
				longLen = -longLen;
			} else
				incrementVal = 1;

			double decInc;
			if (longLen == 0)
				decInc = (double)shortLen;
			else
				decInc = ((double)shortLen / (double)longLen);
			double j = 0.0;
			if (yLonger) {
				for (int i = 0; i != endVal; i += incrementVal) {
					PutPixel (x + (int)j, y + i, col);
					j += decInc;
				}
			} else {
				for (int i = 0; i != endVal; i += incrementVal) {
					PutPixel (x + i, y + (int)j, col);
					j += decInc;
				}
			}
		}

		public void DrawLine(int x1, int y1, int x2, int y2, Color col)
		{
			int dx = Math.Abs (x2 - x1);
			int sx = x1<x2 ? 1 : -1;
			int dy = -Math.Abs (y2 - y1);
			int sy = y1<y2 ? 1 : -1;
			int err = dx + dy;
			int e2;

			while (true) {
				PutPixel(x1,y1,col);
				if (x1==x2 && y1==y2) break;
				e2 = err<<1;
				if (e2 > dy) { err += dy; x1 += sx; } /* e_xy+e_x > 0 */
				if (e2 < dx) { err += dx; y1 += sy; } /* e_xy+e_y < 0 */
			}

		}

		private byte GetBitsPerPixel(PixelFormat pixelFormat)
		{
			switch (pixelFormat)
			{
			case PixelFormat.Format24bppRgb:
				return 24;
			case PixelFormat.Format32bppArgb:
			case PixelFormat.Format32bppPArgb:
			case PixelFormat.Format32bppRgb:
				return 32;
			default:
				throw new ArgumentException("Only 24 and 32 bit images are supported");

			}
		}

	}





}

