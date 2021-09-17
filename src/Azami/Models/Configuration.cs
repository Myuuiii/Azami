namespace Azami.Models
{
	public class Configuration
	{
		public string DbHost { get; set; } = "";
		public string DbName { get; set; } = "";
		public string DbUser { get; set; } = "";
		public string DbPassword { get; set; } = "";

		public string BotToken { get; set; } = "";
	}
}