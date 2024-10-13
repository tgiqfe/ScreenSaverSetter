using Microsoft.Win32;
using ScreenSaverSetter;
using System.Text.Json;



var ap = new Argsparam(args);
ScreenSaverSetting sss = new(true);
if (ap.Show)
{
    PrintText.Show(sss.ScreenSaverPath, sss.IsSecure, sss.Timeout);
}
else if (ap.Run)
{
    sss.Run();
}
else
{
    sss.SetParameter(ap.IsSecure, ap.Timeout, ap.ScreenSaverPath);
}

Console.ReadLine();

/*
 * http://mrxray.on.coocan.jp/Delphi/plSamples/S07_SystemParametersInfo_ScreemSaver.htm
 * https://doc.pcsoft.fr/en-US/?6510001
 */
