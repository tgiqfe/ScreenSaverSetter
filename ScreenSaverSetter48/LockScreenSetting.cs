namespace ScreenSaverSetter
{
    public class LockScreenSetting
    {
        /// <summary>
        /// dll import and run, for PowerShell 5.x
        /// </summary>
        /// <param name="isLock"></param>
        /// <param name="timeout"></param>
        /// <param name="screenSaverPath"></param>
        public static void Update(bool? isLock, int? timeout, string screenSaverPath)
        {
            string ssPath = string.IsNullOrEmpty(screenSaverPath) ?
                "":
                PresetScreenSavers.GetScreenSaverPath(screenSaverPath);
            
            var sss = new ScreenSaver(true);
            sss.SetParameter(isLock, timeout, ssPath);
        }
    }
}
