using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

class MainWindow
{
    [STAThread]
    static void Main()
    {
        APPS apps = new APPS();
        Application.Run();
    }
}

class APPS : Form
{
    [System.Runtime.InteropServices.DllImport("user32.dll")]
    private static extern int GetAsyncKeyState(int vKey);

    Timer timer = new Timer();

    public APPS()
    {
        this.ShowInTaskbar = false;
        this.setComponents();

        timer.Tick += new EventHandler(this.KeysWatch_Tick);
        timer.Interval = 200;

        // タイマーを開始
        timer.Start();

    }

    private void setComponents()
    {
        // 現在のコードを実行しているAssemblyを取得
        Assembly myAssembly = Assembly.GetExecutingAssembly();

        NotifyIcon icon = new NotifyIcon();
        icon.Icon = new Icon(myAssembly.GetManifestResourceStream("AltPlusPrtScr.app.ico"));
        icon.Visible = true;
        icon.Text = "APPS";

        ContextMenuStrip menu = new ContextMenuStrip();

        ToolStripMenuItem Item1 = new ToolStripMenuItem();
        Item1.Text += "&一時停止";
        Item1.Click += new EventHandler(Toggle_Click);
        menu.Items.Add(Item1);

        ToolStripMenuItem Item2 = new ToolStripMenuItem();
        Item2.Text = "&終了";
        Item2.Click += new EventHandler(Close_Click);
        menu.Items.Add(Item2);

        icon.ContextMenuStrip = menu;
    }

    private void Toggle_Click(object sender, EventArgs e)
    {
        ToolStripMenuItem item = (ToolStripMenuItem)sender;
        // チェック状態を反転させる
        item.Checked = !item.Checked;

        // trueなら一時停止、falseならstart
        if (item.Checked)
        {
            // タイマーを停止
            timer.Stop();
        }
        else
        {
            // タイマーを再生
            timer.Start();
        }
    }

    private void Close_Click(object sender, EventArgs e)
    {
        // タイマーの後処理
        timer.Stop();
        timer.Dispose();

        Application.Exit();
    }

    private void KeysWatch_Tick(object sender, EventArgs e)
    {
        // Altキーの判定は複数ある
        // Menu = 18        Altキー
        // LMenu = 164      左Altキー
        // RMenu = 165      右Altキー
        // Alt = 262144     ALT修飾子キー
        int ALT = GetAsyncKeyState((int)Keys.Menu);
        int PSC = GetAsyncKeyState((int)Keys.PrintScreen);

        if (ALT != 0 && PSC != 0)
        {
            ImgSave();
            //System.Diagnostics.Debug.WriteLine("ALT+PSC");
        }
    }

    private void ImgSave()
    {
        // 入れ物用意
        Image img = null;

        try
        {
            // フォルダパスを取得
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + "\\Screenshots";

            // ディレクトリが存在しないなら作成
            Directory.CreateDirectory(path);

            // ディレクトリ内のpngファイルの数を取得
            int count = Directory.GetFiles(path, "*.png", SearchOption.TopDirectoryOnly).Length;

            // 若い数字からチェックしていき、空きがあったらその名前を登録
            for (int i = 1; i <= count+1; i++)
            {
                if (!File.Exists(path + "\\スクリーンショット (" + i + ").png"))
                {
                    path += "\\スクリーンショット (" + i + ").png";
                    break;
                }
            }

            //System.Diagnostics.Debug.WriteLine(count);
            //System.Diagnostics.Debug.WriteLine(path);

            // クリップボードにあるデータの取得
            // クリップボードに画像データがない場合、戻り値はnull
            img = Clipboard.GetImage();

            // PNG形式で保存する
            // imgの中身がnullだと保存に失敗する
            img.Save(path, System.Drawing.Imaging.ImageFormat.Png);

            // 後処理
            img.Dispose();
        }
        catch (Exception ex)
        {
            // imgがnullでDisposeするとエラーを吐く
            if(img != null)
            {
                // 後処理
                // 保存に失敗したときメモリを無限に消費するのを防ぐため
                // 無限と言っても200MB以下で強制的にDisposeされるっぽい？
                img.Dispose();
            }

            //System.Diagnostics.Debug.WriteLine(ex);
        }
    }
}

