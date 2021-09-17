using System;
using System.IO;
using System.Threading.Tasks;
using Azami.Models;
using Discord;
using Discord.WebSocket;
using Newtonsoft.Json;

namespace Azami
{
	class Program
	{
		private static DiscordSocketClient _client;
		public static Configuration _config;
		static void Main(string[] args) => MainAsync(args).GetAwaiter().GetResult();

		public static async Task MainAsync(string[] args)
		{
			if (File.Exists("config.json"))
			{
				_config = JsonConvert.DeserializeObject(File.ReadAllText("config.json"), typeof(Configuration)) as Configuration;
			}
			else
			{
				File.WriteAllText("./config.json", JsonConvert.SerializeObject(new Configuration()));
			}
			_client = new DiscordSocketClient();

			await _client.LoginAsync(TokenType.Bot, _config.BotToken);
			await _client.StartAsync();

			_client.MessageReceived += async (msg) =>
			{
				if (!msg.Author.IsBot)
				{
					AzamiContext ctx = new AzamiContext();

					Log log = new Log();
					log.ServerId = (msg.Channel as SocketGuildChannel).Guild.Id;
					log.MessageId = msg.Id;
					log.UserId = msg.Author.Id;
					log.UserName = msg.Author.Username;
					log.ChannelId = msg.Channel.Id;
					log.Message = msg.Content;
					log.Date = DateTime.Now;

					ctx.Logs.Add(log);
					ctx.SaveChanges();
				}
			};

			await Task.Delay(-1);
		}
	}
}
