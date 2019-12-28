using Microsoft.AspNet.SignalR;
using SignalR_UserControl.Models;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR_UserControl.Hubs
{
    public class CounterHub : Hub 
    {
        public static ConcurrentDictionary<string, string> ConnectedUsers = new ConcurrentDictionary<string, string>(); //eş zamanlı olarak sisteme  giris yapan kullanicilari listele
        public override Task OnConnected()
        {
            return base.OnConnected();
        }
        public override Task OnDisconnected(bool stopCalled) 
        {
            var userName = string.Empty;
            ConnectedUsers.TryRemove(Context.ConnectionId, out userName);
            userList();
            return base.OnDisconnected(stopCalled);
        }
        public void loginUser(string userName)
        {
            var data = ConnectedUsers.FirstOrDefault(x => x.Value == userName);
            ConnectedUsers.AddOrUpdate(Context.ConnectionId,userName,(k,v)=>userName);
            var state = data.Key;
            if (state != null) {
                ConnectedUsers.TryRemove(data.Key, out userName);
                Clients.Client(data.Key).directLogout();
             }
        }
        public void userList()
        {
            Clients.All.userList(ConnectedUsers);
        }


































        //public static List<user> AllConnectedUser = new List<user>();
        ////static long counter = 0; //count online users
        //public void Connect(string userName,string ipAdress)
        //{
        //    string conId = Context.ConnectionId;

        //    if (AllConnectedUser.Count( x=>x.conId == conId) == 0) {
        //        AllConnectedUser.Add(new user { conId=conId,userName=userName, IPadress = ipAdress });
        //        Clients.Caller.onConnected(userName,conId);
        //        Clients.All.showAllusers(AllConnectedUser);
        //    }
        ////counter++;
        ////base.OnConnectedAsync();
        ////Clients.All.UpdateCount(counter);
        //}
        //public override Task OnDisconnected(bool stopCalled)
        //{
        //    var user = AllConnectedUser.FirstOrDefault(x => x.conId == Context.ConnectionId);
        //    if (user != null)
        //    {
        //        AllConnectedUser.Remove(user);
        //        var conId = Context.ConnectionId;
        //        Clients.All.onUserDisconnected(conId);
        //    }
        //     //counter--;
        //    //Clients.All.UpdateCount(counter);
        //    return base.OnDisconnected(stopCalled);
        //}      
    }
}