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
    public partial class ItemsInCartForm : Form
    {
        public ItemsInCartForm()
        {
            InitializeComponent();
        }

        private void ItemsInCartForm_Load(object sender, EventArgs e)
        {
            CFunctions.MemberInfoFromMainForm(out string login, out string welcome, out string itemNumInCart);
            lblWelcome.Text = welcome;
            linkLabelLogin.Text = login;
            lblItemNumInCart.Text = itemNumInCart;
        }
    }
}
