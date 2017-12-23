using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

class MainWindow
{
    [STAThread]
    static void Main()
    {
        ResidentTest rm = new ResidentTest();
        Application.Run();
    }
}

class ResidentTest : Form
{
    [System.Runtime.InteropServices.DllImport("user32.dll")]
    private static extern int GetAsyncKeyState(int vKey);

    Timer timer = new Timer();

    public ResidentTest()
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
        System.Reflection.Assembly myAssembly = System.Reflection.Assembly.GetExecutingAssembly();

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
        //チェック状態を反転させる
        item.Checked = !item.Checked;

        //trueなら一時停止、falseならstart
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
        // タイマーを停止
        timer.Stop();

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
        try
        {
            // クリップボードにあるデータの取得
            Image img = Clipboard.GetImage();

            // フォルダパスを取得してファイル名の決定
            var pass = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + "\\Screenshots";
            // 
            int count = Directory.GetFiles(pass, "*.png", SearchOption.TopDirectoryOnly).Length;
            for(int i = 1; i < count+1; i++)
            {
                if (!File.Exists(pass + "\\スクリーンショット (" + i + ").png"))
                {
                    pass += "\\スクリーンショット (" + i + ").png";
                    break;
                }
            }

            //System.Diagnostics.Debug.WriteLine(count);
            //System.Diagnostics.Debug.WriteLine(pass);
            
            // PNG形式で保存する
            img.Save(pass, System.Drawing.Imaging.ImageFormat.Png);
        }
        catch (Exception ex)
        {
            //System.Diagnostics.Debug.WriteLine(ex);
        }
    }
}