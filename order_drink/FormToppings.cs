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
    public partial class FormToppings : Form
    {
        FormOrder fgrid;
       
        public FormToppings()
        {
            InitializeComponent();
        }


        public FormToppings(FormOrder fg)
        {
            InitializeComponent();
            this.fgrid = fg;
            
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            
            lblTopping.Text = Globalvar.toppings;

            foreach (Control item in flowLayoutPanel1.Controls)
            {
                Button btn = new Button();
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 1;
                btn.Size = new Size(126, 70);
                btn.Margin = new Padding(0);
                btn.Font = new Font("微軟正黑體", 15);
                btn.BackColor = Color.FromArgb(255, 192, 128);
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
                    Globalvar.toppings += control.Text+" ";
                    lblTopping.Text = Globalvar.toppings;
                }


                else if (control.Tag.ToString() == "Price")
                {
                    Globalvar.toppingPrice += Convert.ToInt32(control.Text);
                }

                else if (control.Tag.ToString() == "clear")
                {
                    lblTopping.Text = "";
                    Globalvar.toppingPrice = 0;
                    Globalvar.toppings = "";



                }

                else if (control.Tag.ToString() == "yes")
                {
                    
                    int L = Globalvar.listSubTotal.Count - 1;
                    fgrid.DGV.Rows[Globalvar.i - 1].Cells[4].Value = Globalvar.toppings;
                    Globalvar.listSubTotal.RemoveAt(L);
                    Globalvar.calcTotal();
                    fgrid.DGV.Rows[Globalvar.i - 1].Cells[6].Value = Globalvar.subTotal.ToString();
                    fgrid.lblTotal.Text = Globalvar.orderTotal.ToString()+"元";

                    this.Close();
                }
            }

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
