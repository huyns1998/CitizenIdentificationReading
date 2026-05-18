using System.Windows.Forms;

namespace CitizenIdentificationReading.Forms
{
    partial class frmInputMailAndPhoneNumberAttachedLand
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlInputs = new FlowLayoutPanel();
            lblPhone = new Label();
            txtPhone = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            btnOK = new Button();
            btnClose = new Button();
            chkSyncPhoneEmail = new CheckBox();
            SuspendLayout();
            // 
            // pnlInputs
            // 
            pnlInputs.AutoScroll = true;
            pnlInputs.FlowDirection = FlowDirection.TopDown;
            pnlInputs.Location = new Point(12, 12);
            pnlInputs.Name = "pnlInputs";
            pnlInputs.Size = new Size(460, 160);
            pnlInputs.TabIndex = 0;
            pnlInputs.WrapContents = false;
            // 
            // lblPhone
            // 
            lblPhone.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPhone.Location = new Point(0, 0);
            lblPhone.Margin = new Padding(0, 10, 0, 2);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(440, 20);
            lblPhone.TabIndex = 0;
            lblPhone.Text = "Số điện thoại liên hệ (nếu có):";
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(0, 0);
            txtPhone.Margin = new Padding(0, 0, 0, 10);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(440, 23);
            txtPhone.TabIndex = 0;
            // 
            // lblEmail
            // 
            lblEmail.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblEmail.Location = new Point(0, 0);
            lblEmail.Margin = new Padding(0, 10, 0, 2);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(440, 20);
            lblEmail.TabIndex = 0;
            lblEmail.Text = "Hộp thư điện tử (nếu có):";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(0, 0);
            txtEmail.Margin = new Padding(0, 0, 0, 10);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(440, 23);
            txtEmail.TabIndex = 0;
            // 
            // btnOK
            // 
            btnOK.Location = new Point(397, 185);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(75, 30);
            btnOK.TabIndex = 1;
            btnOK.Text = "Xác nhận";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(316, 185);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 30);
            btnClose.TabIndex = 2;
            btnClose.Text = "Đóng";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // chkSyncPhoneEmail
            // 
            chkSyncPhoneEmail.AutoSize = true;
            chkSyncPhoneEmail.Location = new Point(12, 191);
            chkSyncPhoneEmail.Name = "chkSyncPhoneEmail";
            chkSyncPhoneEmail.Size = new Size(225, 19);
            chkSyncPhoneEmail.TabIndex = 3;
            chkSyncPhoneEmail.Text = "Nhập thông tin số điện thoại và email";
            chkSyncPhoneEmail.UseVisualStyleBackColor = true;
            // 
            // frmInputMailAndPhoneNumberAttachedLand
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 227);
            Controls.Add(chkSyncPhoneEmail);
            Controls.Add(btnClose);
            Controls.Add(btnOK);
            Controls.Add(pnlInputs);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmInputMailAndPhoneNumberAttachedLand";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Nhập thông tin số điện thoại và email";
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.FlowLayoutPanel pnlInputs;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.CheckBox chkSyncPhoneEmail;

        #endregion
    }
}