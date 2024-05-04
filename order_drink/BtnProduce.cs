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
   public static class BtnProduce
    {
        //產品系列
        public static Button BtnSeries()
        {
            Button btn = new Button();            
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 1;
            btn.Size = new Size(120, 60);
            btn.BackColor = Color.FromArgb(255, 240, 60);
            btn.Margin = new Padding(0);
            btn.Font = new Font("微軟正黑體", 15);        
            return btn;

        }

        //商品
        public static Button BtnItems()
        {
            Button btn = new Button();
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 1;
            btn.Size = new Size(120, 40);
            btn.Margin = new Padding(0);
            btn.Font = new Font("微軟正黑體", 15);
            return btn;

        }

        //按鈕的Text
        public static void BtnText(Button btn, Control item)
        {
            foreach (Control control in item.Controls)
            {
                if (control.Tag.ToString() == "name" || control.Tag.ToString()=="clear" || control.Tag.ToString() == "yes")
                {
                    btn.Text = control.Text;
                }
            }

        }
    }
}
