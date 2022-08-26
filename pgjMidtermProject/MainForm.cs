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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        public int memberID { get; set; }
        public string memberName
        {
            get
            {
                return linkLabelLogin.Text;
            }
            set
            {
                linkLabelLogin.Text = value;
            }
        }
        public string welcome
        {
            get
            {
                return lblWelcome.Text;
            }
            set
            {
                lblWelcome.Text = value;
            }
        }
        private void linkLabelLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog(this);
        }

        private void linkLabelRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegisterForm register = new RegisterForm();
            register.ShowDialog(this);
        }

        private void lblToSellerForm_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (linkLabelLogin.Text!="會員資料")
            {
                LoginForm loginForm = new LoginForm();
                loginForm.ShowDialog();
            }
            else
            {
                SellerForm sellerForm = new SellerForm();
                sellerForm.welcome = lblWelcome.Text;
                sellerForm.memberName = "會員資料";
                sellerForm.ShowDialog();
            }
            
        }
    }
}
