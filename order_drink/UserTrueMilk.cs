using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace order_drink
{
    public partial class UserTrueMilk : UserControl
    {
        FormOrder fgrid;
        public UserTrueMilk()
        {
            InitializeComponent();
        }

        public UserTrueMilk(FormOrder fg)
        {
            InitializeComponent();
            this.fgrid = fg;
        }

        private void UserTrueMilk_Load(object sender, EventArgs e)
        {
            foreach (Control item in flowLayoutPanel1.Controls)
            {
                Button btn = BtnProduce.BtnSeries();
                btn.BackColor = Color.FromArgb(145, 238, 145);
                btn.Tag = item;

                BtnProduce.BtnText(btn, item);
                flowLayoutPanel1.Controls.Add(btn);

                btn.Click += Btn_Click;
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Button clickBtn = (Button)sender;
            Control menu = (Control)clickBtn.Tag;
            foreach (Control control in menu.Controls)
            {
                if (control.Tag.ToString() == "name")
                {
                    if (Globalvar.ice != "" || Globalvar.sweet != "")
                    {
                        Globalvar.AddDIV(control.Text, fgrid);
                        fgrid.DGV.Rows[Globalvar.i].Cells[5].Value = Globalvar.qty;
                    }
                    else
                    {
                        MessageBox.Show("請輸入甜度、冰塊");
                        return;
                    }
                    
                }
                

                else if (control.Tag.ToString() == "LPrice")
                {
                    fgrid.DGV.Rows[Globalvar.i].Cells[1].Value = control.Text;
                    Globalvar.LPrice = Convert.ToInt32(control.Text);
                    Globalvar.calcTotal();
                    fgrid.lblTotal.Text = Globalvar.orderTotal.ToString()+"元";
                    fgrid.DGV.Rows[Globalvar.i].Cells[6].Value = Globalvar.subTotal;
                    Globalvar.i++;
                }

                else if (control.Tag.ToString() == "botPrice")
                {
                    Globalvar.botPrice = Convert.ToInt32(control.Text);
                }
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

