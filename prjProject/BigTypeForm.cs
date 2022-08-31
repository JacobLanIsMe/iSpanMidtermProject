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
    public partial class BigTypeForm : Form
    {
        public BigTypeForm()
        {
            InitializeComponent();
        }
        public int bigTypeID { get; set; }
        iSpanProjectEntities dbContext = new iSpanProjectEntities();
        private void BigTypeForm_Load(object sender, EventArgs e)
        {
            var q = dbContext.SmallTypes.Where(i => i.BigTypeID == bigTypeID).Select(i => i.SmallTypeName);
            foreach (var p in q)
            {
                LinkLabel linkLabel = new LinkLabel();
                linkLabel.Text = p;
                linkLabel.LinkColor = Color.Black;
                linkLabel.Margin = new Padding(0, 0, 0, 20);
                flpSmallType.Controls.Add(linkLabel);
                linkLabel.Click += SmallType_Click;
            }
        }

        private void SmallType_Click(object sender, EventArgs e)
        {
            
        }
    }
}
