using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E_Weather
{
    public partial class Frm_input : Form
    {
        public Frm_input()
        {
            InitializeComponent();
        }

        private void Btn_sure_Click(object sender, EventArgs e)
        {
            Frm_Main f1 = (Frm_Main)this.Owner;//将本窗体的拥有者强制设为Form1类的实例f1
            f1.city = this.TbInput.Text.ToString();
            this.Close();
        }
        private void Btn_reset_Click(object sender, EventArgs e)
        {
            this.TbInput.Text = "";
        }

        private void tB_year_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)//如果输入的是回车键
            {
                this.Btn_sure_Click(sender, e);//触发button事件
            }
        }
    }
}
