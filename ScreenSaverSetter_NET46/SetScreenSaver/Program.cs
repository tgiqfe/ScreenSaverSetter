using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.Threading;
using System.IO;
using System.Reflection;

namespace SetScreenSaver
{
    class Program
    {
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SystemParametersInfo(SPI uiAction, uint uiParam, ref uint pvParam, SPIF fWinIni);

        public enum SPI : uint
        {
            //  スクリーンセーバー有効/無効
            SPI_GETSCREENSAVEACTIVE = 0x0010,
            SPI_SETSCREENSAVEACTIVE = 0x0011,
            //  スクリーンセーバー開始までの時間
            SPI_GETSCREENSAVETIMEOUT = 0x000E,
            SPI_SETSCREENSAVETIMEOUT = 0x000F
        }

        public enum SPIF
        {
            None = 0x00,
            SPIF_UPDATEINIFILE = 0x01,
            SPIF_SENDCHANGE = 0x02,
            SPIF_SENDWININICHANGE = 0x02
        }

        //  メイン
        static void Main(string[] args)
        {
            ArgsParam ap = new ArgsParam(args);

            using (Mutex mutex = new Mutex(false, "SetScreenSaver"))
            {
                //  多重禁止
                if (!mutex.WaitOne(0, false)) { return; }

                //  カレントディレクトリ
                Environment.CurrentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

                //  ヘルプ表示
                if (ap.IsHelp)
                {
                    Help.View();
                    return;
                }

                if (ap.IsNone)
                {
                    //  スクリーンセーバー「なし」
                    try
                    {
                        using (RegistryKey regKey = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true))
                        {
                            regKey.DeleteValue("SCRNSAVE.EXE");
                        }
                    }
                    catch { }
                }
                else if (ap.ScrnSaveExe != null && ap.ScrnSaveExe != "")
                {
                    //  スクリーンセーバー設定
                    try
                    {
                        using (RegistryKey regKey = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true))
                        {
                            regKey.SetValue("SCRNSAVE.EXE", ap.ScrnSaveExe, RegistryValueKind.String);
                        }
                    }
                    catch { }
                }

                //  スクリーンセーバー開始までの時間を設定
                if(ap.Timeout > 0)
                {
                    using (RegistryKey regKey = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true))
                    {
                        regKey.SetValue("ScreenSaveTimeOut", ap.Timeout.ToString(), RegistryValueKind.String);
                    }
                }
                uint tempRes = 0;
                SystemParametersInfo(SPI.SPI_SETSCREENSAVETIMEOUT, (uint)ap.Timeout, ref tempRes, SPIF.SPIF_SENDCHANGE);
            }
        }
    }
}

/*  参考にしたサイト)
 *  https://msdn.microsoft.com/ja-jp/library/cc429946.aspx
 *  http://mrxray.on.coocan.jp/Delphi/plSamples/S07_SystemParametersInfo_ScreemSaver.htm
 *  https://social.msdn.microsoft.com/Forums/windows/ja-JP/325ae645-8ada-49db-8f1f-0985f99589bb/vista12391systemparametersinfo12398320802652412364213632617826377211771?forum=windowsgeneraldevelopmentissuesja
 *  https://isishizuka.wordpress.com/2012/08/25/c%E3%82%92%E4%BD%BF%E3%81%A3%E3%81%A6%E3%83%9E%E3%82%A6%E3%82%B9%E3%81%AE%E7%A7%BB%E5%8B%95%E9%80%9F%E5%BA%A6%E3%82%92%E5%A4%89%E3%81%88%E3%82%8B/
 *  https://doc.pcsoft.fr/en-US/?6510001
 */
