using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSaverSetter
{
    internal class PInvoke
    {
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SystemParametersInfo(SPI uiAction, uint uiParam, ref uint pvParam, SPIF fWinIni);

        public enum SPI : uint
        {
            //  スクリーンセーバー有効/無効
            SPI_GETSCREENSAVEACTIVE = 0x0010,
            SPI_SETSCREENSAVEACTIVE = 0x0011,

            //  スクリーンセーバー終了時にパスワードを必要とするかどうか
            SPI_GETSCREENSAVESECURE = 0x0076,
            SPI_SETSCREENSAVESECURE = 0x0077,

            //  スクリーンセーバー開始までの時間
            SPI_GETSCREENSAVETIMEOUT = 0x000E,
            SPI_SETSCREENSAVETIMEOUT = 0x000F,

            //  スクリーンセーバーの実行状態
            SPI_GETSCREENSAVERRUNNING = 0x0072,
        }
        public enum SPIF
        {
            None = 0x00,
            SPIF_UPDATEINIFILE = 0x01,
            SPIF_SENDCHANGE = 0x02,
            SPIF_SENDWININICHANGE = 0x02
        }
    }
}
