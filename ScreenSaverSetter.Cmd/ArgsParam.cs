using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSaverSetter.Cmd
{
    internal class ArgsParam
    {
        public enum CommandAction
        {
            None,
            Show,
            Run,
            Version,
            SetParameter
        }

        public string ScreenSaverPath { get; set; }
        public bool? IsSecure { get; set; }
        public int Timeout { get; set; }
        public CommandAction Action { get; set; } = CommandAction.Show;

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
                        this.Action = CommandAction.SetParameter;
                        break;
                    case "/s":
                    case "-s":
                    case "--screensaver":
                        this.ScreenSaverPath = PresetScreenSavers.GetScreenSaverPath(args[++i]);
                        this.Action = CommandAction.SetParameter;
                        break;
                    case "/n":
                    case "-n":
                    case "--noscreensaver":
                        this.ScreenSaverPath = "";
                        this.Action = CommandAction.SetParameter;
                        break;
                    case "/l":
                    case "-l":
                    case "--lock":
                        string lockText = args[++i].ToLower();
                        if (disableKeywords.Contains(lockText))
                        {
                            this.IsSecure = false;
                            this.Action = CommandAction.SetParameter;
                        }
                        else if (enableKeywords.Contains(lockText))
                        {
                            this.IsSecure = true;
                            this.Action = CommandAction.SetParameter;
                        }
                        break;
                    case "/i":
                    case "-i":
                    case "--info":
                        this.Action = CommandAction.Show;
                        break;
                    case "/r":
                    case "-r":
                    case "--run":
                        this.Action = CommandAction.Run;
                        break;
                    case "/v":
                    case "-v":
                    case "--version":
                        this.Action = CommandAction.Version;
                        break;
                }
            }
        }
    }
}
