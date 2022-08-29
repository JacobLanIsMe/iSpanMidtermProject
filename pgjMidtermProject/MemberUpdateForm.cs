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
    public partial class MemberUpdateForm : Form
    {
        public MemberUpdateForm()
        {
            InitializeComponent();
        }
        iSpanProjectEntities dbContext = new iSpanProjectEntities();
        int memberID;
        private void MemberUpdateForm_Load(object sender, EventArgs e)
        {
            CFunctions.MemberInfoFromMainForm(out string login, out string welcome, out string itemNumInCart, out memberID);
            linkLabelLogin.Text = "會員資料";
            lblWelcome.Text = welcome;
            var q1 = dbContext.RegionLists.Select(i => i.Region).ToArray();
            comboBoxRegion.Items.AddRange(q1);
            var q = dbContext.MemberAccounts.Where(i => i.MemberID == memberID).Select(i => i).FirstOrDefault();
            txtAccount.Text = q.MemberAcc;
            txtPwd.Text = q.MemberPw;
            comboBoxRegion.SelectedItem = q.RegionList.Region;
            txtPhone.Text = q.Phone;
            txtEmail.Text = q.Email;
            txtBackEmail.Text = q.BackUpEmail;
            txtAddress.Text = q.Address;
            txtNickName.Text = q.NickName;
            txtName.Text = q.Name;
            dateTimePickerBirth.Value = q.Birthday;
            txtBiography.Text = q.Bio;
            MemoryStream ms = new MemoryStream(q.MemPic);
            pictureBoxMemPhoto.Image = Image.FromStream(ms);
            if (q.TWorNOT) radioButtonDomestic.Checked = true;
            else radioButtonForeign.Checked = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("請確認輸入正確資料", "是否正確", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
                
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
                var q = dbContext.MemberAccounts.Where(i => i.MemberID == memberID).Select(i => i).FirstOrDefault();
                q.MemberAcc = account;
                q.MemberPw = pwd;
                q.TWorNOT = TWorNOT;
                q.RegionID = regionID;
                q.Phone = "0956789789";
                q.Email = email;
                q.BackUpEmail = txtBackEmail.Text;
                q.Address = address;
                q.NickName = txtNickName.Text;
                q.Name = name;
                q.Birthday = dateTimePickerBirth.Value;
                q.Bio = biography;
                q.MemPic = bytes;
                dbContext.SaveChanges();
            }
            else
            {
                return;
            }

        }
    }
}
