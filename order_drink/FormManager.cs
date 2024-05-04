using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace order_drink
{
    public partial class FormManager : Form
    {
        string myDBConnectionString = "";
        SqlDataAdapter sda;
        DataTable dt;
        List<string> listComSelect = new List<string>();
        string strSQL;




        public FormManager()
        {
            InitializeComponent();
        }

        private void FormManager_Load(object sender, EventArgs e)
        {
            SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = @".";
            scsb.InitialCatalog = "mydb";
            scsb.IntegratedSecurity = true;
            myDBConnectionString = scsb.ToString();
        }

     

        private void button1_Click_1(object sender, EventArgs e)
        {
            listComSelect.Clear();
            comboBox1.Items.Clear();
            listComSelect.Add("姓名");
            listComSelect.Add("電話");
            foreach(string items in listComSelect)
            {
                comboBox1.Items.Add(items);
            }
            btnSearch.Enabled = true;
            comboBox1.SelectedIndex = 0;

            SqlConnection con = new SqlConnection(myDBConnectionString);
            sda = new SqlDataAdapter("select ID, Name, telephone, address, sex, birth, salary from employees", con);
            dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            lblShow.Text = "員工資料";
        }  

        private void btnShowMember_Click(object sender, EventArgs e)
        {
            listComSelect.Clear();
            comboBox1.Items.Clear();           
            listComSelect.Add("電話");
          
            foreach (string items in listComSelect)
            {
                comboBox1.Items.Add(items);
            }
            comboBox1.SelectedIndex = 0;
            btnSearch.Enabled = true;
            SqlConnection con = new SqlConnection(myDBConnectionString);
            sda = new SqlDataAdapter("select *from member ", con);
            dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            lblShow.Text = "會員資料";
        }

        private void btnShowItems_Click(object sender, EventArgs e)
        {
            listComSelect.Clear();
            comboBox1.Items.Clear();
            listComSelect.Add("商品名稱");
            listComSelect.Add("L杯價格");
            listComSelect.Add("瓶裝價格");
            foreach (string items in listComSelect)
            {
                comboBox1.Items.Add(items);
            }
            comboBox1.SelectedIndex = 0;
            btnSearch.Enabled = true;
            SqlConnection con = new SqlConnection(myDBConnectionString);
            sda = new SqlDataAdapter("select *from Items ", con);
            dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            lblShow.Text = "商品資料";
        }

        private void FormManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (lblShow.Text == "員工資料")
            {
                FormEmp info = new FormEmp(this);
                try
                {
                    info.txtID.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    info.txtName.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    info.txtTel.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    info.txtAddr.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
                    if (this.dataGridView1.CurrentRow.Cells[4].Value.ToString() == "男")
                    {

                        info.radButtMan.Checked = true;
                    }
                    else
                    {
                        info.radButtWoman.Checked = true;
                    }
                    info.txtSalary.Text = this.dataGridView1.CurrentRow.Cells[6].Value.ToString();
                    info.dtpBirth.Value = Convert.ToDateTime(this.dataGridView1.CurrentRow.Cells[5].Value.ToString());

                }

                catch
                {
                    return;
                }

                finally
                {
                    info.ShowDialog();
                }


            }

            else if (lblShow.Text == "會員資料")
            {
                FormMember info = new FormMember(this);
                try
                {
                    info.txtID.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    info.txtPhone.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    info.txtTel.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    info.txtEmail.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
                    if (this.dataGridView1.CurrentRow.Cells[4].Value.ToString() == "男")
                    {

                        info.radButtMan.Checked = true;
                    }
                    else
                    {
                        info.radButtWoman.Checked = true;
                    }

                    info.dtpBirth.Value = Convert.ToDateTime(this.dataGridView1.CurrentRow.Cells[5].Value.ToString());

                }

                catch
                {
                    return;
                }

                finally
                {
                    info.ShowDialog();
                }
            }

            else if (lblShow.Text == "商品資料")
            {
                FormItems info = new FormItems(this);
                try
                {
                    info.txtNO.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    info.txtName.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    info.txtLPrice.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    info.txtBotPrice.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
                }

                catch
                {
                    return;
                }

                finally
                {
                    info.ShowDialog();
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
         
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string selectItem = comboBox1.SelectedItem.ToString();
           
            switch (selectItem)
            {
                case "姓名":
                    selectItem = "name";                  
                    strSQL = "select* from employees where (" + selectItem + " like @SearchString); ";                                
                                   
                    break;

                case "電話":                  
                    selectItem = "telephone";
                    if (lblShow.Text == "員工資料")
                    {
                        strSQL = "select* from  employees where (" + selectItem + " like @SearchString); ";
                    }
                    else
                    {
                        strSQL = "select* from  member where (" + selectItem + " like @SearchString); ";
                    }
                    break;

                case "商品名稱":
                    selectItem = "name";
                    strSQL = "select* from Items where (" + selectItem + " like @SearchString); ";
                    break;

                case "L杯價格":
                    selectItem = "LPrice";
                    strSQL = "select* from Items where (" + selectItem + " like @SearchString); ";
                    break;

                case "瓶裝價格":
                    selectItem = "bottlePrice";
                    strSQL = "select* from Items where (" + selectItem + " like @SearchString); ";
                    break;               
            }

         
        

            if (txtSearch.Text != "")
            {
               

                SqlConnection con = new SqlConnection(myDBConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@SearchString", "%" + txtSearch.Text + "%");
                SqlDataReader reader = cmd.ExecuteReader();
                int i = 0;
                if (reader.HasRows)
                {
                    dt = new DataTable();
                    dt.Load(reader);
                    dataGridView1.DataSource = dt;
                    i++;
                }

                if (i <= 0)
                {
                    MessageBox.Show("查無資料");
                }
                reader.Close();
                con.Close();            
           
            }
            else
            {
                MessageBox.Show("請輸入搜尋關鍵字");
            }


        }
    }
}