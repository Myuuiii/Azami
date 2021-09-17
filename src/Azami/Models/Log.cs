using System;
using System.ComponentModel.DataAnnotations;

namespace Azami.Models
{
	public class Log
	{
		public ulong ServerId { get; set; }
		[Key]
		public ulong MessageId { get; set; }
		public ulong UserId { get; set; }
		public string UserName { get; set; }
		public ulong ChannelId { get; set; }
		public string Message { get; set; }
		public DateTime Date { get; set; }
	}
}