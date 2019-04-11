/* WakeOnLan
 * Copyright (C) 2019  henkje (henkje@pm.me)
 * 
 * MIT license
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
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
        /// <param name="MacAddress">MacAdress of the target (001100110011 format)</param>
        public static void Broadcast(string macAddress, int port = 9)
        {
            UdpClient client = new UdpClient() { EnableBroadcast = true };
            client.Connect(IPAddress.Broadcast, port);

            int counter = 0;
            byte[] bytes = new byte[102];
            for (int x = 0; x < 6; x++) bytes[counter++] = 0xFF;

            for (int macPackets = 0; macPackets < 16; macPackets++)
                for (int macBytes = 0; macBytes < 12; macBytes += 2)
                    bytes[counter++] = byte.Parse(macAddress.Substring(macBytes, 2), NumberStyles.HexNumber);

            client.Send(bytes, bytes.Length);
        }
    }
}
