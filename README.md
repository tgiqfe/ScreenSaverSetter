# SetScreenSaver

使用法 SetScreenSaver.exe /S <スクリーンセーバー種別> [/T <タイムアウト>]<br>
　　　 SetScreenSaver.exe /N [/T <タイムアウト>]<br>
　　　 SetScreenSaver.exe /?<br>
<br>
オプション：<br>
  /S <スクリーンセーバー種別>  実行されるスクリーンセーバーの種類を指定<br>
  /T <タイムアウト>            スクリーンセーバー開始までの時間を指定 (秒)<br>
  /N                           スクリーンセーバーを「なし」に設定<br>
                               /S と /N を両方指定した場合、/N を優先<br>
  /?                           ヘルプを表示<br>
<br>
Windows 10 デフォルトのスクリーンサーバー：<br>
  3Dテキスト    ⇒ C:\WINDOWS\system32\ssText3d.scr<br>
  バブル        ⇒ C:\WINDOWS\system32\Bubbles.scr<br>
  ブランク      ⇒ C:\WINDOWS\system32\scrnsave.scr<br>
  ライン アート ⇒ C:\WINDOWS\system32\Mystify.scr<br>
  リボン        ⇒ C:\WINDOWS\system32\Ribbons.scr<br>
  写真          ⇒ C:\WINDOWS\system32\PhotoScreensaver.scr<br>
※この6個については、「.scr」ファイルへのパス / スクリーンセーバー名のどちでも指定可。<br>
　オリジナルスクリーンセーバーを指定する場合は、「.scr」へのパスを指定。<br>
<br>
例：<br>
  SetScreenSaver.exe /S 3Dテキスト /T 300<br>
  ースクリーンセーバーを「3Dテキスト」に設定し、5分後に起動するようにする。<br>
<br>
  SetScreenSaver.exe /S "C:\WINDOWS\system32\ssText3d.scr" / T 300<br>
  ースクリーンセーバーを「3Dテキスト」に設定し、5分後に起動するようにする。<br>
　  ※「3Dテキスト」と指定した場合と同じ挙動<br>
<br>
  SetScreenSaver.exe /N<br>
  ースクリーンセーバーを起動しないようにする。<br>
<br>
  SetScreenSaver.exe /S "D:\Origin\OriginalScreenSaver.scr"<br>
  ーオリジナルスクリーンセーバーに変更する。<br>
