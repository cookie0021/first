using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Data.SqlClient;
namespace order_drink
{
    public partial class FormOrder : Form
    {
        string myDBConnectionString = "";
        public FormOrder()
        {
            InitializeComponent();

        }
        
        

        private void Form2_Load(object sender, EventArgs e)
        {
            lblTel.Text = Globalvar.tel;

            SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = @".";
            scsb.InitialCatalog = "mydb";
            scsb.IntegratedSecurity = true;
            myDBConnectionString = scsb.ToString();

            //創建產品系列按鈕
            foreach (Control item in flowLayoutPanel1.Controls)
            {                
                Button btn = BtnProduce.BtnSeries();
                btn.Tag = item;

                BtnProduce.BtnText(btn, item);
                flowLayoutPanel1.Controls.Add(btn);

                btn.Click += Btn_Click;
            }

            //創建杯子,加料按鈕
            foreach (Control item in flowLayoutPanel8.Controls)
            {
                Button btn = BtnProduce.BtnItems();
                btn.BackColor = Color.FromArgb(255, 125, 135); ;
                btn.Tag = item;

                foreach (Control control in item.Controls)
                {
                    if (control.Tag.ToString() == "L")
                    {
                        btn.Text = control.Text;
                    }
                    else if (control.Tag.ToString() == "bottle")
                    {
                        btn.Text = control.Text;
                    }
                    else if (control.Tag.ToString() == "topping")
                    {
                        btn.Text = control.Text;
                    }
                }
                flowLayoutPanel8.Controls.Add(btn);

                btn.Click += BtnSizeAndTopping_Click;

            }

            //創建甜度按鈕
            foreach (Control item in flowLayoutPanel15.Controls)
            {
                Button btn = BtnProduce.BtnItems();
                btn.BackColor = Color.FromArgb(255, 125, 255); 
                btn.Tag = item;

                BtnProduce.BtnText(btn, item);
                flowLayoutPanel15.Controls.Add(btn);

                btn.Click += BtnSweet_Click;
            }

            //創建冰塊按鈕
            foreach (Control item in flowLayoutPanel22.Controls)
            {
                Button btn = BtnProduce.BtnItems();
                btn.BackColor = Color.FromArgb(125,255,255);
                btn.Tag = item;

                BtnProduce.BtnText(btn, item);
                flowLayoutPanel22.Controls.Add(btn);

                btn.Click += BtnIce_Click;
            }

            //創建數量按鈕
            for (int i = 0; i < 10; i++)
            {
                Button btn = BtnProduce.BtnItems();
                btn.Size = new Size(45, 40);
                btn.BackColor = Color.FromArgb(224, 224, 224);
                btn.Text = i.ToString();
                flowLPqty.Controls.Add(btn);
                btn.Click += BtnQty_Click;
            }
        }

        //點擊系列按鈕換頁
        private void Btn_Click(object sender, EventArgs e)
        {

            Button clickBtn = (Button)sender;
            Control menu = (Control)clickBtn.Tag;
            foreach (Control control in menu.Controls)
            {
                if (control.Tag.ToString() == "name")
                {
                    switch (control.Text)
                    {
                        case "鮮果茶":                            
                            UserFruit U1 = new UserFruit(this);
                            Globalvar.itemsSeries = control.Text;
                            U1.Show();
                            panel1.Controls.Clear();
                            panel1.Controls.Add(U1);
                            break;

                        case "原味茶":
                            UserOriginal U2 = new UserOriginal(this);
                            Globalvar.itemsSeries = control.Text;
                            U2.Show();
                            panel1.Controls.Clear();
                            panel1.Controls.Add(U2);
                            break;

                        case "奶茶系列":
                            UserMilk U3 = new UserMilk(this);
                            Globalvar.itemsSeries = control.Text;
                            U3.Show();
                            panel1.Controls.Clear();
                            panel1.Controls.Add(U3);
                            break;

                        case "鮮奶茶系列":
                            UserTrueMilk U4 = new UserTrueMilk(this);
                            Globalvar.itemsSeries = control.Text;
                            U4.Show();
                            panel1.Controls.Clear();
                            panel1.Controls.Add(U4);
                            break;

                        case "消暑系列":
                            UserCoolDown U5 = new UserCoolDown(this);
                            Globalvar.itemsSeries = control.Text;
                            U5.Show();
                            panel1.Controls.Clear();
                            panel1.Controls.Add(U5);
                            break;


                        case "獨家特調":
                            UserExclusive U6 = new UserExclusive(this);
                            Globalvar.itemsSeries = control.Text;
                            U6.Show();
                            panel1.Controls.Clear();
                            panel1.Controls.Add(U6);
                            break;

                    }

                }
            }
        }

