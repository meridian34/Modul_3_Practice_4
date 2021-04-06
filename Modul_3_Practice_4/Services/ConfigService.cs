using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modul_3_Practice_4.Model;
using Modul_3_Practice_4.Services.Abstract;
using Newtonsoft.Json;

namespace Modul_3_Practice_4.Services
{
    class ConfigService : IConfigService
    {
        public Config GetConfig()
        {
            Config c = JsonConvert.DeserializeObject<Config>(File.ReadAllText("Config.json"));
            return c;
        }
    }
}
