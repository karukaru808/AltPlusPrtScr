# AltPlusPrtScr
Alt+PrtScr を押したら自動で画像ファイルを生成してくれるソフトウェア。

## About
Windows の機能で Alt+PrtScr を押したらクリップボードにアクティブウィンドウのキャプチャがコピーされますが、画像ファイルとして保存はしてくれません。
わざわざペイントを開いて保存するのが面倒だったので自動でやってくれるソフトウェアを作りました。

  <!--
## Install & Usage
1. __[Releases](https://github.com/karukaru808/exPlugin/releases)__ からダウンロードしてくる。
1. ダウンロードしたDLLファイルを、ゆかりねっとをインストールした場所にあるpluginsフォルダへ移動する。  
   例：`C:\Program Files (x86)\OKAYULU STYLE\ゆかりねっと\plugins`
1. ゆかりねっとを起動すると `%AppData%\Local\Yukarinette\plugins` にCSVファイルが作られるので、 __2行目以降__ にキーワードとWAVEファイルパスを記入する。  
   例：`いらっしゃいませ,C:\Users\User\Music\VOICELOID+\東北きりたん exVOICE\あいさつ_基本語\いらっしゃいませ！.wav`
1. 設定画面から使用するVOICEROIDを指定する。
1. キーワードを喋る。

## FAQ
#### Q1
WAVEファイルが再生されない。
#### A1
CSVファイルの書き方が正しいか確認してください。正しい書き方は __左側にキーワード、右側にWAVEファイルパス__ です。また __2行目以降__ に記入されているか確認してください。  
WAVEファイルパスが正しいか確認してください。また __絶対パスでないと再生できません。__ 相対パスには対応していません。  
設定画面で正しいVOICEROIDが指定されているか確認してください。正しくないとWAVEファイルは再生されません。
#### Q2
確認したけど再生されない。そもそも起動しないなど。
#### A2
`%AppData%\Local\Yukarinette\Logs` にある最新のLogファイルとCSVファイルを用意して __[Twitter](https://twitter.com/_karukaru_)__ まで連絡下さい。
#### Q3
バグを見つけた。こんな機能が欲しい。その他意見など。
#### A3
詳しい内容を __[Twitter](https://twitter.com/_karukaru_)__ または __[Issues](https://github.com/karukaru808/exPlugin/issues)__ まで連絡下さい。自力でやれる方は __[Pull requests](https://github.com/karukaru808/exPlugin/pulls)__ でもどうぞ。
-->

## License
このプラグインは[MITライセンス](https://github.com/karukaru808/AltPlusPrtScr/blob/master/LICENSE)の下で公開しています。
