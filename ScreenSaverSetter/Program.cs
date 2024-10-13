using Microsoft.Win32;
using ScreenSaverSetter;
using System.Text.Json;



var ap = new Argsparam(args);
ScreenSaverSetting sss = new();
sss.GetCurrent();



string json = JsonSerializer.Serialize(sss, new JsonSerializerOptions()
{
    WriteIndented = true
});
Console.WriteLine(json);

//sss.Run();

Console.ReadLine();

/*
 * http://mrxray.on.coocan.jp/Delphi/plSamples/S07_SystemParametersInfo_ScreemSaver.htm
 * https://doc.pcsoft.fr/en-US/?6510001
 */
