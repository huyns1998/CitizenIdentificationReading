using Microsoft.Extensions.DependencyInjection;
using CitizenIdentificationReading.Services;

namespace CitizenIdentificationReading
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            var services = new ServiceCollection();
            services.AddHttpClient<ICccdReaderService, CccdReaderService>();
            services.AddTransient<frmMain>();

            using var serviceProvider = services.BuildServiceProvider();
            var mainForm = serviceProvider.GetRequiredService<frmMain>();

            Application.Run(mainForm);
        }
    }
}