namespace HallOfFame.Web.Hubs
{
    using System;
    using System.Linq;

    using HallOfFame.Data;
    using HallOfFame.Data.Contracts;

    using Microsoft.AspNet.SignalR;

    public class ChatHub : Hub
    {
        private readonly IHallOfFameData data;

        public ChatHub()
            : this(new HallOfFameData(new HallOfFameDbContext()))
        {
        }

        public ChatHub(IHallOfFameData data)
        {
            this.data = data;
        }

        public void Send(string name, string message)
        {
            var avatarUrl = this.data.Users.All()
                .Where(u => u.UserName == name)
                .Select(u => u.AvatarUrl)
                .FirstOrDefault();

            var date = DateTime.Now.ToString("dd MMMM HH:mm:ss");

            Clients.All.addMessage(name, message, avatarUrl, date);
        }
    }
}