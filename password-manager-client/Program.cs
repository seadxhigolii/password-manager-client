using password_manager_client.Forms;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace password_manager_client
{
    internal static class Program
    {
        public static IConfiguration Configuration { get; private set; }
        public static JsonSerializerOptions JsonOptions { get; private set; }
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var environment = Environment.GetEnvironmentVariable("APP_ENV") ?? "Development";
            var builder = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                 .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true);
            
            Configuration = builder.Build();

            JsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                WriteIndented = true
            };

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            ApplicationConfiguration.Initialize();
            Application.Run(new LoginForm());
        }
    }
}