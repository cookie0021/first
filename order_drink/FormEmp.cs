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
    public partial class FormEmp : Form
    {
        string myDBConnectionString = "";
        string sex;
        FormManager manager;
        public FormEmp()
        {
            InitializeComponent();
        }

        public FormEmp(FormManager FM)
        {
            InitializeComponent();
            this.manager = FM;
        }

        private void FormDGV_Load(object sender, EventArgs e)
        {
            SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = @".";
            scsb.InitialCatalog = "mydb";
            scsb.IntegratedSecurity = true;
            myDBConnectionString = scsb.ToString();
        }

        void showRefresh()
        {
            SqlConnection con = new SqlConnection(myDBConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select ID, Name, telephone, address, sex, birth, salary from employees", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);           
            manager.dataGridView1.DataSource = dt;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            if (txtID.Text != "")
            {

                DialogResult result = MessageBox.Show("確定要修改?", "修改資料", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    SqlConnection con = new SqlConnection(myDBConnectionString);
                    con.Open();
                    if (radButtMan.Checked == true)
                    {
                        sex = "男";
                    }
                    else
                    {
                        sex = "女";
                    }
                    string strSQL = "update employees set Name=@NewName,telephone=@NewPhone,address=@NewAddress,sex=@NewSex,birth=@NewBirth,salary=@NewSalary where ID =@SelectID;";
                    SqlCommand cmd = new SqlCommand(strSQL, con);
                    if (radButtMan.Checked == true)
                    {
                        sex = "男";
                    }
                    else
                    {
                        sex = "女";
                    }
                    cmd.Parameters.AddWithValue("@SelectID", txtID.Text);
                    cmd.Parameters.AddWithValue("@NewName", txtName.Text);
                    cmd.Parameters.AddWithValue("@NewPhone", txtTel.Text);
                    cmd.Parameters.AddWithValue("@NewAddress", txtAddr.Text);
                    cmd.Parameters.AddWithValue("@NewSex", sex);
                    cmd.Parameters.AddWithValue("@NewBirth", dtpBirth.Value);
                    cmd.Parameters.AddWithValue("@NewSalary", txtSalary.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("修改成功!!");
                    con.Close();
                    showRefresh();
                    this.Close();

                }
                    
            }
            else
            {
                MessageBox.Show("空白資料不能修改!!");
            }
           
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(myDBConnectionString);
            con.Open();
            string strSQL = "insert into employees values(@NewName,@NewPhone,@NewAddress,@NewSex,@NewBirth,@NewSalary);";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            if (radButtMan.Checked == true)
            {
                sex = "男";
            }
            else
            {
                sex = "女";
            }
            cmd.Parameters.AddWithValue("@NewName", txtName.Text);
            cmd.Parameters.AddWithValue("@NewPhone", txtTel.Text);
            cmd.Parameters.AddWithValue("@NewAddress", txtAddr.Text);
            cmd.Parameters.AddWithValue("@NewSex", sex);
            cmd.Parameters.AddWithValue("@NewBirth", dtpBirth.Value);
            cmd.Parameters.AddWithValue("@NewSalary", txtSalary.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("新增成功!!");
            con.Close();
            showRefresh();
            this.Close();
        }      

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("確定要刪除?", "刪除資料", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                SqlConnection con = new SqlConnection(myDBConnectionString);
                con.Open();
                string strSQL = "delete from employees where ID = '" + txtID.Text + "'";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("刪除成功!!");
                con.Close();
                showRefresh();
                this.Close();
            }
                
        }

        private void txtSalary_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 | (int)e.KeyChar > 57) & (int)e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

       
    }
}
