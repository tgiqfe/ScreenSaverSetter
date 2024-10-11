using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSaverSetter
{
    internal class PresetScreenSavers
    {
        private List<ScreenSaverItem> _items;

        public PresetScreenSavers()
        {
            InitSetting();
        }

        private void InitSetting()
        {
            _items = new()
            {
                new ScreenSaverItem()
                {
                    Name = "3dtext",
                    Name_jp = "3Dテキスト",
                    Aliases = new string[] { "3d text", "3D テキスト" },
                    Path = @"C:\WINDOWS\system32\ssText3d.scr"
                },
                new ScreenSaverItem()
                {
                    Name = "bubbles",
                    Name_jp = "バブル",
                    Aliases = new string[] { "Bubble" },
                    Path = @"C:\WINDOWS\system32\Bubbles.scr"
                },
                new ScreenSaverItem()
                {
                    Name = "blank",
                    Name_jp = "ブランク",
                    Aliases = new string[] { "Blanc", "Brank", "Branc" },
                    Path = @"C:\WINDOWS\system32\scrnsave.scr"
                },
                new ScreenSaverItem()
                {
                    Name = "lineart",
                    Name_jp = "ライン アート",
                    Aliases = new string[] { "Line Art", "mystify", "ラインアート" },
                    Path = @"C:\WINDOWS\system32\Mystify.scr"
                },
                new ScreenSaverItem()
                {
                    Name = "ribbons",
                    Name_jp = "リボン",
                    Aliases = new string[] { "Ribbon" },
                    Path = @"C:\WINDOWS\system32\Ribbons.scr"
                },
                new ScreenSaverItem()
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
    }
}
