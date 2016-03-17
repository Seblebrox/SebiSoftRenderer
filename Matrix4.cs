using System;

namespace SebiSoft.SoftwareRenderer
{
	public struct Matrix4
	{
		
		#region Properties

		public double M11 { get; set; }

		public double M12 { get; set; }

		public double M13 { get; set; }

		public double M14 { get; set; }

		public double M21 { get; set; }

		public double M22 { get; set; }

		public double M23 { get; set; }

		public double M24 { get; set; }

		public double M31 { get; set; }

		public double M32 { get; set; }

		public double M33 { get; set; }

		public double M34 { get; set; }

		public double M41 { get; set; }

		public double M42 { get; set; }

		public double M43 { get; set; }

		public double M44 { get; set; }

		public double Determinant3 {
			get {
				return ((this.M11 * ((this.M22 * this.M33) - (this.M23 * this.M32))) -
				(this.M12 * ((this.M21 * this.M33) - (this.M23 * this.M31))) +
				(this.M13 * ((this.M21 * this.M32) - (this.M22 * this.M31))));
			}
		}

		#endregion


		#region Operators

		public static bool operator == (Matrix4 m1, Matrix4 m2)
		{
			return ((m1.M11 == m2.M11) && (m1.M12 == m2.M12) && (m1.M13 == m2.M13) && (m1.M14 == m2.M14) &&
			(m1.M21 == m2.M21) && (m1.M22 == m2.M22) && (m1.M23 == m2.M23) && (m1.M24 == m2.M24) &&
			(m1.M31 == m2.M31) && (m1.M32 == m2.M32) && (m1.M33 == m2.M33) && (m1.M34 == m2.M34) &&
			(m1.M41 == m2.M41) && (m1.M42 == m2.M42) && (m1.M43 == m2.M43) && (m1.M44 == m2.M44));
		}

		public static bool operator != (Matrix4 m1, Matrix4 m2)
		{
			return ((m1.M11 != m2.M11) || (m1.M12 != m2.M12) || (m1.M13 != m2.M13) || (m1.M14 != m2.M14) ||
			(m1.M21 != m2.M21) || (m1.M22 != m2.M22) || (m1.M23 != m2.M23) || (m1.M24 != m2.M24) ||
			(m1.M31 != m2.M31) || (m1.M32 != m2.M32) || (m1.M33 != m2.M33) || (m1.M34 != m2.M34) ||
			(m1.M41 != m2.M41) || (m1.M42 != m2.M42) || (m1.M43 != m2.M43) || (m1.M44 != m2.M44));
		}

		public static Matrix4 operator + (Matrix4 m1, Matrix4 m2)
		{
			return new Matrix4 (m1.M11 + m2.M11, m1.M12 + m2.M12, m1.M13 + m2.M13, m1.M14 + m2.M14,
				m1.M21 + m2.M21, m1.M22 + m2.M22, m1.M23 + m2.M23, m1.M24 + m2.M24,
				m1.M31 + m2.M31, m1.M32 + m2.M32, m1.M33 + m2.M33, m1.M34 + m2.M34,
				m1.M41 + m2.M41, m1.M42 + m2.M42, m1.M43 + m2.M43, m1.M44 + m2.M44);
		}

		public static Matrix4 operator - (Matrix4 m1, Matrix4 m2)
		{
			return new Matrix4 (m1.M11 - m2.M11, m1.M12 - m2.M12, m1.M13 - m2.M13, m1.M14 - m2.M14,
				m1.M21 - m2.M21, m1.M22 - m2.M22, m1.M23 - m2.M23, m1.M24 - m2.M24,
				m1.M31 - m2.M31, m1.M32 - m2.M32, m1.M33 - m2.M33, m1.M34 - m2.M34,
				m1.M41 - m2.M41, m1.M42 - m2.M42, m1.M43 - m2.M43, m1.M44 - m2.M44);
		}

