using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace WcfChat
{
	[ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
	public class ServiceChat : IServiceChat
	{
		List<ServerUser> _users = new List<ServerUser>();
		int _nextId = 1;

		public int Connect(string name)
		{
			ServerUser user = new ServerUser
			{
				Id = _nextId,
				Name = name,
				OperationContext = OperationContext.Current
			};
			_nextId++;

			SendMsg($"{user.Name} подключился к чату.", 0);
			_users.Add(user);
			return user.Id;
		}

		public void Disconnect(int id)
		{
			var user = _users.FirstOrDefault(u => u.Id == id);
			if (user != null)
			{
				_users.Remove(user);
				SendMsg($"{user.Name} покинул чат.", 0);
			}
		}

		public void SendMsg(string msg, int id)
		{
			foreach (var user in _users)
			{
				var answer = new StringBuilder(DateTime.Now.ToShortTimeString());

				var currentUser = _users.FirstOrDefault(u => u.Id == id);
				if (currentUser != null)
				{
					answer.Append($": {user.Name} ");
				}
				answer.Append(msg);

				user.OperationContext.GetCallbackChannel<IServerChatCallback>().MsgCallback(answer.ToString());
			}
		}
	}
}
