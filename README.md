# WakeOnLan
Example of how to send the magic WakeOnLan message with c#.
Usage: 
```cs
using WOL;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            //Mac = 00-14-22-01-23-45
            //So without the '-' char.
            WakeOnLan.Broadcast("001422012345");
        }
    }
}

```
