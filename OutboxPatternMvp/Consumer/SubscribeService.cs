using System;
using DotNetCore.CAP;

namespace Consumer
{
	public interface ISubscriberService
	{
		void CheckReceivedMessage(DateTime datetime);
	}

	public class SubscriberService: ISubscriberService, ICapSubscribe
	{
		[CapSubscribe("xxx.services.show.time")]
		public void CheckReceivedMessage(DateTime datetime)
		{
			Console.WriteLine("Consumed" + datetime);
		}
	}
}