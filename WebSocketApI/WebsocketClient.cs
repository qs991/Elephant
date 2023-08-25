using System.Net.WebSockets;
using System.Text;

namespace WebSocketApI
{
    public class WebsocketClient
    {
        public WebSocket webSocket { get; set; }
        public string Id { get; set; }
        public string roomNo { get; set; }
        public Task SendMessageAsync(string message)
        {
            var msg = Encoding.UTF8.GetBytes(message);
            return webSocket.SendAsync(new ArraySegment<byte>(msg, 0, msg.Length), WebSocketMessageType.Text, true, CancellationToken.None);

        }
    }
}
