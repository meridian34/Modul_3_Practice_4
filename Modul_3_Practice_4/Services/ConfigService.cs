using System.IO;
using Modul_3_Practice_4.Model;
using Modul_3_Practice_4.Services.Abstract;
using Newtonsoft.Json;

namespace Modul_3_Practice_4.Services
{
    public class ConfigService : IConfigService
    {
        public Config GetConfig()
        {
            return JsonConvert.DeserializeObject<Config>(File.ReadAllText("Config.json"));
        }
    }
}
