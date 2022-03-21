using System;
using System.ServiceModel;

namespace ChatHost
{
	class Program
	{
		static void Main(string[] args)
		{
			using (var host = new ServiceHost(typeof(WcfChat.ServiceChat)))
			{
				host.Open();
				Console.WriteLine("Хост стартовал!");
				Console.ReadLine();
			}
		}
	}
}