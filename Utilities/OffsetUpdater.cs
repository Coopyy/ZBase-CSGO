
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZBase.Classes;

namespace ZBase.Utilities
{
    // hazedumper auto offset updater - veri cool
    public class OffsetUpdater
    {
        public static void GetOffsetsFromFile()
        {
            string json = File.ReadAllText($@"{Application.StartupPath}\csgo.json");
            Main.O = JsonConvert.DeserializeObject<RootObject>(json);
        }
        public static void UpdateOffsets()
        {
            System.Net.WebClient wc = new System.Net.WebClient();
            byte[] raw = wc.DownloadData("https://raw.githubusercontent.com/frk1/hazedumper/master/csgo.json");
            string webData = Encoding.UTF8.GetString(raw);
            File.WriteAllText($@"{Application.StartupPath}\csgo.json", webData);
            GetOffsetsFromFile();
        }
    }
}
