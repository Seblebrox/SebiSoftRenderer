using System;

namespace SebiSoft.SoftwareRenderer
{
	public class Frustum
	{
		public double FOV { get; set; }

		public double width { get; set; }

		public double height { get; set; }

		public double nearPlane { get; set; }

		public double farPlane { get; set; }

		public Frustum ()
		{
		}
	}
}

