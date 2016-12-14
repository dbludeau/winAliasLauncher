using System;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Windows;

namespace WpfApplication1.models
{
    class fileParser
    {
        static string path = Environment.ExpandEnvironmentVariables("%HOMEDRIVE%%HOMEPATH%");
        static string json_file = path + "\\launcherPrograms.json";
        //static string json_file = "C:\\Users\\dbludeau\\launcherPrograms.json";
        private JObject jo;

        public fileParser()
        {
            if (File.Exists(json_file))
            {
                this.jo = JObject.Parse(File.ReadAllText(json_file));
            }
            else
            {
                MessageBox.Show("Unable to load json data file (" + json_file + ")");
            }
        }

        public string getCmd(string name)
        {
            return (string)this.jo[name];
        }
    }
}
