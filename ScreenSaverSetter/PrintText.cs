using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSaverSetter
{
    internal class PrintText
    {
        public static void Show(string path, bool isSecure, int timeout)
        {
            string text = string.Format(@"
[ScreenSaver]
    ScreenSaver path : {0}
    Return to logon  : {1}
    Wait time        : {2} seconds
",
Item.PresetScreenSavers.ConvertPathToPresetname(path),
isSecure ? "Enable" : "Disable",
timeout
            );
            Console.WriteLine(text
);
        }
    }
}
