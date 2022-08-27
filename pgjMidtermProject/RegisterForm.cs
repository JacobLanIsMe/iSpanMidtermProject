﻿using System;
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
            if (txtAccount.Text == "" || txtName.Text == "" || txtEmail.Text == "" || txtPhone.Text == "" || comboBoxRegion.Text == "" || txtAddress.Text == "" || txtBiography.Text == "" || pictureBoxMemPhoto.Image == null)
            {
                MessageBox.Show("資料未填妥");
                return;
            }
            var q = dbContext.MemberAccounts.Where(i => i.MemberAcc == txtAccount.Text).Select(i => i).ToList();
            if (q.Count > 0)
            {
                MessageBox.Show("此帳號已被註冊過了");
            }

            if (txtPwd.Text != txtPwdConfirm.Text)
            {
                MessageBox.Show("密碼輸入不同");
                txtPwd.Focus();
                return;
            }
            
            string region = comboBoxRegion.Text;
            var regionID = dbContext.RegionLists.Where(i => i.Region == region).Select(i => i.RegionID).ToList()[0];

            MemoryStream ms = new MemoryStream();
            pictureBoxMemPhoto.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] bytes = ms.GetBuffer();

            MemberAccount memberAccount = new MemberAccount
            {
                MemberAcc = txtAccount.Text,
                MemberPw = txtPwd.Text,
                TWorNOT = radioButtonDomestic.Checked,
                RegionID = regionID,
                Phone = txtPhone.Text,
                Email = txtEmail.Text,
                BackUpEmail = txtBackEmail.Text,
                Address = txtAddress.Text,
                NickName = txtNickName.Text,
                Name = txtName.Text,
                Birthday = dateTimePickerBirth.Value,
                Bio = txtBiography.Text,
                MemPic = bytes
            };
            dbContext.MemberAccounts.Add(memberAccount);
            try
            {
                dbContext.SaveChanges();
                MessageBox.Show($"恭喜 {txtName.Text} 成功加入會員 !");
                foreach (Form f in Application.OpenForms)
                {
                    if (f.GetType() == typeof(MainForm))
                    {
                        MainForm mainForm = (MainForm)f;
                        mainForm.welcome = $"你好，{txtName.Text}";
                        mainForm.memberName = "會員資料";
                        mainForm.memberID = dbContext.MemberAccounts.Where(i => i.MemberAcc == txtAccount.Text && i.MemberPw == txtPwd.Text).Select(i => i.MemberID).FirstOrDefault();
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