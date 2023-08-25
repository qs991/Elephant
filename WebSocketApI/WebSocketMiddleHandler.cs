using Newtonsoft.Json;
using System.Net.WebSockets;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json.Serialization;

namespace WebSocketApI
{
    /// <summary>
    /// 中间件
    /// </summary>
    public class WebSocketMiddleHandler
    {
        private readonly ILogger _logger;
        private readonly RequestDelegate _requestdelegate;
        public WebSocketMiddleHandler(ILoggerFactory loggerFactory, RequestDelegate requestdelegate)
        {
            _logger = loggerFactory.CreateLogger<WebSocketMiddleHandler>();
            _requestdelegate = requestdelegate;
        }
        /// <summary>
        /// 接收websocket连接
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Path == "/ws" || httpContext.Request.Path == "/wss")//wss为htttps
            {
                if (httpContext.WebSockets.IsWebSocketRequest)//是否是websocket请求
                {
                    WebSocket webSocket = await httpContext.WebSockets.AcceptWebSocketAsync();//接收websocket请求
                    string clientId = Guid.NewGuid().ToString();//客服端ID
                    var wsClient = new WebsocketClient() { Id = clientId, webSocket = webSocket };

                    try
                    {
                        await Handle(wsClient);
                    }
                    catch (Exception ee)
                    {
                        _logger.LogError(ee, "websocket 客服端错误{0}", clientId);
                        await httpContext.Response.WriteAsync("closed");
                    }

                }
                else
                {
                    httpContext.Response.StatusCode = 400;
                }
            }
            else
            {
                await _requestdelegate(httpContext);
            }
        }
        /// <summary>
        /// 处理连接  等待客户端信息
        /// </summary>
        /// <param name="websocketClient"></param>
        /// <returns></returns>
        public async Task Handle(WebsocketClient websocketClient)
        {
            WebsocketClientCollection.Add(websocketClient);
            _logger.LogInformation($"客服端{websocketClient.Id}已加入房间号:{websocketClient.roomNo}");

            WebSocketReceiveResult recResult = null;//接收的结果

            do
            {
                var buffer = new byte[1024 * 1024];
                recResult = await websocketClient.webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                if (recResult.MessageType == WebSocketMessageType.Text && !recResult.CloseStatus.HasValue)
                {
                    var msgStr = Encoding.UTF8.GetString(buffer);
                    _logger.LogInformation($"客服{websocketClient.Id},接收到消息:{msgStr}");
                    var message = JsonConvert.DeserializeObject<Message>(msgStr);
                    message.SendClientId = websocketClient.Id;
                    await MessageRoute(message);
                }

            } while (!recResult.CloseStatus.HasValue);


        }
        /// <summary>
        ///  客服操作进行处理  加入 离开
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task MessageRoute(Message message)
        {
            var client = WebsocketClientCollection.GetClientId(message.SendClientId);
            switch (message.action)
            {
                case "join":
                    client.roomNo = message.msg;
                    await client.SendMessageAsync($"{message.nick}加入聊天室{message.msg},{DateTime.Now.ToString("HH:mm:ss")}");
                    _logger.LogInformation($"{message.nick}加入聊天室{message.msg},{DateTime.Now.ToString()}");
                    break;
                case "send":
                    if (string.IsNullOrWhiteSpace(client.roomNo) && string.IsNullOrWhiteSpace(message.msg))
                    {
                        break;
                    }

                    var clientRoom = WebsocketClientCollection.GetRoomNo(client.roomNo);
                    foreach (var item in clientRoom)
                    {
                        await item.SendMessageAsync($"{message.nick}:{message.msg},{DateTime.Now.ToString("HH:mm:ss")}");
                    }
                    break;
                case "leave":
                    var roomNo = message.msg;
                    client.roomNo = "";
                    await client.SendMessageAsync($"{message.nick}离开房间,{DateTime.Now.ToString("HH:mm:ss")}");
                    _logger.LogInformation($"客服端:{message.SendClientId}离开房间:{roomNo}");
                    break;
            }
        }
    }

}
