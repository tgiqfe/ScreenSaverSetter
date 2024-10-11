using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSaverSetter
{
    internal class ScreenSaverItem
    {
        public string Name { get; set; }
        public string Name_jp { get; set; }
        public string[] Aliases { get; set; }
        public string Path { get; set; }

        public bool IsKeywordMatch(string keyword)
        {
            if (this.Name.Equals(keyword, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            if (this.Name_jp.Equals(keyword, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            if (this.Aliases.Contains(keyword, StringComparer.OrdinalIgnoreCase))
            {
                return true;
            }
            return false;
        }
    }
}