        //加入甜度
        private void BtnSweet_Click(object sender, EventArgs e)
        {
            
            Button clickBtn = (Button)sender;
            Control Sweet = (Control)clickBtn.Tag;
            foreach (Control control in Sweet.Controls)
            {
                if (control.Tag.ToString() == "name")
                {
                    if (Globalvar.i < 1) { return; }                 
                    else
                    {
                        DGV.Rows[Globalvar.i - 1].Cells[2].Value =control.Text;
                        Globalvar.sweet = control.Text;                     
                    }
                }              
            }
        }

        //加入冰塊
        private void BtnIce_Click(object sender, EventArgs e)
        {
            Button clickBtn = (Button)sender;
            Control Sweet = (Control)clickBtn.Tag;
            foreach (Control control in Sweet.Controls)
            {
                if (control.Tag.ToString() == "name")
                {
                    if (Globalvar.i < 1) { return; }                   
                    else
                    {
                        DGV.Rows[Globalvar.i - 1].Cells[3].Value = control.Text;
                        Globalvar.ice = control.Text;
                    }                                   
                }
            }
        }

        //L杯、瓶裝、加料
        private void BtnSizeAndTopping_Click(object sender, EventArgs e)
        {
            if (Globalvar.i < 1 ) { return; }
            int count = Globalvar.listSubTotal.Count - 1;
            Button clickBtn = (Button)sender;
            Control Sweet = (Control)clickBtn.Tag;
            foreach (Control control in Sweet.Controls)
            {
                if (control.Tag.ToString() == "L")
                {
                    Globalvar.size = "L";
                    DGV.Rows[Globalvar.i - 1].Cells[0].Value = Globalvar.itmeName + "(L)";
                    DGV.Rows[Globalvar.i - 1].Cells[1].Value = Globalvar.LPrice;
                    if (Globalvar.qty == "") { return; }
                    Globalvar.listSubTotal.RemoveAt(count);
                   
                    Globalvar.calcTotal();
                    DGV.Rows[Globalvar.i-1].Cells[6].Value = Globalvar.subTotal;
                    lblTotal.Text = Globalvar.orderTotal.ToString()+"元";
                }


                else if (control.Tag.ToString() == "bottle")
                {
                    if (Globalvar.botPrice == 0) { return; }
                    Globalvar.size = "bottle";
                    DGV.Rows[Globalvar.i - 1].Cells[0].Value = Globalvar.itmeName + "(瓶)";
                    DGV.Rows[Globalvar.i - 1].Cells[1].Value = Globalvar.botPrice;
                    if (Globalvar.qty == "") { return; }
                    Globalvar.listSubTotal.RemoveAt(count);
                    Globalvar.calcTotal();
                    DGV.Rows[Globalvar.i-1].Cells[6].Value = Globalvar.subTotal;
                    lblTotal.Text = Globalvar.orderTotal.ToString()+"元";
                }

                else if (control.Tag.ToString() == "topping")
                {
                    FormToppings topping = new FormToppings(this );
                    topping.Show();
                }
            }
        }

        //輸入數量,計算總價

        private void BtnQty_Click(object sender, EventArgs e)
        {
            int L = Globalvar.listSubTotal.Count - 1;

            if (Globalvar.i < 1)  return; 
            
            else
            {
                Button btn = (Button)sender;
                if (Globalvar.k == 0  && btn.Text != "0")
                {
                    Globalvar.listSubTotal.RemoveAt(L);                                    
                    Globalvar.qty = btn.Text;
                    Globalvar.k++;
                }
                else
                {
                    Globalvar.qty += btn.Text;
                }              
               
                if ( Globalvar.qty.Length < 5)
                {                   
                    DGV.Rows[Globalvar.i - 1].Cells[5].Value = Globalvar.qty;                   
                    if (Globalvar.qty.Length >1)
                    {                        
                        Globalvar.listSubTotal.RemoveAt(L);                      
                    }
                    Globalvar.calcTotal();
                    DGV.Rows[Globalvar.i - 1].Cells[6].Value = Globalvar.subTotal;
                    lblTotal.Text = Globalvar.orderTotal.ToString() + "元";
                }
                
            }
        }

