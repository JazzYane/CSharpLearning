﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestWindowsFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Panel paneltest1 = new Panel();
            Panel paneltest2 = new Panel();
            paneltest1.BackColor = Color.Red;
            paneltest2.BackColor = Color.Blue;
            this.panel1.Controls.Add(paneltest1);
            this.panel1.Controls.Add(paneltest2);
            
        }
    }
}
