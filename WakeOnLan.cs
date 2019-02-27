using System.Net;
using System.Net.Sockets;
using System.Globalization;

namespace WOL
{
    public static class WakeOnLan
    {
        /// <summary>
        /// Broadcast the magic WOL message.
        /// </summary>
        /// <param name="MacAddress">MacAdress of the target (001100110011 format)</param>
        public static void Broadcast(string MacAddress, int Port = 9)
        {
            UdpClient Client = new UdpClient() { EnableBroadcast = true };
            Client.Connect(IPAddress.Broadcast, Port);

            int Counter = 0;
            byte[] Bytes = new byte[102];
            for (int x = 0; x < 6; x++) Bytes[Counter++] = 0xFF;

            for (int MacPackets = 0; MacPackets < 16; MacPackets++)
                for (int MacBytes = 0; MacBytes < 12; MacBytes += 2)
                    Bytes[Counter++] = byte.Parse(MacAddress.Substring(MacBytes, 2), NumberStyles.HexNumber);

            Client.Send(Bytes, Bytes.Length);
        }
    }
}
