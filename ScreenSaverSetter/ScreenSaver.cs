using Microsoft.Win32;
using System.Runtime.InteropServices;

namespace ScreenSaverSetter
{
    public class ScreenSaver
    {
        #region P/Invoke

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SystemParametersInfo(SPI uiAction, uint uiParam, ref uint pvParam, SPIF fWinIni);

        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern bool PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        enum SPI : uint
        {
            //  Screen saver enable/disables.
            SPI_GETSCREENSAVEACTIVE = 0x0010,
            SPI_SETSCREENSAVEACTIVE = 0x0011,

            //  Whether to require a password to exit the screensaver.
            SPI_GETSCREENSAVESECURE = 0x0076,
            SPI_SETSCREENSAVESECURE = 0x0077,

            //  Screensaver start time. (seconds)
            SPI_GETSCREENSAVETIMEOUT = 0x000E,
            SPI_SETSCREENSAVETIMEOUT = 0x000F,

            //  Screensaver running status.
            SPI_GETSCREENSAVERRUNNING = 0x0072,
        }

        enum SPIF
        {
            None = 0x00,
            SPIF_UPDATEINIFILE = 0x01,
            SPIF_SENDCHANGE = 0x02,
            SPIF_SENDWININICHANGE = 0x02
        }

        const IntPtr HWND_BROADCAST = 0xffff;
        const IntPtr HWND_TOP = 0;
        const IntPtr HWND_BOTTOM = 1;
        const IntPtr HWND_TOPMOST = -1;
        const IntPtr HWND_NOTOPMOST = -2;
        const IntPtr HWND_MESSAGE = -3;
        const uint WM_SYSCOMMAND = 0x0112;
        const IntPtr SC_SCREENSAVE = 0xF140;

        #endregion
        #region Public Properties

        private bool IsActive { get; set; }
        public bool IsSecure { get; set; }
        public int Timeout { get; set; }
        public string ScreenSaverPath { get; set; }
        public bool IsRunning { get; set; }

        #endregion

        public ScreenSaver(bool loadCurrent = false)
        {
            if (loadCurrent)
            {
                GetCurrent();
            }
        }

        /// <summary>
        /// Get current parameters for ScreenSaver.
        /// </summary>
        public void GetCurrent()
        {
            uint isActive = 0;
            SystemParametersInfo(SPI.SPI_GETSCREENSAVEACTIVE, 0, ref isActive, SPIF.None);
            this.IsActive = isActive != 0;

            uint isSecure = 0;
            SystemParametersInfo(SPI.SPI_GETSCREENSAVESECURE, 0, ref isSecure, SPIF.None);
            this.IsSecure = isSecure != 0;

            uint ssTimeout = 0;
            SystemParametersInfo(SPI.SPI_GETSCREENSAVETIMEOUT, 0, ref ssTimeout, SPIF.None);
            this.Timeout = (int)ssTimeout;

            using (var regKey = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop"))
            {
                this.ScreenSaverPath = regKey.GetValue("SCRNSAVE.EXE") as string;
            }

            uint isRunning = 0;
            SystemParametersInfo(SPI.SPI_GETSCREENSAVERRUNNING, 0, ref isRunning, SPIF.None);
            this.IsRunning = isRunning != 0;
        }

        /// <summary>
        /// Start ScreenSaver
        /// </summary>
        public void Run()
        {
            PostMessage(HWND_BROADCAST, WM_SYSCOMMAND, SC_SCREENSAVE, IntPtr.Zero);
        }

        #region Set parameter methods

        /// <summary>
        /// Set parameters for ScreenSaver.
        /// </summary>
        /// <param name="isSecure"></param>
        /// <param name="timeout"></param>
        /// <param name="path"></param>
        public void SetParameter(bool? isSecure, int timeout, string path)
        {
            if (isSecure != null || timeout >= 60 || path != null)
            {
                using (var regKey = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true))
                {
                    SetScreenSaverActive(regKey, true);
                    SetScreenSaverSecure(regKey, isSecure);
                    SetScreenSaverTimeout(regKey, timeout);
                    SetScreenSaverPath(regKey, path);
                }
            }
        }

        private void SetScreenSaverActive(RegistryKey regKey, bool isActive = false)
        {
            if (this.IsActive != isActive)
            {
                uint value = isActive ? 1U : 0U;
                SystemParametersInfo(SPI.SPI_SETSCREENSAVEACTIVE, value, ref value, SPIF.SPIF_SENDCHANGE);
            }

            string valName = "ScreenSaveActive";
            if (isActive)
            {
                regKey.SetValue(valName, 0, RegistryValueKind.String);
            }
            else
            {
                if (regKey.GetValueNames().Any(x => x.Equals(valName, StringComparison.OrdinalIgnoreCase)))
                {
                    regKey.DeleteValue(valName);
                }
            }
        }

        private void SetScreenSaverSecure(RegistryKey regKey, bool? isSecure)
        {
            if (isSecure != null && this.IsSecure != isSecure)
            {
                uint value = isSecure == true ? 1U : 0U;
                SystemParametersInfo(SPI.SPI_SETSCREENSAVESECURE, value, ref value, SPIF.SPIF_SENDCHANGE);

                string valName = "ScreenSaverIsSecure";
                if (isSecure == true)
                {
                    regKey.SetValue(valName, "1", RegistryValueKind.String);
                }
                else
                {
                    if (regKey.GetValueNames().Any(x => x.Equals(valName, StringComparison.OrdinalIgnoreCase)))
                    {
                        regKey.DeleteValue(valName);
                    }
                }
            }
        }

        private void SetScreenSaverTimeout(RegistryKey regKey, int timeout)
        {
            if (timeout >= 60 && this.Timeout != timeout)
            {
                uint value = (uint)timeout;
                SystemParametersInfo(SPI.SPI_SETSCREENSAVETIMEOUT, value, ref value, SPIF.SPIF_SENDCHANGE);

                string valName = "ScreenSaveTimeOut";
                regKey.SetValue(valName, timeout.ToString(), RegistryValueKind.String);
            }
        }

        private void SetScreenSaverPath(RegistryKey regKey, string path)
        {
            string valName = "SCRNSAVE.EXE";
            if (path != null && this.ScreenSaverPath != path)
            {
                if (path != "")
                {
                    regKey.SetValue(valName, path, RegistryValueKind.String);
                }
                else
                {
                    if (regKey.GetValueNames().Any(x => x.Equals(valName, StringComparison.OrdinalIgnoreCase)))
                    {
                        regKey.DeleteValue(valName);
                    }
                }
            }
        }

        #endregion
    }
}
