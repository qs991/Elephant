namespace WebSocketApI
{
    public class WebsocketClientCollection
    {
        private static List<WebsocketClient> websocketClients = new List<WebsocketClient>();//存放客服端连接

        /// <summary>
        /// 添加客服端连接
        /// </summary>
        /// <param name="websocketClient"></param>
        public static void Add(WebsocketClient websocketClient)
        {
            websocketClients.Add(websocketClient);
        }
        /// <summary>
        /// 移除客服端链接
        /// </summary>
        /// <param name="websocketClient"></param>
        public static void Remove(WebsocketClient websocketClient)
        {
            websocketClients.Remove(websocketClient);
        }
        /// <summary>
        /// 获取客户ID的信息
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns></returns>
        public static WebsocketClient GetClientId(string clientId)
        {
            return websocketClients.FirstOrDefault(s => s.Id == clientId);
        }
        /// <summary>
        /// 获取房间中的所有客户端
        /// </summary>
        /// <param name="roomNo"></param>
        /// <returns></returns>
        public static List<WebsocketClient> GetRoomNo(string roomNo)
        {
            return websocketClients.Where(s => s.roomNo == roomNo).ToList();//一个房间会有多个人
        }

    }
}
