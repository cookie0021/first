
namespace order_drink
{
    partial class FormUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.openShop = new System.Windows.Forms.Button();
            this.employee = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // openShop
            // 
            this.openShop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.openShop.Font = new System.Drawing.Font("微軟正黑體", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.openShop.Location = new System.Drawing.Point(63, 57);
            this.openShop.Name = "openShop";
            this.openShop.Size = new System.Drawing.Size(205, 90);
            this.openShop.TabIndex = 0;
            this.openShop.Text = "開始營業";
            this.openShop.UseVisualStyleBackColor = false;
            this.openShop.Click += new System.EventHandler(this.OpenShop_Click);
            // 
            // employee
            // 
            this.employee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.employee.Font = new System.Drawing.Font("微軟正黑體", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.employee.Location = new System.Drawing.Point(63, 193);
            this.employee.Name = "employee";
            this.employee.Size = new System.Drawing.Size(205, 90);
            this.employee.TabIndex = 1;
            this.employee.Text = "會員資料";
            this.employee.UseVisualStyleBackColor = false;
            // 
            // FormUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(321, 361);
            this.Controls.Add(this.employee);
            this.Controls.Add(this.openShop);
            this.Name = "FormUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormUI";
            this.Load += new System.EventHandler(this.FormUI_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button openShop;
        private System.Windows.Forms.Button employee;
    }
}