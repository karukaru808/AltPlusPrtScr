# AltPlusPrtScr
Alt+PrtScr を押したら自動で画像ファイルを生成してくれるソフトウェア。

## About
Windows の機能で __Alt+PrtScr__ を押したらクリップボードにアクティブウィンドウのキャプチャがコピーされますが、画像ファイルとして保存はしてくれません。  
わざわざペイントを開いて保存するのが面倒だったので、自動でやってくれるソフトウェアを作りました。

## Install
1. __[Releases](https://github.com/karukaru808/AltPlusPrtScr/releases)__ からダウンロードしてくる。
1. EXEファイルを適当な場所に置き、スタートアッププログラムとして Windows に登録する。  
スタートアッププログラムの登録方法がわからない方は __[コチラ](https://support.microsoft.com/ja-jp/help/4026268/windows-change-startup-apps-in-windows-10)__ 。
1. 起動すると __APPS__ という名前のソフトウェアがタスクトレイに現れるので、 __Alt+PrtScr__ を押すとピクチャのスクリーンショットフォルダにPNG画像が保存されます。  

## Usage
ソフトウェアが起動した状態で __Alt+PrtScr__ を押すと、ピクチャのスクリーンショットフォルダにPNG画像が保存されます。  
ここら辺の挙動は Win+PrtScr となるべく同じになるようにしています。

タスクトレイにあるアイコンを右クリックすると、一時停止と終了を選ぶことができます。  
一時停止をオンにすると Alt+PrtScr を押しても画像は保存されません。  
終了を押すとソフトウェアが終了します。

## Notes
ざっとバグ取りしたつもりですが、まだバグがあるかもしれません。  
バグを見つけた、こんな機能が欲しい、その他意見などありましたら、詳しい内容を __[Twitter](https://twitter.com/_karukaru_)__ または __[Issues](https://github.com/karukaru808/AltPlusPrtScr/issues)__ まで連絡下さい。自力でやれる方は __[Pull requests](https://github.com/karukaru808/AltPlusPrtScr/pulls)__ でもどうぞ。

## License
このプラグインは[MITライセンス](https://github.com/karukaru808/AltPlusPrtScr/blob/master/LICENSE)の下で公開しています。
