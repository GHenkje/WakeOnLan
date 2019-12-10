<p align="center">
  <b>WakeOnLan</b>
  <br/>
  <img src="https://img.shields.io/badge/License-WTFPL-blue.svg">
  <img src="https://img.shields.io/badge/version-1.0.0-blue.svg">
  <br/>
  <br/>
  <a>An example about how to send the magic wake on lan message with c#<a/>
</p>

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
	    WakeOnLan.Broadcast("00-14-22-01-23-45".Replace("-",""));
            WakeOnLan.Broadcast("001422012345");
        }
    }
}
```
