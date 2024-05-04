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
    public partial class FormFruit : Form
    {
        Form2 fgrid;
        public FormFruit()
        {
            InitializeComponent();
        }

        public FormFruit(Form2 fg)
        {
            InitializeComponent();
            this.fgrid = fg;
        }

        private void Form3_Load(object sender, EventArgs e)
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

                    Globalvar.AddDIV(control.Text, fgrid);

                }

                if (control.Tag.ToString() == "LPrice")
                {
                    fgrid.dataGridView33.Rows[Globalvar.i].Cells[1].Value = control.Text;
                    Globalvar.unitPrice = Convert.ToInt32(control.Text);
                    Globalvar.i++;
                }
            }
        }

    }
}

