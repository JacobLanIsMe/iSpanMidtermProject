
namespace pgjMidtermProject
{
    partial class CtrlDisplayItem
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

        #region 元件設計工具產生的程式碼

        /// <summary> 
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.pbItemPhoto = new System.Windows.Forms.PictureBox();
            this.lblItemDescription = new System.Windows.Forms.Label();
            this.lblItemPrice = new System.Windows.Forms.Label();
            this.lblitemName = new System.Windows.Forms.Label();
            this.lblSoldOut = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbItemPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // pbItemPhoto
            // 
            this.pbItemPhoto.Dock = System.Windows.Forms.DockStyle.Top;
            this.pbItemPhoto.Location = new System.Drawing.Point(0, 0);
            this.pbItemPhoto.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.pbItemPhoto.Name = "pbItemPhoto";
            this.pbItemPhoto.Size = new System.Drawing.Size(156, 120);
            this.pbItemPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbItemPhoto.TabIndex = 0;
            this.pbItemPhoto.TabStop = false;
            // 
            // lblItemDescription
            // 
            this.lblItemDescription.AutoSize = true;
            this.lblItemDescription.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblItemDescription.Location = new System.Drawing.Point(1, 150);
            this.lblItemDescription.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblItemDescription.Name = "lblItemDescription";
            this.lblItemDescription.Size = new System.Drawing.Size(72, 16);
            this.lblItemDescription.TabIndex = 1;
            this.lblItemDescription.Text = "商品描述";
            // 
            // lblItemPrice
            // 
            this.lblItemPrice.AutoSize = true;
            this.lblItemPrice.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblItemPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblItemPrice.Location = new System.Drawing.Point(1, 172);
            this.lblItemPrice.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblItemPrice.Name = "lblItemPrice";
            this.lblItemPrice.Size = new System.Drawing.Size(72, 16);
            this.lblItemPrice.TabIndex = 2;
            this.lblItemPrice.Text = "商品價格";
            // 
            // lblitemName
            // 
            this.lblitemName.AutoSize = true;
            this.lblitemName.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblitemName.Location = new System.Drawing.Point(1, 129);
            this.lblitemName.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblitemName.Name = "lblitemName";
            this.lblitemName.Size = new System.Drawing.Size(72, 16);
            this.lblitemName.TabIndex = 3;
            this.lblitemName.Text = "商品描述";
            // 
            // lblSoldOut
            // 
            this.lblSoldOut.AutoSize = true;
            this.lblSoldOut.Font = new System.Drawing.Font("標楷體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblSoldOut.ForeColor = System.Drawing.Color.Red;
            this.lblSoldOut.Location = new System.Drawing.Point(4, 4);
            this.lblSoldOut.Name = "lblSoldOut";
            this.lblSoldOut.Size = new System.Drawing.Size(0, 21);
            this.lblSoldOut.TabIndex = 4;
            // 
            // CtrlDisplayItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblSoldOut);
            this.Controls.Add(this.lblitemName);
            this.Controls.Add(this.lblItemPrice);
            this.Controls.Add(this.lblItemDescription);
            this.Controls.Add(this.pbItemPhoto);
            this.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.Name = "CtrlDisplayItem";
            this.Size = new System.Drawing.Size(156, 214);
            ((System.ComponentModel.ISupportInitialize)(this.pbItemPhoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbItemPhoto;
        private System.Windows.Forms.Label lblItemDescription;
        private System.Windows.Forms.Label lblItemPrice;
        private System.Windows.Forms.Label lblitemName;
        private System.Windows.Forms.Label lblSoldOut;
    }
}
