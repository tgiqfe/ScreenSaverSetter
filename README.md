# SetScreenSaver

使用法 SetScreenSaver.exe /S <スクリーンセーバー種別> [/T <タイムアウト>]
　　　 SetScreenSaver.exe /N [/T <タイムアウト>]
　　　 SetScreenSaver.exe /?

オプション：
  /S <スクリーンセーバー種別>  実行されるスクリーンセーバーの種類を指定
  /T <タイムアウト>            スクリーンセーバー開始までの時間を指定 (秒)
  /N                           スクリーンセーバーを「なし」に設定
                               /S と /N を両方指定した場合、/N を優先
  /?                           ヘルプを表示

Windows 10 デフォルトのスクリーンサーバー：
  3Dテキスト    ⇒ C:\WINDOWS\system32\ssText3d.scr
  バブル        ⇒ C:\WINDOWS\system32\Bubbles.scr
  ブランク      ⇒ C:\WINDOWS\system32\scrnsave.scr
  ライン アート ⇒ C:\WINDOWS\system32\Mystify.scr
  リボン        ⇒ C:\WINDOWS\system32\Ribbons.scr
  写真          ⇒ C:\WINDOWS\system32\PhotoScreensaver.scr
※この6個については、「.scr」ファイルへのパス / スクリーンセーバー名のどちでも指定可。
　オリジナルスクリーンセーバーを指定する場合は、「.scr」へのパスを指定。

例：
  SetScreenSaver.exe /S 3Dテキスト /T 300
  - スクリーンセーバーを「3Dテキスト」に設定し、5分後に起動するようにする。

  SetScreenSaver.exe /S "C:\WINDOWS\system32\ssText3d.scr" / T 300
  - スクリーンセーバーを「3Dテキスト」に設定し、5分後に起動するようにする。
　  ※「3Dテキスト」と指定した場合と同じ挙動

  SetScreenSaver.exe /N
  - スクリーンセーバーを起動しないようにする。

  SetScreenSaver.exe /S "D:\Origin\OriginalScreenSaver.scr"
  - オリジナルスクリーンセーバーに変更する。
