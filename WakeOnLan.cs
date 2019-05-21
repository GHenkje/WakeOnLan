/* WakeOnLan
 * 
 *              DO WHAT THE FUCK YOU WANT TO PUBLIC LICENSE
 *                      Version 2, December 2004
 *
 * Copyright (C) 2019 henkje (henkje@pm.me)
 *
 * Everyone is permitted to copy and distribute verbatim or modified
 * copies of this license document, and changing it is allowed as long as the name is changed.
 *
 * DO WHAT THE FUCK YOU WANT TO PUBLIC LICENSE
 * TERMS AND CONDITIONS FOR COPYING, DISTRIBUTION AND MODIFICATION
 *
 * 0. You just DO WHAT THE FUCK YOU WANT TO.
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
        /// <param name="macAddress">MacAdress of the target (001100110011 format)</param>
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
