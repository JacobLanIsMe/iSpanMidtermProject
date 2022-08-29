using pgjMidtermProject.models;
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

namespace pgjMidtermProject
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        iSpanProjectEntities dbContext = new iSpanProjectEntities();
        private void Register_Load(object sender, EventArgs e)
        {
            var q = dbContext.RegionLists.Select(i => i.Region);
            comboBoxRegion.Items.AddRange(q.ToArray());
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            int memberID = -1;
            string account = txtAccount.Text;
            string name = txtName.Text;
            string email = txtEmail.Text;
            string phone = txtPhone.Text;
            string region = comboBoxRegion.Text;
            string address = txtAddress.Text;
            string biography = txtBiography.Text;
            string pwd = txtPwd.Text;
            string pwdConfirm = txtPwdConfirm.Text;
            Image image = pictureBoxMemPhoto.Image;
            if (!CFunctions.IsMemberInfoAllFill(memberID, account, name, email, phone, region, address, biography, pwd, pwdConfirm, image, radioButtonDomestic, radioButtonForeign))
                return;
            
            var regionID = dbContext.RegionLists.Where(i => i.Region == region).Select(i => i.RegionID).ToList()[0];

            MemoryStream ms = new MemoryStream();
            pictureBoxMemPhoto.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] bytes = ms.GetBuffer();

            bool TWorNOT;
            if (radioButtonDomestic.Checked)
                TWorNOT = true;
            else
                TWorNOT = false; 
            MemberAccount memberAccount = new MemberAccount
            {
                MemberAcc = account,
                MemberPw = pwd,
                TWorNOT = TWorNOT,
                RegionID = regionID,
                Phone = phone,
                Email = email,
                BackUpEmail = txtBackEmail.Text,
                Address = address,
                NickName = txtNickName.Text,
                Name = name,
                Birthday = dateTimePickerBirth.Value,
                Bio = biography,
                MemPic = bytes
            };
            dbContext.MemberAccounts.Add(memberAccount);
            try
            {
                dbContext.SaveChanges();
                MessageBox.Show($"恭喜 {txtName.Text} 成功加入會員 !");
                foreach (Form form in Application.OpenForms)
                {
                    if (form.GetType() == typeof(MainForm))
                    {
                        MainForm f = (MainForm)form;
                        f.welcome = $"你好，{txtName.Text}";
                        f.memberName = "會員資料";
                        f.memberID = dbContext.MemberAccounts.Where(i => i.MemberAcc == txtAccount.Text && i.MemberPw == txtPwd.Text).Select(i => i.MemberID).FirstOrDefault();
                    }
                    else if (form.GetType() == typeof(LoginForm))
                    {
                        LoginForm f = (LoginForm)form;
                        f.Close();
                    }
                }
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("註冊失敗，請再試一次。");
            }
            
        }
        private string filePath;
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog1.FileName;
                txtMemPhotoFile.Text = filePath;
                try
                {
                    pictureBoxMemPhoto.Image = Image.FromFile(filePath);
                }
                catch (Exception E)
                {
                    MessageBox.Show("圖片格式不符");
                }

            }
        }

        private void lblToMainForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
