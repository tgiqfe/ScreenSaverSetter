# ScreenSaverSetter

## インストール

### 前提条件

.NET 8.0

### インストール手順

↓のページから``ScreenSaverSetter.zip``をダウンロード。
[https://github.com/tgiqfe/ScreenSaverSetter/releases/latest](https://github.com/tgiqfe/ScreenSaverSetter/releases/latest)

任意の場所に展開する。

コマンドプロンプトから実行
```dos
sss /s <ScreenSaveer path> /t <timeout> /l true|false
```

## ヘルプファイル

```
[ScreenSaverSetter]
スクリーンセーバーの設定を変更。

使用方法:
  sss [/t <int>][/s <string>][/n][/l <bool>]
  sss [/i | /r | /v | /?]

パラメーター:
  /t <int>      スクリーンセーバー開始までの待ち時間。単位: 秒
                [--timeout]
  /s <string>   スクリーンセーバーのパスもしくは、プリセットスクリーンセーバーの名前を指定
                以下のプリセットのスクリーンセーバーが指定可能。
                (3Dテキスト, バブル, ブランク, ライン アート, リボン, 写真)
                [--screensaverpath]
  /n            スクリーンセーバーを (なし) に設定。
                [--noscreensaver]
  /l <bool>     再開時にログオン画面に戻る設定の有効/無効設定
                指定可能な値: true, false
                [--lock]
  /i            スクリーンセーバーの設定を表示
                [--info]
  /r            スクリーンセーバーを開始
                [--run]
  /v            バージョンを表示
                [--version]
  /?            ヘルプを表示
                [--help]

例:
  スクリーンセーバーの設定を表示
    > sss /i
  パラメータ指定無しでも、スクリーンセーバーの設定を表示
    > sss
  スクリーンセーバーを[3Dテキスト]、待ち時間を10分、再開時にログオン画面に設定
    > sss /s 3Dテキスト /t 60 /l true
  オリジナルのスクリーンセーバーを設定 (事前にインストールしておく必要有り)
    > sss /s "C:\Windows\System32\originalss.scr"
  今すぐスクリーンセーバーを開始
    > sss /r
  バージョンを確認
    > sss /v
  ヘルプを表示
    > sss /?
```
