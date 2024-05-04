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
    public partial class FormUI : Form
    {
        public FormUI()
        {
            InitializeComponent();
        }

        private void OpenShop_Click(object sender, EventArgs e)
        {
            FormOrder f2 = new FormOrder();
            f2.ShowDialog();
            this.Hide();
              
        }

        private void FormUI_Load(object sender, EventArgs e)
        {

        }
    }
}
