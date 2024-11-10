using password_manager_client.Forms;
using System;
using System.IO;
using System.Windows.Forms;
using Microsoft.Extensions.Configuration;

namespace password_manager_client
{
    internal static class Program
    {
        public static IConfiguration Configuration { get; private set; }
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

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ApplicationConfiguration.Initialize();
            Application.Run(new LoginForm());
        }
    }
}