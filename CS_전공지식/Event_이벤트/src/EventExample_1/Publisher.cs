using System;
namespace EventDrivenExample_3;

class Publisher
{
    //이벤트 변수
    public event EventHandler<CustomEventArgs> RaiseCustomEvent;

    public void DoSomething() {
        EmitCustomEvent(new CustomEventArgs("Event triggered"));
    }
    protected virtual void EmitCustomEvent(CustomEventArgs e) { 
        //동기화 문제로 (Race Condition) 꼭 이벤트에대한 Temporary 이벤트 변수를 만들어야 한다.
        //그리고 null 체크를 통해 핸들러가 있는지 확인한. 
        EventHandler<CustomEventArgs> raiseEvent = RaiseCustomEvent;

        // Event will be null if there are no subscribers
        if (raiseEvent != null)
        {
            e.Message += $" at {DateTime.Now}";
            raiseEvent(this, e); // Call to raise the event.
        }
    }
}