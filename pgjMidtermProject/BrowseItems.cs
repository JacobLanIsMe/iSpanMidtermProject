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
    public partial class BrowseItems : Form
    {
        public BrowseItems()
        {
            InitializeComponent();
        }

        public int productID { get; set; }

        private void BrowseItems_Load(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(MainForm))
                {
                    MainForm f = (MainForm)form;
                    lblWelcome.Text = f.welcome;
                    linkLabelLogin.Text = "會員資料";
                }
            }

        }
    }
}
