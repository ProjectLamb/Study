using System;

using EventDrivenExample_3;

public class CustomEventArgs : EventArgs
{
	public CustomEventArgs(string _message) {
		Message = _message;
	}

	public string Message { get; set; }
}

