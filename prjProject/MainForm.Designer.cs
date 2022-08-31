
namespace prjProject
{
    partial class MainForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.linkLabelLogin = new System.Windows.Forms.LinkLabel();
            this.linkLabelRegister = new System.Windows.Forms.LinkLabel();
            this.pbCart = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.lblToSellerForm = new System.Windows.Forms.LinkLabel();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.flpBigType = new System.Windows.Forms.FlowLayoutPanel();
            this.flpProduct = new System.Windows.Forms.FlowLayoutPanel();
            this.lblProductNumInCart = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.splitContainer1.Panel1.Controls.Add(this.lblProductNumInCart);
            this.splitContainer1.Panel1.Controls.Add(this.lblWelcome);
            this.splitContainer1.Panel1.Controls.Add(this.linkLabelLogin);
            this.splitContainer1.Panel1.Controls.Add(this.linkLabelRegister);
            this.splitContainer1.Panel1.Controls.Add(this.pbCart);
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.Controls.Add(this.textBox1);
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox1);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.linkLabel2);
            this.splitContainer1.Panel1.Controls.Add(this.lblToSellerForm);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1914, 1018);
            this.splitContainer1.SplitterDistance = 267;
            this.splitContainer1.SplitterWidth = 8;
            this.splitContainer1.TabIndex = 0;
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("標楷體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblWelcome.Location = new System.Drawing.Point(1808, 30);
            this.lblWelcome.Margin = new System.Windows.Forms.Padding(22, 0, 7, 0);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(102, 42);
            this.lblWelcome.TabIndex = 19;
            this.lblWelcome.Text = "歡迎";
            // 
            // linkLabelLogin
            // 
            this.linkLabelLogin.AutoSize = true;
            this.linkLabelLogin.Font = new System.Drawing.Font("標楷體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.linkLabelLogin.ForeColor = System.Drawing.Color.Black;
            this.linkLabelLogin.LinkColor = System.Drawing.Color.Black;
            this.linkLabelLogin.Location = new System.Drawing.Point(1698, 30);
            this.linkLabelLogin.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.linkLabelLogin.Name = "linkLabelLogin";
            this.linkLabelLogin.Size = new System.Drawing.Size(102, 42);
            this.linkLabelLogin.TabIndex = 13;
            this.linkLabelLogin.TabStop = true;
            this.linkLabelLogin.Text = "登入";
            this.linkLabelLogin.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelLogin_LinkClicked);
            // 
            // linkLabelRegister
            // 
            this.linkLabelRegister.AutoSize = true;
            this.linkLabelRegister.Font = new System.Drawing.Font("標楷體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.linkLabelRegister.ForeColor = System.Drawing.Color.Black;
            this.linkLabelRegister.LinkColor = System.Drawing.Color.Black;
            this.linkLabelRegister.Location = new System.Drawing.Point(1533, 30);
            this.linkLabelRegister.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.linkLabelRegister.Name = "linkLabelRegister";
            this.linkLabelRegister.Size = new System.Drawing.Size(102, 42);
            this.linkLabelRegister.TabIndex = 12;
            this.linkLabelRegister.TabStop = true;
            this.linkLabelRegister.Text = "註冊";
            // 
            // pbCart
            // 
            this.pbCart.Image = ((System.Drawing.Image)(resources.GetObject("pbCart.Image")));
            this.pbCart.Location = new System.Drawing.Point(1540, 132);
            this.pbCart.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.pbCart.Name = "pbCart";
            this.pbCart.Size = new System.Drawing.Size(108, 100);
            this.pbCart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCart.TabIndex = 18;
            this.pbCart.TabStop = false;
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point(1366, 144);
            this.button1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 66);
            this.button1.TabIndex = 17;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("標楷體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox1.Location = new System.Drawing.Point(575, 148);
            this.textBox1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(858, 58);
            this.textBox1.TabIndex = 16;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(165, 100);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(130, 120);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("標楷體", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(334, 136);
            this.label1.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(243, 70);
            this.label1.TabIndex = 14;
            this.label1.Text = "蝦到爆";
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Font = new System.Drawing.Font("標楷體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.linkLabel2.ForeColor = System.Drawing.Color.Black;
            this.linkLabel2.LinkColor = System.Drawing.Color.Black;
            this.linkLabel2.Location = new System.Drawing.Point(434, 34);
            this.linkLabel2.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(186, 42);
            this.linkLabel2.TabIndex = 11;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "追蹤我們";
            // 
            // lblToSellerForm
            // 
            this.lblToSellerForm.AutoSize = true;
            this.lblToSellerForm.Font = new System.Drawing.Font("標楷體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblToSellerForm.ForeColor = System.Drawing.Color.Black;
            this.lblToSellerForm.LinkColor = System.Drawing.Color.Black;
            this.lblToSellerForm.Location = new System.Drawing.Point(165, 34);
            this.lblToSellerForm.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.lblToSellerForm.Name = "lblToSellerForm";
            this.lblToSellerForm.Size = new System.Drawing.Size(186, 42);
            this.lblToSellerForm.TabIndex = 10;
            this.lblToSellerForm.TabStop = true;
            this.lblToSellerForm.Text = "賣家中心";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.flpBigType);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.flpProduct);
            this.splitContainer2.Size = new System.Drawing.Size(1914, 743);
            this.splitContainer2.SplitterDistance = 193;
            this.splitContainer2.TabIndex = 0;
            // 
            // flpBigType
            // 
            this.flpBigType.AutoScroll = true;
            this.flpBigType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpBigType.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpBigType.Font = new System.Drawing.Font("標楷體", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.flpBigType.Location = new System.Drawing.Point(0, 0);
            this.flpBigType.Name = "flpBigType";
            this.flpBigType.Size = new System.Drawing.Size(193, 743);
            this.flpBigType.TabIndex = 0;
            this.flpBigType.WrapContents = false;
            // 
            // flpProduct
            // 
            this.flpProduct.AutoScroll = true;
            this.flpProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpProduct.Location = new System.Drawing.Point(0, 0);
            this.flpProduct.Name = "flpProduct";
            this.flpProduct.Size = new System.Drawing.Size(1717, 743);
            this.flpProduct.TabIndex = 0;
            // 
            // lblProductNumInCart
            // 
            this.lblProductNumInCart.AutoSize = true;
            this.lblProductNumInCart.Location = new System.Drawing.Point(1667, 121);
            this.lblProductNumInCart.Name = "lblProductNumInCart";
            this.lblProductNumInCart.Size = new System.Drawing.Size(154, 24);
            this.lblProductNumInCart.TabIndex = 20;
            this.lblProductNumInCart.Text = "ProductNumber";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1914, 1018);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbCart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.LinkLabel linkLabelLogin;
        private System.Windows.Forms.LinkLabel linkLabelRegister;
        private System.Windows.Forms.PictureBox pbCart;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.LinkLabel lblToSellerForm;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.FlowLayoutPanel flpBigType;
        private System.Windows.Forms.FlowLayoutPanel flpProduct;
        private System.Windows.Forms.Label lblProductNumInCart;
    }
}

