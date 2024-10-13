using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSaverSetter.Cmd
{
    internal class ArgsParam
    {
        public string ScreenSaverPath { get; set; }
        public bool? IsSecure { get; set; }
        public int Timeout { get; set; }
        public bool Show { get; set; }
        public bool Run { get; set; }
        public bool Version { get; set; }

        private static readonly string[] disableKeywords =
        {
            "none", "null", "nul", "nil", "disable", "off", "false", "no", "0",
            "無", "無し", "なし", "無効", "オフ", "偽", "いいえ"
        };
        private static readonly string[] enableKeywords =
        {
            "enable", "on", "true", "ok", "yes", "1",
            "有", "有り", "あり", "有効", "オン", "正", "はい"
        };

        public ArgsParam(string[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                switch (args[i].ToLower())
                {
                    case "/t":
                    case "-t":
                    case "--timeout":
                        this.Timeout = int.TryParse(args[++i], out int num) ? num : 0;
                        break;
                    case "/s":
                    case "-s":
                    case "--screensaver":
                        this.ScreenSaverPath = Item.PresetScreenSavers.GetScreenSaverPath(args[++i]);
                        break;
                    case "/n":
                    case "-n":
                    case "--noscreensaver":
                        this.ScreenSaverPath = "";
                        break;
                    case "/l":
                    case "-l":
                    case "--lock":
                        string lockText = args[++i].ToLower();
                        if (disableKeywords.Contains(lockText))
                        {
                            this.IsSecure = false;
                        }
                        else if (enableKeywords.Contains(lockText))
                        {
                            this.IsSecure = true;
                        }
                        break;
                    case "/i":
                    case "-i":
                    case "--info":
                        this.Show = true;
                        break;
                    case "/r":
                    case "-r":
                    case "--run":
                        this.Run = true;
                        break;
                    case "/v":
                    case "-v":
                    case "--version":
                        this.Version = true;
                        break;
                }
            }
            if (this.ScreenSaverPath == null && this.IsSecure == null && this.Timeout < 60 && !this.Run && !this.Version)
            {
                this.Show = true;
            }
        }
    }
}
