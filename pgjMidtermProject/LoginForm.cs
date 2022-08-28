using pgjMidtermProject.models;
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
                //var q2 = dbContext.Orders.Where(i => i.MemberID == q[0].MemberID && i.StatusID == 1).Select(i => i).ToList();
                var q2 = from i in dbContext.Orders.AsEnumerable()
                         where i.MemberID == q[0].MemberID && i.StatusID == 1
                         select i;
                int itemCount = 0;
                if (q2.ToList().Count > 0)
                {
                    itemCount = q2.ToList().Count;
                }
                MessageBox.Show("登入成功");
                foreach (Form i in Application.OpenForms)
                {
                    if (i.GetType() == typeof(MainForm))
                    {
                        MainForm f = (MainForm)i;
                        f.welcome = $"你好，{q[0].Name}";
                        f.memberName = "會員資料";
                        f.memberID = q[0].MemberID;
                        //f.itemNumInCart = itemCount.ToString();
                        CFunctions.ShowTheCountOfItemsInCart(q[0].MemberID);
                    }
                    else if (i.GetType() == typeof(BrowseItemsForm))
                    {
                        BrowseItemsForm f = (BrowseItemsForm)i;
                        f.welcome = $"你好，{q[0].Name}";
                        f.memberName = "會員資料";
                        //f.itemNumInCart = itemCount.ToString();
                        CFunctions.ShowTheCountOfItemsInCart(q[0].MemberID);
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