		public static Matrix4 operator * (Matrix4 m1, Matrix4 m2)
		{
			return new Matrix4 (((m1.M11 * m2.M11) + (m1.M12 * m2.M21) + (m1.M13 * m2.M31) + (m1.M14 * m2.M41)),
				((m1.M11 * m2.M12) + (m1.M12 * m2.M22) + (m1.M13 * m2.M32) + (m1.M14 * m2.M42)),
				((m1.M11 * m2.M13) + (m1.M12 * m2.M23) + (m1.M13 * m2.M33) + (m1.M14 * m2.M43)),
				((m1.M11 * m2.M14) + (m1.M12 * m2.M24) + (m1.M13 * m2.M34) + (m1.M14 * m2.M44)),
				((m1.M21 * m2.M11) + (m1.M22 * m2.M21) + (m1.M23 * m2.M31) + (m1.M24 * m2.M41)),
				((m1.M21 * m2.M12) + (m1.M22 * m2.M22) + (m1.M23 * m2.M32) + (m1.M24 * m2.M42)),
				((m1.M21 * m2.M13) + (m1.M22 * m2.M23) + (m1.M23 * m2.M33) + (m1.M24 * m2.M43)),
				((m1.M21 * m2.M14) + (m1.M22 * m2.M24) + (m1.M23 * m2.M34) + (m1.M24 * m2.M44)),
				((m1.M31 * m2.M11) + (m1.M32 * m2.M21) + (m1.M33 * m2.M31) + (m1.M34 * m2.M41)),
				((m1.M31 * m2.M12) + (m1.M32 * m2.M22) + (m1.M33 * m2.M32) + (m1.M34 * m2.M42)),
				((m1.M31 * m2.M13) + (m1.M32 * m2.M23) + (m1.M33 * m2.M33) + (m1.M34 * m2.M43)),
				((m1.M31 * m2.M14) + (m1.M32 * m2.M24) + (m1.M33 * m2.M34) + (m1.M34 * m2.M44)),
				((m1.M41 * m2.M11) + (m1.M42 * m2.M21) + (m1.M43 * m2.M31) + (m1.M44 * m2.M41)),
				((m1.M41 * m2.M12) + (m1.M42 * m2.M22) + (m1.M43 * m2.M32) + (m1.M44 * m2.M42)),
				((m1.M41 * m2.M13) + (m1.M42 * m2.M23) + (m1.M43 * m2.M33) + (m1.M44 * m2.M43)),
				((m1.M41 * m2.M14) + (m1.M42 * m2.M24) + (m1.M43 * m2.M34) + (m1.M44 * m2.M44)));
		}

		public static Vector3 operator * (Matrix4 m1, Vector3 v1)
		{
			return new Vector3 ((v1.X * m1.M11) + (v1.Y * m1.M21) + (v1.Z * m1.M31) + m1.M41,
				(v1.X * m1.M12) + (v1.Y * m1.M22) + (v1.Z * m1.M32) + m1.M42,
				(v1.X * m1.M13) + (v1.Y * m1.M23) + (v1.Z * m1.M33) + m1.M43);
		}

		public static Matrix4 operator * (Matrix4 m1, double a)
		{
			return new Matrix4 (m1.M11 * a, m1.M12 * a, m1.M13 * a, m1.M14 * a,
				m1.M21 * a, m1.M22 * a, m1.M23 * a, m1.M24 * a,
				m1.M31 * a, m1.M32 * a, m1.M33 * a, m1.M34 * a,
				m1.M41 * a, m1.M42 * a, m1.M43 * a, m1.M44 * a);
		}

		#endregion


		#region Constructors

