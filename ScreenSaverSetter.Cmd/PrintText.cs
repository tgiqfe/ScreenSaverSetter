namespace ScreenSaverSetter.Cmd
{
    internal class PrintText
    {
        public static void Show(string path, bool isSecure, int timeout, bool isRunning)
        {
            string text = string.Format(@"[ScreenSaver]
    ScreenSaver path : {0}
    Return to lock   : {1}
    Wait time        : {2} seconds
    Running          : {3}",
PresetScreenSavers.ConvertPathToPresetname(path),
isSecure ? "Enable" : "Disable",
timeout,
isRunning
            );
            Console.WriteLine(text
);
        }
    }
}
