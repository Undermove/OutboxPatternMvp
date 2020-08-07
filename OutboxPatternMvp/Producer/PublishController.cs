using System;
using DotNetCore.CAP;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;

namespace Producer
{
	public class PublishController: ControllerBase
	{
		private readonly ICapPublisher _capBus;

		public PublishController(ICapPublisher capPublisher)
		{
			_capBus = capPublisher;
		}

		[HttpGet]
		[Route("outbox", Name = "outbox")]
		public IActionResult Publish()
		{
			using (var connection = new MySqlConnection("Server=localhost;Database=outboxmvp;Uid=app;Password=12345;Allow User Variables=True;Port=3308"))
			{
				using (var transaction = connection.BeginTransaction(_capBus, autoCommit: true))
				{
					//your business logic code

					_capBus.Publish("xxx.services.show.time", DateTime.Now);
				}
			}

			return Ok();
		}
	}
}