		/*		public Matrix4 ()
		{
			this.M11 = 0.0f;
			this.M12 = 0.0f;
			this.M13 = 0.0f;
			this.M14 = 0.0;
			this.M21 = 0.0f;
			this.M22 = 0.0f;
			this.M23 = 0.0f;
			this.M24 = 0.0;
			this.M31 = 0.0f;
			this.M32 = 0.0f;
			this.M33 = 0.0f;
			this.M34 = 0.0;
			this.M41 = 0.0f;
			this.M42 = 0.0f;
			this.M43 = 0.0f;
			this.M44 = 0.0;
		}
*/
		public Matrix4 (double m11, double m12, double m13, double m14, 
		                double m21, double m22, double m23, double m24,
		                double m31, double m32, double m33, double m34, 
		                double m41, double m42, double m43, double m44)
		{
			this.M11 = m11;
			this.M12 = m12;
			this.M13 = m13;
			this.M14 = m14;
			this.M21 = m21;
			this.M22 = m22;
			this.M23 = m23;
			this.M24 = m24;
			this.M31 = m31;
			this.M32 = m32;
			this.M33 = m33;
			this.M34 = m34;
			this.M41 = m41;
			this.M42 = m42;
			this.M43 = m43;
			this.M44 = m44;
		}

		public Matrix4 (Matrix4 m1)
		{
			this.M11 = m1.M11;
			this.M12 = m1.M12;
			this.M13 = m1.M13;
			this.M14 = m1.M14;
			this.M21 = m1.M21;
			this.M22 = m1.M22;
			this.M23 = m1.M23;
			this.M24 = m1.M24;
			this.M31 = m1.M31;
			this.M32 = m1.M32;
			this.M33 = m1.M33;
			this.M34 = m1.M34;
			this.M41 = m1.M41;
			this.M42 = m1.M42;
			this.M43 = m1.M43;
			this.M44 = m1.M44;
		}

		#endregion


		//GetHashCode, toString, compare, equals

		public static Matrix4 CreateIdentityMatrix ()
		{
			return new Matrix4 (1.0f, 0.0f, 0.0f, 0.0f,
				0.0f, 1.0f, 0.0f, 0.0f,
				0.0f, 0.0f, 1.0f, 0.0f,
				0.0f, 0.0f, 0.0f, 1.0f);
		}

		public static Matrix4 CreateTransformationMatrix ()
		{
			return new Matrix4 ();
		}

		public static Matrix4 CreateTranslationMatrix (double xTrans, double yTrans, double zTrans)
		{
			Matrix4 result = Matrix4.CreateIdentityMatrix ();
			result.M41 = xTrans;
			result.M42 = yTrans;
			result.M43 = zTrans;
			return result;
		}

		public static Matrix4 CreateRotationMatrix (double xAngle, double yAngle, double zAngle)
		{
			Matrix4 result = Matrix4.CreateIdentityMatrix ();
			double sx = Math.Sin (xAngle);
			double sy = Math.Sin (yAngle);
			double sz = Math.Sin (zAngle);
			double cx = Math.Cos (xAngle);
			double cy = Math.Cos (yAngle);
			double cz = Math.Cos (zAngle);

			result.M11 = cy * cz + sy * sx * sz; 
			result.M21 = -cy * sz + cz * sy * sx; 
			result.M31 = cx * sy;
			result.M12 = cx * sz; 
			result.M22 = cx * cz; 
			result.M32 = -sx;
			result.M13 = -cz * sy + cy * sx * sz; 
			result.M23 = sy * sz + cy * cz * sx; 
			result.M33 = cy * cx;

			return result;
		}



