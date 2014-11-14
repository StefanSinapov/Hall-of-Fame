namespace HallOfFame.Web.Hubs
{
    using Microsoft.AspNet.SignalR;

    public class MessageHub : Hub
    {
        public void ChangeGroup()
        {
            // Clients.Caller.changeGroup
        }

        public void GetUnreadMessages()
        {
        }

        public void Join()
        {
        }

        public void RegisterUser()
        {
        }

        public void SendMessage()
        {
        }
    }
}