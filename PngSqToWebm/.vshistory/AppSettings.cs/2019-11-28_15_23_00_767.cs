using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PngSqToWebm
{
    class AppSettings
    {
        public string ffmpegPath;
        public string lastworkDirectory;

        [JsonIgnore]
        public string settingsFilePath;


        [JsonIgnore]
        public static AppSettings Value { get; private set; }

        public AppSettings()
        {
            Value = this;
        }

        public void Save(string path = null)
        {
            if (string.IsNullOrEmpty(path))
                path = settingsFilePath;

            if (string.IsNullOrEmpty(path))
                return;

            using (var fs = System.IO.File.OpenWrite(path))
            {
                var buffer = System.Text.Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(this));
                fs.Write()
            }
        }
    }
}