		public static Matrix4 CreatePerspectiveMatrixFOV (double FOV, double aspect, double nearPlaneDistance, double farPlaneDistance)
		{
			Matrix4 result = new Matrix4 ();
			/*if ((fieldOfView <= 0f) || (fieldOfView >= 3.141593f))
			{
				throw new ArgumentException("fieldOfView <= 0 O >= PI");
			}
			if (nearPlaneDistanceDistance <= 0f)
			{
				throw new ArgumentException("nearPlaneDistanceDistance <= 0");
			}
			if (farPlaneDistanceDistance <= 0f)
			{
				throw new ArgumentException("farPlaneDistanceDistance <= 0");
			}
			if (nearPlaneDistanceDistance >= farPlaneDistanceDistance)
			{
				throw new ArgumentException("nearPlaneDistanceDistance >= farPlaneDistanceDistance");
			}*/
			//https://de.wikipedia.org/wiki/Grafikpipeline
			double h = 1.0f / ((double)Math.Tan ((double)(FOV * 0.5f)));
			double w = h / aspect;
			result.M11 = w;
			result.M22 = h;
			result.M33 = farPlaneDistance / (nearPlaneDistance - farPlaneDistance);
			result.M43 = -1.0f;
			result.M34 = nearPlaneDistance * farPlaneDistance / (nearPlaneDistance - farPlaneDistance);
/*			double num = 1f / ((double) Math.Tan((double) (FOV * 0.5f)));
			double num9 = num / aspect;
			result.M11 = num9;
			result.M12 = result.M13 = result.M14 = 0f;
			result.M22 = num;
			result.M21 = result.M23 = result.M24 = 0f;
			result.M31 = result.M32 = 0f;
			result.M33 = farPlaneDistance / (nearPlaneDistance - farPlaneDistance);
			result.M34 = -1f;
			result.M41 = result.M42 = result.M44 = 0f;
			result.M43 = (nearPlaneDistance * farPlaneDistance) / (nearPlaneDistance - farPlaneDistance);*/
			return result;
		}


		public static Matrix4 CreateOrthogonalMatrix (double width, double height, double nearPlaneDistance, double farPlaneDistance)
		{
			Matrix4 result = new Matrix4 ();
			result.M11 = 2f / width;
			result.M12 = result.M13 = result.M14 = 0f;
			result.M22 = 2f / height;
			result.M21 = result.M23 = result.M24 = 0f;
			result.M33 = 1f / (nearPlaneDistance - farPlaneDistance);
			result.M31 = result.M32 = result.M34 = 0f;
			result.M41 = result.M42 = 0f;
			result.M43 = nearPlaneDistance / (nearPlaneDistance - farPlaneDistance);
			result.M44 = 1f;
			return result;
		}

		public static Matrix4 CreateWorldMatrix ()
		{
			return new Matrix4 ();

		}

		public static Matrix4 CreateCameraMatrix (Vector3 cameraPosition, Vector3 cameraTarget, Vector3 cameraUpVector)
		{
			Vector3 vector3_1 = Vector3.Normalize (cameraPosition - cameraTarget);
			Vector3 vector3_2 = Vector3.Normalize (Vector3.Cross (cameraUpVector, vector3_1));
			Vector3 vector1 = Vector3.Cross (vector3_1, vector3_2);
			Matrix4 result = new Matrix4 ();
			result.M11 = vector3_2.X;
			result.M12 = vector1.X;
			result.M13 = vector3_1.X;
			result.M14 = 0.0f;
			result.M21 = vector3_2.Y;
			result.M22 = vector1.Y;
			result.M23 = vector3_1.Y;
			result.M24 = 0.0f;
			result.M31 = vector3_2.Z;
			result.M32 = vector1.Z;
			result.M33 = vector3_1.Z;
			result.M34 = 0.0f;
			result.M41 = -Vector3.Dot (vector3_2, cameraPosition);
			result.M42 = -Vector3.Dot (vector1, cameraPosition);
			result.M43 = -Vector3.Dot (vector3_1, cameraPosition);
			result.M44 = 1f;
			return result;		
		}

		public static Matrix4 CreateScaleMatrix ()
		{
			return new Matrix4 ();

		}

		//public static Matrix4 Multiply
		//public static Matrix4 Add
		//public static Matrix4 Subtract
		//Divide

		//Set

		//Determinant4 property

		//Perspective,PerspectiveFOV
	}
}

