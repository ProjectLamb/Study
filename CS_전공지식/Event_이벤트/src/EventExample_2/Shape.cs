using System;
namespace EventDrivenExample_5
{
	public abstract class Shape
	{
		protected double mArea;

		public double Area {
			get => mArea;
			set => mArea = value;
		}

		public event EventHandler<ShapeEventArgs> ShapeChangedEvnet;

		public abstract void Draw();

		protected virtual void OnShapeChanged(ShapeEventArgs _e) {
			ShapeChangedEvnet?.Invoke(this, _e);
		}
	}

	public class Circle : Shape {
		private double mRadius;

		public Circle(double _radius) {
			this.mRadius = _radius;
			mArea = Math.PI * _radius * _radius;
		}

		public void Update(double _d) {
			this.mRadius = _d;
			mArea = Math.PI * mRadius * mRadius;
			OnShapeChanged(new ShapeEventArgs(mArea));
		}

		protected override void OnShapeChanged(ShapeEventArgs _e) { 
			// Call the base class event invocation method.
			base.OnShapeChanged(_e);
		}

        public override void Draw()
        {
			Console.WriteLine("Drawing a circle");
        }
    }

	public class Rectangle : Shape {
        private double mLength;
        private double mWidth;

		public Rectangle(double _length, double _width) {
			this.mLength = _length;
            this.mWidth = _width;
			mArea = mLength * mWidth;
        }

		public void Update(double _length, double _width)
        {
            this.mLength = _length;
            this.mWidth = _width;
            mArea = mLength * mWidth;
			OnShapeChanged(new ShapeEventArgs(mArea));
        }

        protected override void OnShapeChanged(ShapeEventArgs _e)
        {
            // Call the base class event invocation method.
            base.OnShapeChanged(_e);
        }

        public override void Draw()
        {
            Console.WriteLine("Drawing a ractangle");
        }
    }
}
