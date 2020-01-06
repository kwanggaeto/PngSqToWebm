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
        public static AppSettings Value { get; private set; }

        public AppSettings()
        {
            Value = this;
        }

        public void Save(string path)
        {
            System.IO.File.WriteAllText(path)
        }
    }
}
