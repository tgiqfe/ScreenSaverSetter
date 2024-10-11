namespace ScreenSaverSetter
{
    internal class Argsparam
    {
        public string ScreenSaverPath { get; set; }
        public bool IsNone { get; set; }
        public bool? IsPassword { get; set; }
        public int Timeout { get; set; } = -1;

        public Argsparam(string[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                switch (args[i].ToLower())
                {
                    case "/t":
                    case "-t":
                    case "--timeout":
                        this.Timeout = int.TryParse(args[++i], out int num) ? num : -1;
                        break;
                    case "/s":
                    case "-s":
                    case "--screensaver":
                        this.ScreenSaverPath = Item.PresetScreenSavers.GetScreenSaverPath(args[++i]);
                        break;
                    case "/n":
                    case "-n":
                    case "--noscreensaver":
                        this.IsNone = true;
                        break;
                    case "/p":
                    case "-p":
                    case "--password":



                        break;
                }
            }
        }
    }
}
