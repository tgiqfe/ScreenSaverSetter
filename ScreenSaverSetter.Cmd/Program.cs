using ScreenSaverSetter;
using ScreenSaverSetter.Cmd;
using System.Reflection;

var ap = new ArgsParam(args);
ScreenSaver sss = new(true);
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
    var version = Assembly.GetAssembly(typeof(ScreenSaver)).GetName().Version;
    Console.WriteLine($"ScreenSaverSetter version: {version.Major}.{version.Minor}.{version.Build}.{version.Revision}");
}
else
{
    sss.SetParameter(ap.IsSecure, ap.Timeout, ap.ScreenSaverPath);
}

#if DEBUG
Console.ReadLine();
#endif
