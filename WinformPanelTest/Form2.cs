using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinformPanelTest
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            button2.Click +=(s,e)=> contextMenuStrip1.Click();
            button2_Click +=(s,e)=> contextMenuStrip1.Click();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //ContextMenuStrip cms = new ContextMenuStrip();
            //cms.Items.Add("属性设置");
            //坐标转化保证右键菜单出现在点击的位置
            //Point p = oView.PointToScreen(e.Location);
            //cms.Show(p);

            //cms.Items[0].Tag = oView;
            //cms.Items[0].Click += ContextMenuStrip_Click;



            //contextMenuStrip1.Show(((Button)sender).Location.X, (((Button)sender).Location.Y -((Button)sender).Width));
            //contextMenuStrip1.Show(((Button)sender).Location.X, ((Button)sender).Location.Y);
            contextMenuStrip1.Click();
            //contextMenuStrip1.Show(e.Location.X, ((Button)sender).Location.Y);

            //= new ContextMenuStrip();
            //contextMenuStrip1.l
            //contextMenuStrip1.Show();
        }
        //打开新窗体的菜单项单击事件
        private void 打开窗体ToolStripMenuItem_Click(object sender, EventArgs e)
    {
        ContextMenuStrip menu1 = new ContextMenuStrip();
        menu1.Show();
    }
    //关闭窗体菜单项的单击事件
    private void 关闭窗体ToolStripMenuItem_Click(object sender, EventArgs e)
    {
        this.Close();
    }

        private void contextMenuStrip1_MouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show("ssss");
        }
    }
}
