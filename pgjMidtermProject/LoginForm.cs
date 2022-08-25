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
            string q = "";
            try
            {
                q = dbContext.MemberAccounts.Where(i => i.Email == txtAccount.Text).Select(i => i.MemberPw).FirstOrDefault();
            }
            catch(Exception ex)
            {
                MessageBox.Show("帳號錯誤");
            }
            if (q == txtPwd.Text)
            {
                MessageBox.Show("登入成功");
            }
            else
            {
                MessageBox.Show("密碼錯誤");
            }
        }
    }
}
