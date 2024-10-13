namespace ScreenSaverSetter
{
    internal class Argsparam
    {
        public string ScreenSaverPath { get; set; }
        public bool? IsSecure { get; set; }
        public int Timeout { get; set; }
        public bool Show { get; set; }
        public bool Run { get; set; }

        private static string[] disableKeywords = new string[]
        {
            "none", "null", "nul", "nil", "disable", "off", "false", "no", "0",
            "無", "なし", "無効", "オフ", "偽", "いいえ"
        };

        public Argsparam(string[] args)
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
                        this.IsSecure = !disableKeywords.Contains(args[++i].ToLower());
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
                }
            }
            if (this.ScreenSaverPath == null && this.IsSecure == null && this.Timeout < 60)
            {
                this.Show = true;
            }
        }
    }
}
