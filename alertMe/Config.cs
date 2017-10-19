using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alertMe
{
    class Config {

        [JsonProperty]
        public String smtpHost { get; set; }

        [JsonProperty]
        public Int32 smtpPort { get; set; }

        [JsonProperty]
        public Boolean smtpSSL { get; set; }

        [JsonProperty]
        public String smtpUser { get; set; }

        [JsonProperty]
        public String smtpPass { get; set; }

        [JsonProperty]
        public String targetEmail { get; set; }

        [JsonProperty]
        public String[] hourRange { get; set; }

        [JsonProperty]
        public String from { get; set; }

        [JsonProperty]
        public String subject { get; set; }

        [JsonProperty]
        public String message { get; set; }

        public Config() {
            // Mock values
            this.smtpHost = "mail.example.com";
            this.smtpPort = 587;
            this.smtpSSL = true;
            this.smtpUser = "username";
            this.smtpPass = "password";
            this.targetEmail = "test@example.com";
            this.hourRange = new String[] { "09:00:00", "18:00:00" };
            this.from = "username@example.com";
            this.subject = "[AlertMe] Detected new login outside allowed hour range";
            this.message = "Details about incident ... ";
        }

        public static bool Exists() { return System.IO.File.Exists(Properties.Settings.Default.configFile); }
        
        public bool isInHourRange() {

            TimeSpan startTime = TimeSpan.Parse(this.hourRange.ElementAt(0));
            TimeSpan endTime = TimeSpan.Parse(this.hourRange.ElementAt(1));

            DateTime now = DateTime.Now;
            DateTime start = new DateTime(now.Year, now.Month, now.Day, startTime.Hours, startTime.Minutes, startTime.Seconds);
            DateTime end = new DateTime(now.Year, now.Month, now.Day, endTime.Hours, endTime.Minutes, endTime.Seconds);

            return ((start >= now) && (now <= end));
        }
    }
}
