using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjProject
{
    public partial class SelectedProductForm : Form
    {
        public SelectedProductForm()
        {
            InitializeComponent();
        }
        public int productID { get; set; }
        iSpanProjectEntities dbContext = new iSpanProjectEntities();
        private void SelectedProductForm_Load(object sender, EventArgs e)
        {
            var q = dbContext.ProductPics.Where(i => i.ProductID == productID).Select(i => i.picture).ToList();
            MemoryStream ms = new MemoryStream(q[0]);
            pbProductPhoto.Image = Image.FromStream(ms);
            
            for (int i = 0; i < q.ToList().Count; i++)
            {
                MemoryStream ms1 = new MemoryStream(q[i]);
                productPhotoList.Add(Image.FromStream(ms1));
                PictureBox pb = new PictureBox();
                pb.Image = Image.FromStream(ms1);
                pb.SizeMode = PictureBoxSizeMode.StretchImage;
                pb.Name = $"pb{i}";
                flowLayoutPanel1.Controls.Add(pb);
                pb.MouseEnter += ProductPhoto_MouseEnter;
                pb.MouseLeave += Pb_MouseLeave;
            }
        }

        private void Pb_MouseLeave(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void ProductPhoto_MouseEnter(object sender, EventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            pbProductPhoto.Image = pb.Image;
            timer1.Stop();
        }

        List<Image> productPhotoList = new List<Image>();
        private int productPhotoIndex = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            productPhotoIndex++;
            if (productPhotoIndex >= productPhotoList.Count)
                productPhotoIndex = 0;
            pbProductPhoto.Image = productPhotoList[productPhotoIndex];
        }

       
    }
}
