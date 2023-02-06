using System;
using System.Security.Cryptography;

using EventDrivenExample_3;

class Subscriber
{
    private readonly string mId;

    public Subscriber(string _id, Publisher _pub) {
        mId = _id;
        _pub.RaiseCustomEvent += HandleCustomEvent;
    }

    void HandleCustomEvent(Object sender, CustomEventArgs e) {
        Console.WriteLine($"{mId} received this message: {e.Message}");
    }
}