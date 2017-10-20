using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace alertMe
{
    class Core
    {
        Config cfg = null;
        Mail mail;

        public Core()
        {
            this.loadConfig((x) => {
                if (this.cfg.isDefaultConfig()) {
                    return;
                } else {
                    if (!this.cfg.isInHourRange()) {
                        // Violation

                        this.mail = new Mail(this.cfg);
                        this.mail.send("UserInfo: " + (System.Environment.UserName + "@" + System.Environment.MachineName));
                    }
                }
            });
        }

        

        #region Config

        public void loadConfig(Action<bool> callback) {
            if (Config.Exists()) {
                this.Read((x) => callback(true));
            } else {
                this.WriteDefault((w) => {
                    this.Read((x) => callback(true));
                });
            }
        }

        public void Read(Action<bool> callback) {
            JsonSerializer js = new JsonSerializer();
            using (StreamReader sr = new StreamReader(Properties.Settings.Default.configFile))
            using (JsonReader jr = new JsonTextReader(sr))
            {
                cfg = js.Deserialize<Config>(jr);
                callback(true);
            }
        }

        public async void WriteDefault(Action<bool> callback)
        {
            Config tempCfg = new Config();

            JsonSerializer js = new JsonSerializer();
            js.Formatting = Formatting.Indented;
            using (StreamWriter sw = new StreamWriter(Properties.Settings.Default.configFile))
            using (JsonWriter jsw = new JsonTextWriter(sw))
            {
                js.Serialize(jsw, tempCfg);
                await jsw.CloseAsync();
                callback(true);
            }
        }

        #endregion Config
    }
}
