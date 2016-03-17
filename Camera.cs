using System;

namespace SebiSoft.SoftwareRenderer
{
	public class Camera
	{
		public Vector3 Position { get; set; }

		public Vector3 Orientation { get; set; }

		public Vector3 Up { get; set; }

		public Camera ()
		{
			this.Position = new Vector3 (0, 0, 0);
			this.Orientation = new Vector3 (1, 0, 0);
			this.Up = new Vector3 (0, 1, 0);
		}
	}
}

