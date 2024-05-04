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
    public partial class FormRegister : Form
    {
        string myDBConnectionString = "";
        string sex = "";
        public FormRegister()
        {
            InitializeComponent();
        }

        private void FormRegister_Load(object sender, EventArgs e)
        {
            SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = @".";
            scsb.InitialCatalog = "mydb";
            scsb.IntegratedSecurity = true;
            myDBConnectionString = scsb.ToString();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtTel.Text != "" && txtEmail.Text != "" && 
                txtPsw.Text != "" && (radButtMan.Checked != false || radButtWoman.Checked != false))
            {
                if (txtTel.Text.Length == 10)
                {
                    SqlConnection con = new SqlConnection(myDBConnectionString);
                    con.Open();
                    string strSQL = "insert into member values(@NewPhone,@NewEmail,@NewPsw,@NewSex,@NewBirth)";
                    SqlCommand cmd = new SqlCommand(strSQL, con);
                    if (radButtMan.Checked == true)
                    {
                        sex = "男";
                    }
                    else
                    {
                        sex = "女";
                    }
                    cmd.Parameters.AddWithValue("@NewPhone", txtTel.Text);
                    cmd.Parameters.AddWithValue("@NewPsw", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@NewEmail", txtPsw.Text);
                    cmd.Parameters.AddWithValue("@NewSex", sex);
                    cmd.Parameters.AddWithValue("@NewBirth", dtpBirth.Value);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("註冊成功!!");
                    con.Close();
                    FormLogin login = new FormLogin();
                    login.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("號碼格式錯誤");
                }
            }
           else
            {
                MessageBox.Show("資料欄不能空白");
            }
            
        }

        private void txtTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(((int)e.KeyChar<48 || (int)e.KeyChar>57) && (int)e.KeyChar != 8)
            {
                e.Handled = true;
            }
            
        }

     
    }
}
