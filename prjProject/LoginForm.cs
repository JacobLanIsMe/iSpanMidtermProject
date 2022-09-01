using prjProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjProject
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        iSpanProjectEntities dbContext = new iSpanProjectEntities();
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string account = txtAccount.Text;
            string pwd = txtPwd.Text;
            var q = dbContext.MemberAccounts.Where(i => i.MemberAcc == account && i.MemberPw == pwd).Select(i => i).ToList();
            if (q.Count > 0)
            {
                MessageBox.Show("成功登入");
                int memberID = q[0].MemberID;
                CFunctions.SendMemberInfoToEachForm(memberID);
                
                this.Close();
            }
            else
            {
                MessageBox.Show("登入失敗");
            }
        }
    }
}
