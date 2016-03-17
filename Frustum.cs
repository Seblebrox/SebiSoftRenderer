using System;

namespace SebiSoft.SoftwareRenderer
{
	public class Frustum
	{

		double fov;
		double aspect;
		double width;
		double height;
		double nearPlaneDistance;
		double farPlaneDistance;

		public double FOV { 
			get {
				return this.fov;
			}
			set {
				this.fov = value;
				ComputeWidthHeight ();
			}
		}

		public double Width { 
			get {
				return this.width;
			}
			set {
				this.width = value;
				this.height = this.width * this.aspect;
				ComputeFOV ();
			} 
		}

		public double Height { 
			get {
				return this.height;
			}
			set {
				this.height = value;
				this.width = this.height / this.aspect;
				ComputeFOV ();
			} 
		}

		public double Aspect {
			get {
				return this.aspect;
			}
			set {
				this.height = this.width * this.aspect;
			}
		}

		public double NearPlaneDistance {
			get {
				return this.nearPlaneDistance;
			} 
			set {
				this.nearPlaneDistance = value;
				ComputeWidthHeight ();
			} 
		}

		public double FarPlaneDistance { get; set; }


		private void ComputeWidthHeight ()
		{
			this.height = Math.Tan (fov) * this.nearPlaneDistance;
			this.width = this.height * this.aspect;
		}

		private void ComputeFOV ()
		{
			this.fov = Math.Atan (this.height / this.nearPlaneDistance);
		}

		public Frustum ()
		{
			this.fov = Math.PI / 3;
			this.aspect = 1.0;
			this.NearPlaneDistance = 50;
			this.FarPlaneDistance = 5000;
		}
	}
}

