using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pgjMidtermProject
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        iSpanProjectEntities dbContext = new iSpanProjectEntities();
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.ShowDialog();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            
            var q = dbContext.MemberAccounts.Where(i => i.MemberAcc == txtAccount.Text && i.MemberPw == txtPwd.Text).Select(i => i).ToList();
            
            
            if (q.Count == 1)
            {
                MessageBox.Show("登入成功");
                foreach (Form i in Application.OpenForms)
                {
                    if (i.GetType() == typeof(MainForm))
                    {
                        MainForm f = (MainForm)i;
                        f.welcome = $"你好，{q[0].Name}";
                        f.memberName = "會員資料";
                        f.memberID = q[0].MemberID;
                    }
                }
                this.Close();
            }
            else if (q.Count > 1)
            {
                MessageBox.Show("有重複帳號");
            }
            else
            {
                MessageBox.Show("密碼錯誤");
            }
        }

        private void lblToMainForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
