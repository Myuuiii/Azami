using Microsoft.EntityFrameworkCore;

namespace Azami.Models
{
	public class AzamiContext : DbContext
	{

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			Configuration config = Program._config;
			string dbString = $"server={config.DbHost};uid={config.DbUser};pwd={config.DbPassword};database={config.DbName}";
			optionsBuilder.UseMySql(dbString, ServerVersion.AutoDetect(dbString));
		}
		public DbSet<Log> Logs { get; set; }
	}
}