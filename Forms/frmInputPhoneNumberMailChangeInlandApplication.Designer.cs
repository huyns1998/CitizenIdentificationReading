namespace CitizenIdentificationReading.Forms
{
    partial class frmInputPhoneNumberMailChangeInlandApplication
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
            pnlInputs.Size = new Size(460, 225);
            pnlInputs.TabIndex = 0;
            pnlInputs.WrapContents = false;
            // 
            // btnOK
            // 
            btnOK.Location = new Point(397, 252);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(75, 30);
            btnOK.TabIndex = 1;
            btnOK.Text = "Xác nhận";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(316, 252);
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
            chkSyncPhoneEmail.Location = new Point(12, 258);
            chkSyncPhoneEmail.Name = "chkSyncPhoneEmail";
            chkSyncPhoneEmail.Size = new Size(225, 19);
            chkSyncPhoneEmail.TabIndex = 3;
            chkSyncPhoneEmail.Text = "Nhập thông tin số điện thoại và email";
            chkSyncPhoneEmail.UseVisualStyleBackColor = true;
            // 
            // frmInputPhoneNumberMailChangeInlandApplication
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 296);
            Controls.Add(chkSyncPhoneEmail);
            Controls.Add(btnClose);
            Controls.Add(btnOK);
            Controls.Add(pnlInputs);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmInputPhoneNumberMailChangeInlandApplication";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Nhập thông tin số điện thoại và email";
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.FlowLayoutPanel pnlInputs;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.CheckBox chkSyncPhoneEmail;

        #endregion
    }
}