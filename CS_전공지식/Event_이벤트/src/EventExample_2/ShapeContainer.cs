using System;
namespace EventDrivenExample_5
{
	public class ShapeContainer
	{
		private readonly List<Shape> mList;
		public ShapeContainer()
		{
			mList = new List<Shape>();
		}

		public void AddShape(Shape _shape) {
			mList.Add(_shape);
            // Subscribe to the base class event.
            _shape.ShapeChangedEvnet += HandleShapeChanged;
        }

		private void HandleShapeChanged(object _sender, ShapeEventArgs _e) {
			if (_sender is Shape shape) {
				Console.WriteLine($"Received event. Shape area is now {_e.NewArea}");

				shape.Draw();
			}
		}
	}
}

