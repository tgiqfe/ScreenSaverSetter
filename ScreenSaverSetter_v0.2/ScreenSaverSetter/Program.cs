using ScreenSaverSetter;
using System.Reflection;

var ap = new Argsparam(args);
ScreenSaverSetting sss = new(true);
if (ap.Show)
{
    PrintText.Show(sss.ScreenSaverPath, sss.IsSecure, sss.Timeout, sss.IsRunning);
}
else if (ap.Run)
{
    sss.Run();
}
else if (ap.Version)
{
    var version = Assembly.GetExecutingAssembly().GetName().Version;
    Console.WriteLine($"ScreenSaverSetter version: {version.Major}.{version.Minor}.{version.Build}.{version.Revision}");
}
else
{
    sss.SetParameter(ap.IsSecure, ap.Timeout, ap.ScreenSaverPath);
}

#if DEBUG
Console.ReadLine();
#endif

/*
 * http://mrxray.on.coocan.jp/Delphi/plSamples/S07_SystemParametersInfo_ScreemSaver.htm
 * https://doc.pcsoft.fr/en-US/?6510001
 */