        //清除數量
        private void qtyClear_Click(object sender, EventArgs e)
        {
            int L = Globalvar.listSubTotal.Count - 1;
            Globalvar.listSubTotal.RemoveAt(L);
            Globalvar.listSubTotal.Add(0);
            DGV.Rows[Globalvar.i - 1].Cells[5].Value = "";
            DGV.Rows[Globalvar.i - 1].Cells[6].Value = "";
            Globalvar.qty = "";
            Globalvar.orderTotal = 0;

            foreach (int item in Globalvar.listSubTotal)
            {
                Globalvar.orderTotal += item;
            }           
            lblTotal.Text = Globalvar.orderTotal.ToString()+"元";

        }         

        //移除所選品項
        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            Globalvar.orderTotal = 0;
            int RowIndex = DGV.CurrentRow.Index;
            try
            {
                if(RowIndex == DGV.Rows.Count -2)
                {
                    Globalvar.ice = "Cancel current item";
                    Globalvar.sweet = "Cancel current item";
                }
                DGV.Rows.RemoveAt(RowIndex);
                Globalvar.listSubTotal.RemoveAt(RowIndex);
                foreach (int item in Globalvar.listSubTotal)
                {
                    Globalvar.orderTotal += item;
                }
                lblTotal.Text = Globalvar.orderTotal.ToString()+"元";
                Globalvar.i--;
                Globalvar.purchaserOrderList.RemoveAt(RowIndex);
                
            }
            catch { return; }                    
        }

        //取消訂單
        private void cancelOrder_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("確定要取消訂單?", "取消", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Globalvar.purchaserOrderList.Clear();
                Globalvar.listItems.Clear();
                Globalvar.listSubTotal.Clear();
                DGV.Rows.Clear();
                Globalvar.i = 0;
                Globalvar.orderTotal = 0;
                lblTotal.Text = "";

            }
        }

        //結帳
        private void button1_Click(object sender, EventArgs e)
        {
            
            DialogResult result = MessageBox.Show("確定結帳?", "結帳", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Globalvar.listAdd();

                if ((string)Globalvar.purchaserOrderList[Globalvar.purchaserOrderList.Count-1][2] == "" ||
                    (string)Globalvar.purchaserOrderList[Globalvar.purchaserOrderList.Count - 1][3] == "")
                {
                    MessageBox.Show("甜度、冰塊沒有輸入完整");
                    return;
                }
                
                foreach (ArrayList orderItems in Globalvar.purchaserOrderList)
                {
                    string itmeName = (string)orderItems[0];
                    int unitPrice = (int)orderItems[1];
                    string Sweet = (string)orderItems[2];
                    string Ice = (string)orderItems[3];
                    string toppings = (string)orderItems[4];
                    string qty = (string)orderItems[5];
                    int subPrice = (int)orderItems[6];                    
                    SqlConnection con = new SqlConnection(myDBConnectionString);
                    con.Open();
                    string strSQL = "insert into orderRecord values(@Phone,@ItmeName,@UnitPrice,@Sweet,@Ice,@Toppings,@Qty,@SubPrice,@Date)";
                    SqlCommand cmd = new SqlCommand(strSQL, con);
                    cmd.Parameters.AddWithValue("@Phone", lblTel.Text);
                    cmd.Parameters.AddWithValue("@ItmeName", itmeName);
                    cmd.Parameters.AddWithValue("@UnitPrice", unitPrice);
                    cmd.Parameters.AddWithValue("@Sweet", Sweet);
                    cmd.Parameters.AddWithValue("@Ice", Ice);
                    cmd.Parameters.AddWithValue("@Toppings", toppings);
                    cmd.Parameters.AddWithValue("@Qty", qty);
                    cmd.Parameters.AddWithValue("@SubPrice", subPrice);
                    cmd.Parameters.AddWithValue("@Date", DateTime.Now);
                   
                    cmd.ExecuteNonQuery();                    
                    con.Close();
                    con.Dispose();
                }
                Globalvar.purchaserOrderList.Clear();
                Globalvar.listItems.Clear();
                Globalvar.listSubTotal.Clear();
                DGV.Rows.Clear();
                Globalvar.i = 0;
                Globalvar.orderTotal = 0;
                lblTotal.Text = "";
                MessageBox.Show("結帳成功!!","成功");
            }
        }     

      

        private void dataGridView33_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Rectangle rectangle = new Rectangle(
            e.RowBounds.Location.X,
            e.RowBounds.Location.Y,
            DGV.RowHeadersWidth - 4,
            e.RowBounds.Height);

            TextRenderer.DrawText(e.Graphics,
                   (e.RowIndex + 1).ToString(),
                   DGV.RowHeadersDefaultCellStyle.Font,
                   rectangle,
                   DGV.RowHeadersDefaultCellStyle.ForeColor,
                   TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        private void FormOrder_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

