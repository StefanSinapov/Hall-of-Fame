namespace HallOfFame.Web.Hubs
{
    using Microsoft.AspNet.SignalR;

    public class MessageHub : Hub
    {
        public void Hello()
        {
            Clients.All.hello();
        }
    }
}