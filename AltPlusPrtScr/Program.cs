using System;
using System.Drawing;
using System.Windows.Forms;

class MainWindow
{
    static void Main()
    {
        ResidentTest rm = new ResidentTest();
        Application.Run();
    }
}

class ResidentTest : Form
{
    public ResidentTest()
    {
        this.ShowInTaskbar = false;
        this.setComponents();
    }

    private void setComponents()
    {
        //現在のコードを実行しているAssemblyを取得
        System.Reflection.Assembly myAssembly = System.Reflection.Assembly.GetExecutingAssembly();

        NotifyIcon icon = new NotifyIcon();
        icon.Icon = new Icon(myAssembly.GetManifestResourceStream("AltPlusPrtScr.app.ico"));
        icon.Visible = true;
        icon.Text = "Alt+PrtScrで画像保存するやつ";

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
    }

    private void Close_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }

}