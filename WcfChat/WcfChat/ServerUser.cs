using System.ServiceModel;

namespace WcfChat
{
	public class ServerUser
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public OperationContext OperationContext { get; set; }
	}
}