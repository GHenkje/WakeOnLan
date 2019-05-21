# WakeOnLan
Example of how to send the magic wake on lan message with c#.
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
            //Remove the "-" chars
	    //WakeOnLan.Broadcast("00-14-22-01-23-45".Replace("-",""));
            WakeOnLan.Broadcast("001422012345");
        }
    }
}

```
