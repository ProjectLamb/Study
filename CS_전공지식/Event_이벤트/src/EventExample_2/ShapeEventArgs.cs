using System;
namespace EventDrivenExample_5
{
	public class ShapeEventArgs : EventArgs
	{
		public ShapeEventArgs(double area) { NewArea = area; }
		public double NewArea { get; }
	}
}