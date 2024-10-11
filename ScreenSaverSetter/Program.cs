using Microsoft.Win32;
using ScreenSaverSetter;

Console.WriteLine("Hello, World!");




uint res = 0;
PInvoke.SystemParametersInfo(
    PInvoke.SPI.SPI_SETSCREENSAVESECURE,
    1,
    ref res,
    PInvoke.SPIF.SPIF_SENDCHANGE);
/*
using (var regKey = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true))
{
    regKey.SetValue("ScreenSaverIsSecure", "1");
}
*/







Console.ReadLine();

/*
 * http://mrxray.on.coocan.jp/Delphi/plSamples/S07_SystemParametersInfo_ScreemSaver.htm
 * https://doc.pcsoft.fr/en-US/?6510001
 */
