using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSaverSetter
{
    public class PresetScreenSavers
    {
        private List<PreScreenSaver> _items;

        class PreScreenSaver
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

        public PresetScreenSavers()
        {
            InitSetting();
        }

        private void InitSetting()
        {
            _items = new()
            {
                new PreScreenSaver()
                {
                    Name = "3dtext",
                    Name_jp = "3Dテキスト",
                    Aliases = new string[] { "3d text", "3D テキスト" },
                    Path = @"C:\WINDOWS\system32\ssText3d.scr"
                },
                new PreScreenSaver()
                {
                    Name = "bubbles",
                    Name_jp = "バブル",
                    Aliases = new string[] { "Bubble" },
                    Path = @"C:\WINDOWS\system32\Bubbles.scr"
                },
                new PreScreenSaver()
                {
                    Name = "blank",
                    Name_jp = "ブランク",
                    Aliases = new string[] { "Blanc", "Brank", "Branc" },
                    Path = @"C:\WINDOWS\system32\scrnsave.scr"
                },
                new PreScreenSaver()
                {
                    Name = "lineart",
                    Name_jp = "ライン アート",
                    Aliases = new string[] { "Line Art", "mystify", "ラインアート" },
                    Path = @"C:\WINDOWS\system32\Mystify.scr"
                },
                new PreScreenSaver()
                {
                    Name = "ribbons",
                    Name_jp = "リボン",
                    Aliases = new string[] { "Ribbon" },
                    Path = @"C:\WINDOWS\system32\Ribbons.scr"
                },
                new PreScreenSaver()
                {
                    Name = "picture",
                    Name_jp = "写真",
                    Aliases = new string[] { "Photo", "Pictures", "フォト", "ピクチャ", "ピクチャー" },
                    Path = @"C:\WINDOWS\system32\PhotoScreensaver.scr"
                },
            };
        }

        public string GetScreenSaverPath(string keyword)
        {
            var ssItem = _items.FirstOrDefault(x => x.IsKeywordMatch(keyword));
            return ssItem == null ? keyword : ssItem.Path;
        }

        public string ConvertPathToPresetname(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                return "(None)";
            }
            var ssItem = _items.FirstOrDefault(x => x.Path.Equals(path, StringComparison.OrdinalIgnoreCase));
            return ssItem == null ? path : ssItem.Name_jp;
        }
    }
}
