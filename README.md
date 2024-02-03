# SharpTimer
A simple Timer system for C# game applications. 

## Features
Sharp timer is a simple foundation for timers in C# applications. The simplicity of the system allows for easy integration with different systems and applications. While this system has been created for game engines, it is not exclusive to this use-case.

## Usage
To use this system, it is recommended to create an ITimer field on a controller class. Then construct the explicit implementation you need. All you have to do next is update your timer with the delta time of your application. Once you have done that, there are several builder methods that can help you set up your timer further. 

Below is an example of a Unity MonoBehaviour that uses the DurationTimer implementation.

```csharp
public class TimerController : MonoBehaviour
{
    private ITimer _timer;

    private void Start()
    {
        // Create a new timer with a duration of 60 seconds
        _timer = new DurationTimer(60)
            .AddCompleteListener(OnComplete)
            .Start();
    }

    private void Update()
    {
        _timer.Update(Time.deltaTime);
    }
    
    private void OnComplete()
    {
        Debug.Log("Timer Complete");
    }
}
```

## Important Notes
Additionally, you don't have to use the builder methods. You can create your own implementation of the ITimer interface or the TimerBase and use that instead. 
Also, you don't have to use delta time to update the timer. You can use any time system you want. Simple incrementation to a value will work just as well.

