using System;
using System.Text;



namespace SebiSoft.SoftwareRenderer
{
	public struct Vector3 : IEquatable<Vector3>, IComparable<Vector3>
	{

		#region Properties

		public double X { get; set; }

		public double Y { get; set; }

		public double Z { get; set; }

		public double Length {
			get {
				return Math.Sqrt (this.X * this.X) + (this.Y * this.Y) + (this.Z * this.Z);
			}
		}

		public double LengthSquare {
			get {
				return (this.X * this.X) + (this.Y * this.Y) + (this.Z * this.Z);
			}
		}

		#endregion


		#region Constructors

		/*		public Vector3 ()
		{
			this.X = 0.0f;
			this.Y = 0.0f;
			this.Z = 0.0f;
		}
*/
		public Vector3 (double v)
		{
			this.X = v;
			this.Y = v;
			this.Z = v;
		}

		public Vector3 (double x, double y, double z)
		{
			this.X = x;
			this.Y = y;
			this.Z = z;
		}

		public Vector3 (Vector3 v1)
		{ 
			this.X = v1.X;
			this.Y = v1.Y;
			this.Z = v1.Z;
		}

		#endregion


		#region Operators

		public static bool operator == (Vector3 v1, Vector3 v2)
		{
			return (v1.X == v2.X && v1.Y == v2.Y && v1.Z == v2.Z);
		}

		public static bool operator != (Vector3 v1, Vector3 v2)
		{
			return (v1.X != v2.X || v1.Y != v2.Y || v1.Z != v2.Z);
		}

		public static Vector3 operator + (Vector3 v1, Vector3 v2)
		{
			return new Vector3 (v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);
		}

		public static Vector3 operator - (Vector3 v1, Vector3 v2)
		{
			return new Vector3 (v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);
		}

		public static Vector3 operator * (Vector3 v1, double a)
		{
			return new Vector3 (v1.X * a, v1.Y * a, v1.Z * a);
		}

		public static Vector3 operator / (Vector3 v1, double a)
		{
			return new Vector3 (v1.X / a, v1.Y / a, v1.Z / a);
		}

		#endregion


		#region Static Methods

		public static double Angle (Vector3 v1, Vector3 v2)
		{
			return Math.Acos (v1.Dot (v2) / (v1.Length * v2.Length));
		}

		public static Vector3 Cross (Vector3 v1, Vector3 v2)
		{
			return new Vector3 (
				(v1.Y * v2.Z) - (v1.Z * v2.Y),
				(v1.Z * v2.X) - (v1.X * v2.Z),
				(v1.X * v2.Y) - (v1.Y * v2.X)
			);
		}

		public static double Distance (Vector3 v1, Vector3 v2)
		{
			return (v2 - v1).Length;
		}

		public static double Dot (Vector3 v1, Vector3 v2)
		{
			return (v1.X * v2.X) + (v1.Y * v2.Y) + (v1.Z * v2.Z);
		}

		public static Vector3 Lerp (Vector3 v1, Vector3 v2, double ratio)
		{
			return new Vector3 (
				v1.X + (v2.X - v1.X) * ratio,
				v1.Y + (v2.Y - v1.Y) * ratio,
				v1.Z + (v2.Z - v1.Z) * ratio);
		}

		public static Vector3 Min (Vector3 v1, Vector3 v2)
		{
			return new Vector3 (
				Math.Min (v1.X, v2.X),
				Math.Min (v1.Y, v2.Y),
				Math.Min (v1.Z, v2.Z));
		}

		public static Vector3 Max (Vector3 v1, Vector3 v2)
		{
			return new Vector3 (
				Math.Max (v1.X, v2.X),
				Math.Max (v1.Y, v2.Y),
				Math.Max (v1.Z, v2.Z));
		}

		public static Vector3 NLerp (Vector3 v1, Vector3 v2, double ratio)
		{
			return Vector3.Normalize (
				new Vector3 (
					v1.X + (v2.X - v1.X) * ratio,
					v1.Y + (v2.Y - v1.Y) * ratio,
					v1.Z + (v2.Z - v1.Z) * ratio));
		}

