using Microsoft.Extensions.DependencyInjection;

namespace Data
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // AI Sistemleri için bağımlılıklar
            services.AddSingleton<AIManager>();
            services.AddSingleton<TradeAI>();
            services.AddSingleton<DroneAI>();
            services.AddSingleton<DefenseAI>();
        }
    }
}
