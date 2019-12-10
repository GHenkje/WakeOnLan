/* WakeOnLan
 * This program is free software. It comes without any warranty, to
 * the extent permitted by applicable law. You can redistribute it
 * and/or modify it under the terms of the Do What The Fuck You Want
 * To Public License, Version 2.
 */

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
        /// <param name="macAddress">MacAdress of the target (format: 001100110011 (The macAdress without all the ':' chars))</param>
        public static void Broadcast(string macAddress, int port = 9)
        {
            UdpClient client = new UdpClient() { EnableBroadcast = true };
            client.Connect(IPAddress.Broadcast, port);

            int counter = 0;
            byte[] bytes = new byte[102];

            for (int x = 0; x < 6; x++)
                bytes[counter++] = 0xFF;

            for (int macPackets = 0; macPackets < 16; macPackets++)
                for (int macBytes = 0; macBytes < 12; macBytes += 2)
                    bytes[counter++] = byte.Parse(macAddress.Substring(macBytes, 2), NumberStyles.HexNumber);

            client.Send(bytes, bytes.Length);
        }
    }
}
