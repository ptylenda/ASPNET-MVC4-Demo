using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PhotoSharingApplication.Hubs
{
    public class ChatHub : Hub
    {
        public Task Join(int photoId)
        {
            return this.Groups.Add(this.Context.ConnectionId, CreateGroupName(photoId));
        }

        public Task Send(string userName, int photoId, string message)
        {
            string groupName = CreateGroupName(photoId);
            return this.Clients.Group(groupName).addMessage(userName, message);
        }

        private static string CreateGroupName(int photoId)
        {
            return string.Format("Photo {0}", photoId);
        }
    }
}