using System;

namespace SebiSoft.SoftwareRenderer 
{
	public static class MathHelper
	{
		public const double DoubleTolerance= 0.0000001f;

		static MathHelper ()
		{
		}

		static public bool Equals(double d1, double d2)
		{
			return ((d1-d2) <= DoubleTolerance);
		}

		public static double Clamp(double v, double min, double max)
		{
			v = (v > max) ? max : v;
			v = (v < min) ? min : v;
			return v;
		}
	}
}