		public static Vector3 Normalize (Vector3 v1)
		{
			double length = v1.Length;
			return new Vector3 (v1.X / length, v1.Y / length, v1.Z / length);
		}

		public static Vector3 Slerp (Vector3 v1, Vector3 v2, float ratio)
		{
			double dot = Vector3.Dot (v1, v2);     
			MathHelper.Clamp (dot, -1.0f, 1.0f);
			double theta = Math.Acos (dot) * ratio;
			Vector3 relVec = v2 - v1 * dot;
			relVec.Normalize ();  
			return ((v1 * Math.Cos (theta)) + (relVec * Math.Sin (theta)));
		}

		#endregion


		#region Instance methods

		public void Add (Vector3 v1)
		{
			this.X += v1.X;
			this.Y += v1.Y;
			this.Z += v1.Z;
		}

		public double Angle (Vector3 v1)
		{
			return Math.Acos (Dot (v1) / (Length * v1.Length));
		}

		public int CompareTo (Vector3 v1)
		{
			double length = this.Length;
			double v1length = v1.Length;

			if (length == v1length)
				return 0;
			if (length > v1length)
				return 1;
			return -1;
		}

		public Vector3 Cross (Vector3 v1)
		{
			return new Vector3 (
				(this.Y * v1.Z) - (this.Z * v1.Y),
				(this.Z * v1.X) - (this.X * v1.Z),
				(this.X * v1.Y) - (this.Y * v1.X)
			);
		}

		public double Distance (Vector3 v1)
		{
			return (v1 - this).Length;
		}

		public void Divide (double a)
		{
			this.X /= a;
			this.Y /= a;
			this.Z /= a;
		}

		public double Dot (Vector3 v1)
		{
			return (this.X * v1.X) + (this.Y * v1.Y) + (this.Z * v1.Z);
		}

		public override bool Equals (object o)
		{
			return (o is Vector3) ? this == (Vector3)o : false;
		}

		public bool Equals (Vector3 v1)
		{
			return (this.X == v1.X && this.Y == v1.Y && this.Z == v1.Z);
		}

		public override int GetHashCode ()
		{
			return (int)(this.X.GetHashCode () + this.Y.GetHashCode () + this.Z.GetHashCode ());
		}

		public void Lerp (Vector3 v1, double ratio)
		{
			this.X += (v1.X - this.X) * ratio;
			this.Y += (v1.Y - this.Y) * ratio;
			this.Z += (v1.Z - this.Z) * ratio;
		}

		public void Multiply (double a)
		{
			this.X *= a;
			this.Y *= a;
			this.Z *= a;			
		}

		public void NLerp (Vector3 v1, double ratio)
		{
			this.X += (v1.X - this.X) * ratio;
			this.Y += (v1.Y - this.Y) * ratio;
			this.Z += (v1.Z - this.Z) * ratio;
			this.Normalize ();
		}

		public void Normalize ()
		{
			double length = this.Length;
			this.X /= length;
			this.Y /= length;
			this.Z /= length;
		}

		public void Set (double x, double y, double z)
		{
			this.X = x;
			this.Y = y;
			this.Z = z;
		}

		public void Set (Vector3 v1)
		{ 
			this.X = v1.X;
			this.Y = v1.Y; 
			this.Z = v1.Z;
		}

		public void Subtract (Vector3 v1)
		{
			this.X -= v1.X;
			this.Y -= v1.Y;
			this.Z -= v1.Z;
		}

		public override string ToString ()
		{
			StringBuilder sb = new StringBuilder ();
			sb.Append ("{x=");
			sb.Append (this.X);
			sb.Append (" y=");
			sb.Append (this.Y);
			sb.Append (" z=");
			sb.Append (this.Z);
			sb.Append ("}");
			return sb.ToString ();
		}

		#endregion

	}
}

