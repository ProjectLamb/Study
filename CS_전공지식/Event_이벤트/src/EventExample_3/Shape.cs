using System;
namespace EventDrivenExample_6
{
	public class Shape : IDrawingObject, IShape{
		event EventHandler preDrawEvent;
		event EventHandler postDrawEvent;

		object objectLock = new Object();

		#region IDrawingObjectOnDraw
		// Explicit interface implementation required.
        // Associate IDrawingObject's event with
        // PreDrawEvent
		event EventHandler IDrawingObject.OnDraw {
			add {
				lock(objectLock) {preDrawEvent += value;}
			}
			remove {
				lock(objectLock) {preDrawEvent -= value;}
			}
		}
		#endregion
		// Explicit interface implementation required.
        // Associate IShape's event with
        // PostDrawEvent
		event EventHandler IShape.OnDraw {
			add {
				lock(objectLock) {postDrawEvent += value;}
			}
			remove {
				lock(objectLock) {postDrawEvent -= value;}
			}
		}
		
		// For the sake of simplicity this one method
        // implements both interfaces.

		public void Draw(){
			preDrawEvent?.Invoke(this, EventArgs.Empty);
			Console.WriteLine("Drawing a shape.");
			postDrawEvent?.Invoke(this, EventArgs.Empty);
		}
	}
}
