﻿using Newtonsoft.Json;
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
                return;

            System.IO.File.WriteAllText(path, JsonConvert.SerializeObject(this));
        }
    }
}
