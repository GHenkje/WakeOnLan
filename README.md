# WakeOnLan
<p align="center">
  <img src="https://img.shields.io/badge/Do What The F*ck You Want To Public License-blue.svg">
  <img src="https://img.shields.io/badge/version-1.0.0-blue.svg">
  <br/>
  <br/>
  <a>Display images and play videos in a console window.<a/>
</p>
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
