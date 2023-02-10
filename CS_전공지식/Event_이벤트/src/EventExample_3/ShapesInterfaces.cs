
using System;
using System.Drawing;

namespace EventDrivenExample_6
{
    public interface IDrawingObject {
        //Raise this event before drawing
        event EventHandler OnDraw;
    }
    public interface IShape {
        //Raise this event after drawing
        event EventHandler OnDraw;
    }
}