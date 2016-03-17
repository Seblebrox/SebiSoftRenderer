using System;
using System.Text;



namespace SebiSoft.SoftwareRenderer 
{
	public class Vector2 : IEquatable<Vector2>, IComparable<Vector2>
	{

		#region Properties
		public double X { get; set; }
		public double Y { get; set; }
		public double Length {
			get {
				return Math.Sqrt(this.X * this.X) + (this.Y * this.Y);
			}
		}
		public double LengthSquare {
			get {
				return (this.X * this.X) + (this.Y * this.Y);
			}
		}
		#endregion


		#region Constructors
		public Vector2()
		{
			this.X = 0.0f;
			this.Y = 0.0f;
		}

		public Vector2(double v)
		{
			this.X = v;
			this.Y = v;
		}

		public Vector2(double x,double y)
		{
			this.X = x;
			this.Y = y;
		}

		public Vector2(Vector2 v1)
		{ 
			this.X = v1.X;
			this.Y = v1.Y;
		}
		#endregion


		#region Operators
		public static bool operator == (Vector2 v1, Vector2 v2)
		{
			return (v1.X == v2.X && v1.Y == v2.Y);
		}

		public static bool operator != (Vector2 v1, Vector2 v2) 
		{
			return (v1.X != v2.X || v1.Y != v2.Y);
		}

		public static Vector2 operator + (Vector2 v1, Vector2 v2) 
		{
			return new Vector2 (v1.X + v2.X, v1.Y + v2.Y);
		}

		public static Vector2 operator - (Vector2 v1, Vector2 v2) 
		{
			return new Vector2 (v1.X - v2.X, v1.Y - v2.Y);
		}

		public static Vector2 operator * (Vector2 v1, double a) 
		{
			return new Vector2 (v1.X * a, v1.Y * a);
		}

		public static Vector2 operator / (Vector2 v1, double a) 
		{
			return new Vector2 (v1.X / a, v1.Y / a);
		}
		#endregion


		#region Static Methods
		public static double Angle(Vector2 v1, Vector2 v2)
		{
			return Math.Acos (v1.Dot (v2) / (v1.Length * v2.Length));
		}

		public static double Cross(Vector2 v1, Vector2 v2)
		{
			return (v1.X * v2.Y) - (v1.Y * v2.X);
		}

		public static double Distance(Vector2 v1, Vector2 v2) 
		{
			return (v2 - v1).Length;
		}

		public static double Dot(Vector2 v1, Vector2 v2)
		{
			return (v1.X * v2.X) + (v1.Y * v2.Y);
		}

		public static Vector2 Lerp(Vector2 v1, Vector2 v2, double ratio)
		{
			return new Vector2 (
				v1.X + (v2.X - v1.X) * ratio,
				v1.Y + (v2.Y - v1.Y) * ratio);
		}

		public static Vector2 Min(Vector2 v1, Vector2 v2)
		{
			return new Vector2 (
				Math.Min (v1.X, v2.X),
				Math.Min (v1.Y, v2.Y));
		}

		public static Vector2 Max(Vector2 v1, Vector2 v2)
		{
			return new Vector2 (
				Math.Max (v1.X, v2.X),
				Math.Max (v1.Y, v2.Y));
		}

		public static Vector2 NLerp(Vector2 v1, Vector2 v2, double ratio)
		{
			return Vector2.Normalize (
				new Vector2 (
					v1.X + (v2.X - v1.X) * ratio,
					v1.Y + (v2.Y - v1.Y) * ratio));
		}

		public static Vector2 Normalize(Vector2 v1)
		{
			double length = v1.Length;
			return new Vector2 (v1.X / length, v1.Y / length);
		}

		public static Vector2 Slerp(Vector2 v1, Vector2 v2, float ratio)
		{
			double dot = Vector2.Dot(v1, v2);     
			MathHelper.Clamp(dot, -1.0f, 1.0f);
			double theta = Math.Acos(dot)*ratio;
			Vector2 relVec = v2 - v1*dot;
			relVec.Normalize();  
			return ((v1*Math.Cos(theta)) + (relVec*Math.Sin(theta)));
		}
		#endregion


		#region Instance methods
		public void Add(Vector2 v1)
		{
			this.X += v1.X;
			this.Y += v1.Y;
		}

		public double Angle(Vector2 v1)
		{
			return Math.Acos (Dot (v1) / (Length * v1.Length));
		}

		public int CompareTo(Vector2 v1)
		{
			double length = this.Length;
			double v1length = v1.Length;

			if (length == v1length)
				return 0;
			if (length > v1length)
				return 1;
			return -1;
		}

		public double Cross(Vector2 v1) 
		{
			return  (this.X * v1.Y) - (this.Y * v1.X);
		}

		public double Distance(Vector2 v1)
		{
			return (v1 - this).Length;
		}

		public void Divide(double a)
		{
			this.X /= a;
			this.Y /= a;
		}

		public double Dot(Vector2 v1) 
		{
			return (this.X * v1.X) + (this.Y * v1.Y);
		}

		public override bool Equals(object o)
		{
			return (o is Vector2) ? this == (Vector2)o : false;
		}

		public bool Equals(Vector2 v1) 
		{
			return (this.X == v1.X && this.Y == v1.Y);
		}

		public override int GetHashCode()
		{
			return (int)(this.X.GetHashCode() + this.Y.GetHashCode());
		}

		public void Lerp(Vector2 v1, double ratio)
		{
			this.X += (v1.X - this.X) * ratio;
			this.Y += (v1.Y - this.Y) * ratio;
		}

		public void Multiply (double a)
		{
			this.X *= a;
			this.Y *= a;
		}

		public void NLerp(Vector2 v1, double ratio)
		{
			this.X += (v1.X - this.X) * ratio;
			this.Y += (v1.Y - this.Y) * ratio;
			this.Normalize ();
		}

		public void Normalize()
		{
			double length = this.Length;
			this.X /= length;
			this.Y /= length;
		}

		public void Set(double x,double y) 
		{
			this.X = x;
			this.Y = y;
		}

		public void Set(Vector2 v1) 
		{ 
			this.X = v1.X;
			this.Y = v1.Y; 
		}

		public void Subtract(Vector2 v1)
		{
			this.X -= v1.X;
			this.Y -= v1.Y;
		}

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("{x=");
			sb.Append(this.X);
			sb.Append(" y=");
			sb.Append(this.Y);
			sb.Append("}");
			return sb.ToString();
		}
		#endregion

	}
}

