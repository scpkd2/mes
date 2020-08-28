using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MES_PROJECT
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void 주문관리ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Order_mng od = new Order_mng();
            od.MdiParent = this;
            od.Show();
        }

        private void 발주등록ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Material_mng mt = new Material_mng();
            mt.MdiParent = this;
            mt.Show();
        }

        private void 작업지시관리ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Work_mng wk = new Work_mng();
            wk.MdiParent = this;
            wk.Show();
        }
    }
}
