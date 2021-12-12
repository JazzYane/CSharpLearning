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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.panel1.BackColor = Color.Gray;
            //this.panel1.ForeColor = Color.Gray;
            Button button = new Button();
            button.Click += Button_Click;
            button.Text = "TestB";
            Panel panelTest = new Panel();
            panelTest.BackColor = Color.Red;
            //panelTest.ForeColor = Color.Red;
            this.panel1.Controls.Add(panelTest);
            this.panel1.Controls.Add(button);
            button.BringToFront();

            //this.panel1.SetChildIndex(1)
        }

        private void Button_Click(object sender, EventArgs e)
        {
            ((Button)sender).Text = "sasasas";
        }
    }
}
