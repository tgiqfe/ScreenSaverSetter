using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetScreenSaver
{
    class ArgsParam
    {
        public int Timeout { get; set; } = 0;
        private Dictionary<string, string> def_ScrnSaveExe = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            { "3Dテキスト", @"C:\WINDOWS\system32\ssText3d.scr" },
            { "バブル", @"C:\WINDOWS\system32\Bubbles.scr" },
            { "ブランク", @"C:\WINDOWS\system32\scrnsave.scr" },
            { "ライン アート", @"C:\WINDOWS\system32\Mystify.scr" },
            { "リボン", @"C:\WINDOWS\system32\Ribbons.scr" },
            { "写真", @"C:\WINDOWS\system32\PhotoScreensaver.scr" }
        };
        public string ScrnSaveExe { get; set; } = "";
        public bool IsNone { get; set; } = false;
        public bool IsHelp { get; set; } = false;

        //  コンストラクタ
        public ArgsParam() { }
        public ArgsParam(string[] args)
        {
            //  引数解析
            try
            {
                for (int i = 0; i < args.Length; i++)
                {
                    switch (args[i].ToLower())
                    {
                        case "/t":
                        case "-t":
                        case "--timeout":
                            this.Timeout = int.TryParse(args[++i], out int tempInt) ? tempInt : 60;
                            break;
                        case "/s":
                        case "-s":
                        case "--screensaver":
                            string tempScrnSaveExe = args[++i];
                            if (def_ScrnSaveExe.ContainsKey(tempScrnSaveExe))
                            {
                                tempScrnSaveExe = def_ScrnSaveExe[tempScrnSaveExe];
                            }
                            this.ScrnSaveExe = tempScrnSaveExe;
                            break;
                        case "/n":
                        case "-n":
                        case "--none":
                            this.IsNone = true;
                            break;
                        case "/?":
                        case "--help":
                            this.IsHelp = true;
                            break;
                    }
                }
            }
            catch { }
        }
    }
}
