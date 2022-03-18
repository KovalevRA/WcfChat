using System.ServiceModel;

namespace WcfChat
{
	// ПРИМЕЧАНИЕ. Можно использовать команду "Переименовать" в меню "Рефакторинг", чтобы изменить имя интерфейса "IServiceChat" в коде и файле конфигурации.
	[ServiceContract(CallbackContract = typeof(IServerChatCallback))]
	public interface IServiceChat
	{
		[OperationContract]
		int Connect(string name);

		[OperationContract]
		void Disconnect(int id);

		[OperationContract(IsOneWay = true)]
		void SendMsg(string msg, int id);
	}

	public interface IServerChatCallback
	{
		[OperationContract(IsOneWay = true)]
		void MsgCallback(string msg);
	}
}
