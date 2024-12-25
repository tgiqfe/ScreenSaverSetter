using ScreenSaverSetter;
using ScreenSaverSetter.Cmd;
using System.Reflection;

ScreenSaver sss = new(true);
var ap = new ArgsParam(args);
switch (ap.Action)
{
    case ArgsParam.CommandAction.Show:
        PrintText.Show(sss.ScreenSaverPath, sss.IsSecure, sss.Timeout, sss.IsRunning);
        break;
    case ArgsParam.CommandAction.Run:
        sss.Run();
        break;
    case ArgsParam.CommandAction.Version:
        var version = Assembly.GetAssembly(typeof(ScreenSaver)).GetName().Version;
        Console.WriteLine($"ScreenSaverSetter version: {version.Major}.{version.Minor}.{version.Build}.{version.Revision}");
        break;
    case ArgsParam.CommandAction.Help:
        var text = ScreenSaverSetter.Cmd.Properties.Resources.HelpFile;
        Console.WriteLine(text);
        break;
    case ArgsParam.CommandAction.SetParameter:
        sss.SetParameter(ap.IsSecure, ap.Timeout, ap.ScreenSaverPath);
        break;
}


#if DEBUG
Console.ReadLine();
#endif
