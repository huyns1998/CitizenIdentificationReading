namespace CitizenIdentificationReading
{
    partial class frmMain
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
            btnSelectCCCDFolder = new Button();
            txtPathToCccd = new TextBox();
            txtSaveFolder = new TextBox();
            btnSaveFolder = new Button();
            btnScan = new Button();
            txtErrorCCCD = new RichTextBox();
            label1 = new Label();
            txtDocPath = new TextBox();
            btnBrowseDoc = new Button();
            lblPaperType = new Label();
            cboPaperType = new ComboBox();
            txtPathToCccdDeligationPaper = new TextBox();
            btnSelectCCCDFolderDeligationPaper = new Button();
            txtSaveFolderDeligationPaper = new TextBox();
            btnSaveFolderDeligationPaper = new Button();
            btnScanDeligationPaper = new Button();
            txtErrorCCCDDeligationPaper = new RichTextBox();
            label1DeligationPaper = new Label();
            btnCancel = new Button();
            btnCancelDeligationPaper = new Button();
            btnReset = new Button();
            btnResetDeligationPaper = new Button();
            txtPathToCccdLandTransfer = new TextBox();
            btnSelectCCCDFolderLandTransfer = new Button();
            txtSaveFolderLandTransfer = new TextBox();
            btnSaveFolderLandTransfer = new Button();
            btnScanLandTransfer = new Button();
            txtErrorCCCDLandTransfer = new RichTextBox();
            label1LandTransfer = new Label();
            btnCancelLandTransfer = new Button();
            btnResetLandTransfer = new Button();
            chkInputIssuePlaceLandTransfer = new CheckBox();
            txtPathToCccdLandChange = new TextBox();
            btnSelectCCCDFolderLandChange = new Button();
            txtSaveFolderLandChange = new TextBox();
            btnSaveFolderLandChange = new Button();
            btnScanLandChange = new Button();
            txtErrorCCCDLandChange = new RichTextBox();
            label1LandChange = new Label();
            btnCancelLandChange = new Button();
            btnResetLandChange = new Button();
            chkInputPhoneEmailLandChange = new CheckBox();
            txtPathToCccdLandUseChange = new TextBox();
            btnSelectCCCDFolderLandUseChange = new Button();
            txtSaveFolderLandUseChange = new TextBox();
            btnSaveFolderLandUseChange = new Button();
            btnScanLandUseChange = new Button();
            txtErrorCCCDLandUseChange = new RichTextBox();
            label1LandUseChange = new Label();
            btnCancelLandUseChange = new Button();
            btnResetLandUseChange = new Button();
            chkInputContactLandUseChange = new CheckBox();
            txtPathToCccdAttachedLand = new TextBox();
            btnSelectCCCDFolderAttachedLand = new Button();
            txtSaveFolderAttachedLand = new TextBox();
            btnSaveFolderAttachedLand = new Button();
            btnScanAttachedLand = new Button();
            txtErrorCCCDAttachedLand = new RichTextBox();
            label1AttachedLand = new Label();
            btnCancelAttachedLand = new Button();
            btnResetAttachedLand = new Button();
            chkInputPhoneEmailAttachedLand = new CheckBox();
            SuspendLayout();
            // 
            // btnSelectCCCDFolder
            // 
            btnSelectCCCDFolder.Location = new Point(449, 70);
            btnSelectCCCDFolder.Name = "btnSelectCCCDFolder";
            btnSelectCCCDFolder.Size = new Size(111, 23);
            btnSelectCCCDFolder.TabIndex = 1;
            btnSelectCCCDFolder.Text = "Chọn folder cccd";
            btnSelectCCCDFolder.UseVisualStyleBackColor = true;
            btnSelectCCCDFolder.Visible = false;
            btnSelectCCCDFolder.Click += btnSelectCCCDFolder_Click;
            // 
            // txtPathToCccd
            // 
            txtPathToCccd.Location = new Point(46, 70);
            txtPathToCccd.Name = "txtPathToCccd";
            txtPathToCccd.Size = new Size(370, 23);
            txtPathToCccd.TabIndex = 0;
            txtPathToCccd.Visible = false;
            txtPathToCccd.TextChanged += txtPaths_TextChanged;
            // 
            // txtSaveFolder
            // 
            txtSaveFolder.Location = new Point(45, 111);
            txtSaveFolder.Name = "txtSaveFolder";
            txtSaveFolder.Size = new Size(371, 23);
            txtSaveFolder.TabIndex = 2;
            txtSaveFolder.Visible = false;
            txtSaveFolder.TextChanged += txtPaths_TextChanged;
            // 
            // btnSaveFolder
            // 
            btnSaveFolder.Location = new Point(449, 111);
            btnSaveFolder.Name = "btnSaveFolder";
            btnSaveFolder.Size = new Size(149, 23);
            btnSaveFolder.TabIndex = 3;
            btnSaveFolder.Text = "Chọn folder lưu kết quả";
            btnSaveFolder.UseVisualStyleBackColor = true;
            btnSaveFolder.Visible = false;
            btnSaveFolder.Click += btnSaveFolder_Click;
            // 
            // btnScan
            // 
            btnScan.Enabled = false;
            btnScan.Location = new Point(178, 190);
            btnScan.Name = "btnScan";
            btnScan.Size = new Size(75, 23);
            btnScan.TabIndex = 4;
            btnScan.Text = "Quét cccd";
            btnScan.UseVisualStyleBackColor = true;
            btnScan.Visible = false;
            btnScan.Click += btnScan_Click;
            // 
            // txtErrorCCCD
            // 
            txtErrorCCCD.Location = new Point(49, 251);
            txtErrorCCCD.Name = "txtErrorCCCD";
            txtErrorCCCD.ReadOnly = true;
            txtErrorCCCD.Size = new Size(553, 212);
            txtErrorCCCD.TabIndex = 5;
            txtErrorCCCD.Text = "";
            txtErrorCCCD.Visible = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(49, 225);
            label1.Name = "label1";
            label1.Size = new Size(27, 15);
            label1.TabIndex = 6;
            label1.Text = "log:";
            label1.Visible = false;
            // 
            // txtDocPath
            // 
            txtDocPath.Location = new Point(45, 150);
            txtDocPath.Name = "txtDocPath";
            txtDocPath.Size = new Size(371, 23);
            txtDocPath.TabIndex = 7;
            txtDocPath.Visible = false;
            txtDocPath.TextChanged += txtPaths_TextChanged;
            // 
            // btnBrowseDoc
            // 
            btnBrowseDoc.Location = new Point(449, 149);
            btnBrowseDoc.Name = "btnBrowseDoc";
            btnBrowseDoc.Size = new Size(111, 23);
            btnBrowseDoc.TabIndex = 8;
            btnBrowseDoc.Text = "Chọn document";
            btnBrowseDoc.UseVisualStyleBackColor = true;
            btnBrowseDoc.Visible = false;
            btnBrowseDoc.Click += btnBrowseDoc_Click;
            // 
            // lblPaperType
            // 
            lblPaperType.AutoSize = true;
            lblPaperType.Location = new Point(45, 25);
            lblPaperType.Name = "lblPaperType";
            lblPaperType.Size = new Size(105, 15);
            lblPaperType.TabIndex = 22;
            lblPaperType.Text = "Chọn mẫu giấy tờ:";
            // 
            // cboPaperType
            // 
            cboPaperType.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPaperType.FormattingEnabled = true;
            cboPaperType.Items.AddRange(new object[] { "Giấy ủy quyền", "Hợp đồng chuyển nhượng quyền sử dụng đất", "Đơn đăng ký biến động đất đai", "Đơn đề nghị chuyển mục đích sử dụng đất", "Đơn đăng ký đất đai, tài sản gắn liền với đất", "Tự chọn mẫu giấy tờ" });
            cboPaperType.Location = new Point(160, 22);
            cboPaperType.Name = "cboPaperType";
            cboPaperType.Size = new Size(300, 23);
            cboPaperType.TabIndex = 23;
            cboPaperType.SelectedIndexChanged += cboPaperType_SelectedIndexChanged;
            // 
            // txtPathToCccdDeligationPaper
            // 
            txtPathToCccdDeligationPaper.Location = new Point(46, 70);
            txtPathToCccdDeligationPaper.Name = "txtPathToCccdDeligationPaper";
            txtPathToCccdDeligationPaper.Size = new Size(370, 23);
            txtPathToCccdDeligationPaper.TabIndex = 11;
            txtPathToCccdDeligationPaper.Visible = false;
            txtPathToCccdDeligationPaper.TextChanged += txtPathsDeligationPaper_TextChanged;
            // 
            // btnSelectCCCDFolderDeligationPaper
            // 
            btnSelectCCCDFolderDeligationPaper.Location = new Point(449, 70);
            btnSelectCCCDFolderDeligationPaper.Name = "btnSelectCCCDFolderDeligationPaper";
            btnSelectCCCDFolderDeligationPaper.Size = new Size(111, 23);
            btnSelectCCCDFolderDeligationPaper.TabIndex = 12;
            btnSelectCCCDFolderDeligationPaper.Text = "Chọn folder cccd";
            btnSelectCCCDFolderDeligationPaper.UseVisualStyleBackColor = true;
            btnSelectCCCDFolderDeligationPaper.Visible = false;
            btnSelectCCCDFolderDeligationPaper.Click += btnSelectCCCDFolderDeligationPaper_Click;
            // 
            // txtSaveFolderDeligationPaper
            // 
            txtSaveFolderDeligationPaper.Location = new Point(45, 111);
            txtSaveFolderDeligationPaper.Name = "txtSaveFolderDeligationPaper";
            txtSaveFolderDeligationPaper.Size = new Size(371, 23);
            txtSaveFolderDeligationPaper.TabIndex = 13;
            txtSaveFolderDeligationPaper.Visible = false;
            txtSaveFolderDeligationPaper.TextChanged += txtPathsDeligationPaper_TextChanged;
            // 
            // btnSaveFolderDeligationPaper
            // 
            btnSaveFolderDeligationPaper.Location = new Point(449, 111);
            btnSaveFolderDeligationPaper.Name = "btnSaveFolderDeligationPaper";
            btnSaveFolderDeligationPaper.Size = new Size(149, 23);
            btnSaveFolderDeligationPaper.TabIndex = 14;
            btnSaveFolderDeligationPaper.Text = "Chọn folder lưu kết quả";
            btnSaveFolderDeligationPaper.UseVisualStyleBackColor = true;
            btnSaveFolderDeligationPaper.Visible = false;
            btnSaveFolderDeligationPaper.Click += btnSaveFolderDeligationPaper_Click;
            // 
            // btnScanDeligationPaper
            // 
            btnScanDeligationPaper.Enabled = false;
            btnScanDeligationPaper.Location = new Point(178, 190);
            btnScanDeligationPaper.Name = "btnScanDeligationPaper";
            btnScanDeligationPaper.Size = new Size(75, 23);
            btnScanDeligationPaper.TabIndex = 15;
            btnScanDeligationPaper.Text = "Quét cccd";
            btnScanDeligationPaper.UseVisualStyleBackColor = true;
            btnScanDeligationPaper.Visible = false;
            btnScanDeligationPaper.Click += btnScanDeligationPaper_Click;
            // 
            // txtErrorCCCDDeligationPaper
            // 
            txtErrorCCCDDeligationPaper.Location = new Point(49, 251);
            txtErrorCCCDDeligationPaper.Name = "txtErrorCCCDDeligationPaper";
            txtErrorCCCDDeligationPaper.ReadOnly = true;
            txtErrorCCCDDeligationPaper.Size = new Size(553, 212);
            txtErrorCCCDDeligationPaper.TabIndex = 16;
            txtErrorCCCDDeligationPaper.Text = "";
            txtErrorCCCDDeligationPaper.Visible = false;
            // 
            // label1DeligationPaper
            // 
            label1DeligationPaper.Location = new Point(49, 225);
            label1DeligationPaper.Name = "label1DeligationPaper";
            label1DeligationPaper.Size = new Size(100, 23);
            label1DeligationPaper.TabIndex = 17;
            label1DeligationPaper.Text = "log:";
            label1DeligationPaper.Visible = false;
            // 
            // btnCancel
            // 
            btnCancel.Enabled = false;
            btnCancel.Location = new Point(259, 190);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 18;
            btnCancel.Text = "Hủy";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Visible = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnCancelDeligationPaper
            // 
            btnCancelDeligationPaper.Enabled = false;
            btnCancelDeligationPaper.Location = new Point(260, 190);
            btnCancelDeligationPaper.Name = "btnCancelDeligationPaper";
            btnCancelDeligationPaper.Size = new Size(75, 23);
            btnCancelDeligationPaper.TabIndex = 19;
            btnCancelDeligationPaper.Text = "Hủy";
            btnCancelDeligationPaper.UseVisualStyleBackColor = true;
            btnCancelDeligationPaper.Visible = false;
            btnCancelDeligationPaper.Click += btnCancelDeligationPaper_Click;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(341, 190);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(75, 23);
            btnReset.TabIndex = 20;
            btnReset.Text = "Đặt lại";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Visible = false;
            btnReset.Click += btnReset_Click;
            // 
            // btnResetDeligationPaper
            // 
            btnResetDeligationPaper.Location = new Point(341, 190);
            btnResetDeligationPaper.Name = "btnResetDeligationPaper";
            btnResetDeligationPaper.Size = new Size(75, 23);
            btnResetDeligationPaper.TabIndex = 21;
            btnResetDeligationPaper.Text = "Đặt lại";
            btnResetDeligationPaper.UseVisualStyleBackColor = true;
            btnResetDeligationPaper.Visible = false;
            btnResetDeligationPaper.Click += btnResetDeligationPaper_Click;
            // 
            // txtPathToCccdLandTransfer
            // 
            txtPathToCccdLandTransfer.Location = new Point(46, 70);
            txtPathToCccdLandTransfer.Name = "txtPathToCccdLandTransfer";
            txtPathToCccdLandTransfer.Size = new Size(370, 23);
            txtPathToCccdLandTransfer.TabIndex = 24;
            txtPathToCccdLandTransfer.Visible = false;
            txtPathToCccdLandTransfer.TextChanged += txtPathsLandTransfer_TextChanged;
            // 
            // btnSelectCCCDFolderLandTransfer
            // 
            btnSelectCCCDFolderLandTransfer.Location = new Point(449, 70);
            btnSelectCCCDFolderLandTransfer.Name = "btnSelectCCCDFolderLandTransfer";
            btnSelectCCCDFolderLandTransfer.Size = new Size(111, 23);
            btnSelectCCCDFolderLandTransfer.TabIndex = 25;
            btnSelectCCCDFolderLandTransfer.Text = "Chọn folder cccd";
            btnSelectCCCDFolderLandTransfer.UseVisualStyleBackColor = true;
            btnSelectCCCDFolderLandTransfer.Visible = false;
            btnSelectCCCDFolderLandTransfer.Click += btnSelectCCCDFolderLandTransfer_Click;
            // 
            // txtSaveFolderLandTransfer
            // 
            txtSaveFolderLandTransfer.Location = new Point(45, 111);
            txtSaveFolderLandTransfer.Name = "txtSaveFolderLandTransfer";
            txtSaveFolderLandTransfer.Size = new Size(371, 23);
            txtSaveFolderLandTransfer.TabIndex = 26;
            txtSaveFolderLandTransfer.Visible = false;
            txtSaveFolderLandTransfer.TextChanged += txtPathsLandTransfer_TextChanged;
            // 
            // btnSaveFolderLandTransfer
            // 
            btnSaveFolderLandTransfer.Location = new Point(449, 111);
            btnSaveFolderLandTransfer.Name = "btnSaveFolderLandTransfer";
            btnSaveFolderLandTransfer.Size = new Size(149, 23);
            btnSaveFolderLandTransfer.TabIndex = 27;
            btnSaveFolderLandTransfer.Text = "Chọn folder lưu kết quả";
            btnSaveFolderLandTransfer.UseVisualStyleBackColor = true;
            btnSaveFolderLandTransfer.Visible = false;
            btnSaveFolderLandTransfer.Click += btnSaveFolderLandTransfer_Click;
            // 
            // btnScanLandTransfer
            // 
            btnScanLandTransfer.Enabled = false;
            btnScanLandTransfer.Location = new Point(178, 190);
            btnScanLandTransfer.Name = "btnScanLandTransfer";
            btnScanLandTransfer.Size = new Size(75, 23);
            btnScanLandTransfer.TabIndex = 28;
            btnScanLandTransfer.Text = "Quét cccd";
            btnScanLandTransfer.UseVisualStyleBackColor = true;
            btnScanLandTransfer.Visible = false;
            btnScanLandTransfer.Click += btnScanLandTransfer_Click;
            // 
            // txtErrorCCCDLandTransfer
            // 
            txtErrorCCCDLandTransfer.Location = new Point(49, 251);
            txtErrorCCCDLandTransfer.Name = "txtErrorCCCDLandTransfer";
            txtErrorCCCDLandTransfer.ReadOnly = true;
            txtErrorCCCDLandTransfer.Size = new Size(553, 212);
            txtErrorCCCDLandTransfer.TabIndex = 29;
            txtErrorCCCDLandTransfer.Text = "";
            txtErrorCCCDLandTransfer.Visible = false;
            // 
            // label1LandTransfer
            // 
            label1LandTransfer.Location = new Point(49, 225);
            label1LandTransfer.Name = "label1LandTransfer";
            label1LandTransfer.Size = new Size(100, 23);
            label1LandTransfer.TabIndex = 30;
            label1LandTransfer.Text = "log:";
            label1LandTransfer.Visible = false;
            // 
            // btnCancelLandTransfer
            // 
            btnCancelLandTransfer.Enabled = false;
            btnCancelLandTransfer.Location = new Point(259, 190);
            btnCancelLandTransfer.Name = "btnCancelLandTransfer";
            btnCancelLandTransfer.Size = new Size(75, 23);
            btnCancelLandTransfer.TabIndex = 31;
            btnCancelLandTransfer.Text = "Hủy";
            btnCancelLandTransfer.UseVisualStyleBackColor = true;
            btnCancelLandTransfer.Visible = false;
            btnCancelLandTransfer.Click += btnCancelLandTransfer_Click;
            // 
            // btnResetLandTransfer
            // 
            btnResetLandTransfer.Location = new Point(341, 190);
            btnResetLandTransfer.Name = "btnResetLandTransfer";
            btnResetLandTransfer.Size = new Size(75, 23);
            btnResetLandTransfer.TabIndex = 32;
            btnResetLandTransfer.Text = "Đặt lại";
            btnResetLandTransfer.UseVisualStyleBackColor = true;
            btnResetLandTransfer.Visible = false;
            btnResetLandTransfer.Click += btnResetLandTransfer_Click;
            // 
            // chkInputIssuePlaceLandTransfer
            // 
            chkInputIssuePlaceLandTransfer.AutoSize = true;
            chkInputIssuePlaceLandTransfer.Location = new Point(470, 24);
            chkInputIssuePlaceLandTransfer.Name = "chkInputIssuePlaceLandTransfer";
            chkInputIssuePlaceLandTransfer.Size = new Size(184, 19);
            chkInputIssuePlaceLandTransfer.TabIndex = 33;
            chkInputIssuePlaceLandTransfer.Text = "Nhập thông tin nơi cấp CCCD";
            chkInputIssuePlaceLandTransfer.UseVisualStyleBackColor = true;
            chkInputIssuePlaceLandTransfer.Visible = false;
            // 
            // txtPathToCccdLandChange
            // 
            txtPathToCccdLandChange.Location = new Point(46, 70);
            txtPathToCccdLandChange.Name = "txtPathToCccdLandChange";
            txtPathToCccdLandChange.Size = new Size(370, 23);
            txtPathToCccdLandChange.TabIndex = 34;
            txtPathToCccdLandChange.Visible = false;
            txtPathToCccdLandChange.TextChanged += txtPathsLandChange_TextChanged;
            // 
            // btnSelectCCCDFolderLandChange
            // 
            btnSelectCCCDFolderLandChange.Location = new Point(449, 70);
            btnSelectCCCDFolderLandChange.Name = "btnSelectCCCDFolderLandChange";
            btnSelectCCCDFolderLandChange.Size = new Size(111, 23);
            btnSelectCCCDFolderLandChange.TabIndex = 35;
            btnSelectCCCDFolderLandChange.Text = "Chọn folder cccd";
            btnSelectCCCDFolderLandChange.UseVisualStyleBackColor = true;
            btnSelectCCCDFolderLandChange.Visible = false;
            btnSelectCCCDFolderLandChange.Click += btnSelectCCCDFolderLandChange_Click;
            // 
            // txtSaveFolderLandChange
            // 
            txtSaveFolderLandChange.Location = new Point(45, 111);
            txtSaveFolderLandChange.Name = "txtSaveFolderLandChange";
            txtSaveFolderLandChange.Size = new Size(371, 23);
            txtSaveFolderLandChange.TabIndex = 36;
            txtSaveFolderLandChange.Visible = false;
            txtSaveFolderLandChange.TextChanged += txtPathsLandChange_TextChanged;
            // 
            // btnSaveFolderLandChange
            // 
            btnSaveFolderLandChange.Location = new Point(449, 111);
            btnSaveFolderLandChange.Name = "btnSaveFolderLandChange";
            btnSaveFolderLandChange.Size = new Size(149, 23);
            btnSaveFolderLandChange.TabIndex = 37;
            btnSaveFolderLandChange.Text = "Chọn folder lưu kết quả";
            btnSaveFolderLandChange.UseVisualStyleBackColor = true;
            btnSaveFolderLandChange.Visible = false;
            btnSaveFolderLandChange.Click += btnSaveFolderLandChange_Click;
            // 
            // btnScanLandChange
            // 
            btnScanLandChange.Enabled = false;
            btnScanLandChange.Location = new Point(178, 190);
            btnScanLandChange.Name = "btnScanLandChange";
            btnScanLandChange.Size = new Size(75, 23);
            btnScanLandChange.TabIndex = 38;
            btnScanLandChange.Text = "Quét cccd";
            btnScanLandChange.UseVisualStyleBackColor = true;
            btnScanLandChange.Visible = false;
            btnScanLandChange.Click += btnScanLandChange_Click;
            // 
            // txtErrorCCCDLandChange
            // 
            txtErrorCCCDLandChange.Location = new Point(49, 251);
            txtErrorCCCDLandChange.Name = "txtErrorCCCDLandChange";
            txtErrorCCCDLandChange.ReadOnly = true;
            txtErrorCCCDLandChange.Size = new Size(553, 212);
            txtErrorCCCDLandChange.TabIndex = 39;
            txtErrorCCCDLandChange.Text = "";
            txtErrorCCCDLandChange.Visible = false;
            // 
            // label1LandChange
            // 
            label1LandChange.Location = new Point(49, 225);
            label1LandChange.Name = "label1LandChange";
            label1LandChange.Size = new Size(100, 23);
            label1LandChange.TabIndex = 40;
            label1LandChange.Text = "log:";
            label1LandChange.Visible = false;
            // 
            // btnCancelLandChange
            // 
            btnCancelLandChange.Enabled = false;
            btnCancelLandChange.Location = new Point(259, 190);
            btnCancelLandChange.Name = "btnCancelLandChange";
            btnCancelLandChange.Size = new Size(75, 23);
            btnCancelLandChange.TabIndex = 41;
            btnCancelLandChange.Text = "Hủy";
            btnCancelLandChange.UseVisualStyleBackColor = true;
            btnCancelLandChange.Visible = false;
            btnCancelLandChange.Click += btnCancelLandChange_Click;
            // 
            // btnResetLandChange
            // 
            btnResetLandChange.Location = new Point(341, 190);
            btnResetLandChange.Name = "btnResetLandChange";
            btnResetLandChange.Size = new Size(75, 23);
            btnResetLandChange.TabIndex = 42;
            btnResetLandChange.Text = "Đặt lại";
            btnResetLandChange.UseVisualStyleBackColor = true;
            btnResetLandChange.Visible = false;
            btnResetLandChange.Click += btnResetLandChange_Click;
            // 
            // chkInputPhoneEmailLandChange
            // 
            chkInputPhoneEmailLandChange.AutoSize = true;
            chkInputPhoneEmailLandChange.Location = new Point(470, 24);
            chkInputPhoneEmailLandChange.Name = "chkInputPhoneEmailLandChange";
            chkInputPhoneEmailLandChange.Size = new Size(225, 19);
            chkInputPhoneEmailLandChange.TabIndex = 43;
            chkInputPhoneEmailLandChange.Text = "Nhập thông tin số điện thoại và email";
            chkInputPhoneEmailLandChange.UseVisualStyleBackColor = true;
            chkInputPhoneEmailLandChange.Visible = false;
            // 
            // txtPathToCccdLandUseChange
            // 
            txtPathToCccdLandUseChange.Location = new Point(46, 70);
            txtPathToCccdLandUseChange.Name = "txtPathToCccdLandUseChange";
            txtPathToCccdLandUseChange.Size = new Size(370, 23);
            txtPathToCccdLandUseChange.TabIndex = 44;
            txtPathToCccdLandUseChange.Visible = false;
            txtPathToCccdLandUseChange.TextChanged += txtPathsLandUseChange_TextChanged;
            // 
            // btnSelectCCCDFolderLandUseChange
            // 
            btnSelectCCCDFolderLandUseChange.Location = new Point(449, 70);
            btnSelectCCCDFolderLandUseChange.Name = "btnSelectCCCDFolderLandUseChange";
            btnSelectCCCDFolderLandUseChange.Size = new Size(111, 23);
            btnSelectCCCDFolderLandUseChange.TabIndex = 45;
            btnSelectCCCDFolderLandUseChange.Text = "Chọn folder cccd";
            btnSelectCCCDFolderLandUseChange.UseVisualStyleBackColor = true;
            btnSelectCCCDFolderLandUseChange.Visible = false;
            btnSelectCCCDFolderLandUseChange.Click += btnSelectCCCDFolderLandUseChange_Click;
            // 
            // txtSaveFolderLandUseChange
            // 
            txtSaveFolderLandUseChange.Location = new Point(45, 111);
            txtSaveFolderLandUseChange.Name = "txtSaveFolderLandUseChange";
            txtSaveFolderLandUseChange.Size = new Size(371, 23);
            txtSaveFolderLandUseChange.TabIndex = 46;
            txtSaveFolderLandUseChange.Visible = false;
            txtSaveFolderLandUseChange.TextChanged += txtPathsLandUseChange_TextChanged;
            // 
            // btnSaveFolderLandUseChange
            // 
            btnSaveFolderLandUseChange.Location = new Point(449, 111);
            btnSaveFolderLandUseChange.Name = "btnSaveFolderLandUseChange";
            btnSaveFolderLandUseChange.Size = new Size(149, 23);
            btnSaveFolderLandUseChange.TabIndex = 47;
            btnSaveFolderLandUseChange.Text = "Chọn folder lưu kết quả";
            btnSaveFolderLandUseChange.UseVisualStyleBackColor = true;
            btnSaveFolderLandUseChange.Visible = false;
            btnSaveFolderLandUseChange.Click += btnSaveFolderLandUseChange_Click;
            // 
            // btnScanLandUseChange
            // 
            btnScanLandUseChange.Enabled = false;
            btnScanLandUseChange.Location = new Point(178, 190);
            btnScanLandUseChange.Name = "btnScanLandUseChange";
            btnScanLandUseChange.Size = new Size(75, 23);
            btnScanLandUseChange.TabIndex = 48;
            btnScanLandUseChange.Text = "Quét cccd";
            btnScanLandUseChange.UseVisualStyleBackColor = true;
            btnScanLandUseChange.Visible = false;
            btnScanLandUseChange.Click += btnScanLandUseChange_Click;
            // 
            // txtErrorCCCDLandUseChange
            // 
            txtErrorCCCDLandUseChange.Location = new Point(49, 251);
            txtErrorCCCDLandUseChange.Name = "txtErrorCCCDLandUseChange";
            txtErrorCCCDLandUseChange.ReadOnly = true;
            txtErrorCCCDLandUseChange.Size = new Size(553, 212);
            txtErrorCCCDLandUseChange.TabIndex = 49;
            txtErrorCCCDLandUseChange.Text = "";
            txtErrorCCCDLandUseChange.Visible = false;
            // 
            // label1LandUseChange
            // 
            label1LandUseChange.Location = new Point(49, 225);
            label1LandUseChange.Name = "label1LandUseChange";
            label1LandUseChange.Size = new Size(100, 23);
            label1LandUseChange.TabIndex = 50;
            label1LandUseChange.Text = "log:";
            label1LandUseChange.Visible = false;
            // 
            // btnCancelLandUseChange
            // 
            btnCancelLandUseChange.Enabled = false;
            btnCancelLandUseChange.Location = new Point(259, 190);
            btnCancelLandUseChange.Name = "btnCancelLandUseChange";
            btnCancelLandUseChange.Size = new Size(75, 23);
            btnCancelLandUseChange.TabIndex = 51;
            btnCancelLandUseChange.Text = "Hủy";
            btnCancelLandUseChange.UseVisualStyleBackColor = true;
            btnCancelLandUseChange.Visible = false;
            btnCancelLandUseChange.Click += btnCancelLandUseChange_Click;
            // 
            // btnResetLandUseChange
            // 
            btnResetLandUseChange.Location = new Point(341, 190);
            btnResetLandUseChange.Name = "btnResetLandUseChange";
            btnResetLandUseChange.Size = new Size(75, 23);
            btnResetLandUseChange.TabIndex = 52;
            btnResetLandUseChange.Text = "Đặt lại";
            btnResetLandUseChange.UseVisualStyleBackColor = true;
            btnResetLandUseChange.Visible = false;
            btnResetLandUseChange.Click += btnResetLandUseChange_Click;
            // 
            // chkInputContactLandUseChange
            // 
            chkInputContactLandUseChange.AutoSize = true;
            chkInputContactLandUseChange.Location = new Point(470, 24);
            chkInputContactLandUseChange.Name = "chkInputContactLandUseChange";
            chkInputContactLandUseChange.Size = new Size(160, 19);
            chkInputContactLandUseChange.TabIndex = 53;
            chkInputContactLandUseChange.Text = "Nhập thông tin liên hệ";
            chkInputContactLandUseChange.UseVisualStyleBackColor = true;
            chkInputContactLandUseChange.Visible = false;
            // 
            // txtPathToCccdAttachedLand
            // 
            txtPathToCccdAttachedLand.Location = new Point(46, 70);
            txtPathToCccdAttachedLand.Name = "txtPathToCccdAttachedLand";
            txtPathToCccdAttachedLand.Size = new Size(370, 23);
            txtPathToCccdAttachedLand.TabIndex = 54;
            txtPathToCccdAttachedLand.Visible = false;
            txtPathToCccdAttachedLand.TextChanged += txtPathsAttachedLand_TextChanged;
            // 
            // btnSelectCCCDFolderAttachedLand
            // 
            btnSelectCCCDFolderAttachedLand.Location = new Point(449, 70);
            btnSelectCCCDFolderAttachedLand.Name = "btnSelectCCCDFolderAttachedLand";
            btnSelectCCCDFolderAttachedLand.Size = new Size(111, 23);
            btnSelectCCCDFolderAttachedLand.TabIndex = 55;
            btnSelectCCCDFolderAttachedLand.Text = "Chọn folder cccd";
            btnSelectCCCDFolderAttachedLand.UseVisualStyleBackColor = true;
            btnSelectCCCDFolderAttachedLand.Visible = false;
            btnSelectCCCDFolderAttachedLand.Click += btnSelectCCCDFolderAttachedLand_Click;
            // 
            // txtSaveFolderAttachedLand
            // 
            txtSaveFolderAttachedLand.Location = new Point(45, 111);
            txtSaveFolderAttachedLand.Name = "txtSaveFolderAttachedLand";
            txtSaveFolderAttachedLand.Size = new Size(371, 23);
            txtSaveFolderAttachedLand.TabIndex = 56;
            txtSaveFolderAttachedLand.Visible = false;
            txtSaveFolderAttachedLand.TextChanged += txtPathsAttachedLand_TextChanged;
            // 
            // btnSaveFolderAttachedLand
            // 
            btnSaveFolderAttachedLand.Location = new Point(449, 111);
            btnSaveFolderAttachedLand.Name = "btnSaveFolderAttachedLand";
            btnSaveFolderAttachedLand.Size = new Size(149, 23);
            btnSaveFolderAttachedLand.TabIndex = 57;
            btnSaveFolderAttachedLand.Text = "Chọn folder lưu kết quả";
            btnSaveFolderAttachedLand.UseVisualStyleBackColor = true;
            btnSaveFolderAttachedLand.Visible = false;
            btnSaveFolderAttachedLand.Click += btnSaveFolderAttachedLand_Click;
            // 
            // btnScanAttachedLand
            // 
            btnScanAttachedLand.Enabled = false;
            btnScanAttachedLand.Location = new Point(178, 190);
            btnScanAttachedLand.Name = "btnScanAttachedLand";
            btnScanAttachedLand.Size = new Size(75, 23);
            btnScanAttachedLand.TabIndex = 58;
            btnScanAttachedLand.Text = "Quét cccd";
            btnScanAttachedLand.UseVisualStyleBackColor = true;
            btnScanAttachedLand.Visible = false;
            btnScanAttachedLand.Click += btnScanAttachedLand_Click;
            // 
            // txtErrorCCCDAttachedLand
            // 
            txtErrorCCCDAttachedLand.Location = new Point(49, 251);
            txtErrorCCCDAttachedLand.Name = "txtErrorCCCDAttachedLand";
            txtErrorCCCDAttachedLand.ReadOnly = true;
            txtErrorCCCDAttachedLand.Size = new Size(553, 212);
            txtErrorCCCDAttachedLand.TabIndex = 59;
            txtErrorCCCDAttachedLand.Text = "";
            txtErrorCCCDAttachedLand.Visible = false;
            // 
            // label1AttachedLand
            // 
            label1AttachedLand.Location = new Point(49, 225);
            label1AttachedLand.Name = "label1AttachedLand";
            label1AttachedLand.Size = new Size(100, 23);
            label1AttachedLand.TabIndex = 60;
            label1AttachedLand.Text = "log:";
            label1AttachedLand.Visible = false;
            // 
            // btnCancelAttachedLand
            // 
            btnCancelAttachedLand.Enabled = false;
            btnCancelAttachedLand.Location = new Point(259, 190);
            btnCancelAttachedLand.Name = "btnCancelAttachedLand";
            btnCancelAttachedLand.Size = new Size(75, 23);
            btnCancelAttachedLand.TabIndex = 61;
            btnCancelAttachedLand.Text = "Hủy";
            btnCancelAttachedLand.UseVisualStyleBackColor = true;
            btnCancelAttachedLand.Visible = false;
            btnCancelAttachedLand.Click += btnCancelAttachedLand_Click;
            // 
            // btnResetAttachedLand
            // 
            btnResetAttachedLand.Location = new Point(341, 190);
            btnResetAttachedLand.Name = "btnResetAttachedLand";
            btnResetAttachedLand.Size = new Size(75, 23);
            btnResetAttachedLand.TabIndex = 62;
            btnResetAttachedLand.Text = "Đặt lại";
            btnResetAttachedLand.UseVisualStyleBackColor = true;
            btnResetAttachedLand.Visible = false;
            btnResetAttachedLand.Click += btnResetAttachedLand_Click;
            // 
            // chkInputPhoneEmailAttachedLand
            // 
            chkInputPhoneEmailAttachedLand.AutoSize = true;
            chkInputPhoneEmailAttachedLand.Location = new Point(470, 24);
            chkInputPhoneEmailAttachedLand.Name = "chkInputPhoneEmailAttachedLand";
            chkInputPhoneEmailAttachedLand.Size = new Size(225, 19);
            chkInputPhoneEmailAttachedLand.TabIndex = 63;
            chkInputPhoneEmailAttachedLand.Text = "Nhập thông tin số điện thoại và email";
            chkInputPhoneEmailAttachedLand.UseVisualStyleBackColor = true;
            chkInputPhoneEmailAttachedLand.Visible = false;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(724, 475);
            Controls.Add(txtPathToCccdDeligationPaper);
            Controls.Add(btnSelectCCCDFolderDeligationPaper);
            Controls.Add(txtSaveFolderDeligationPaper);
            Controls.Add(btnSaveFolderDeligationPaper);
            Controls.Add(btnScanDeligationPaper);
            Controls.Add(txtErrorCCCDDeligationPaper);
            Controls.Add(label1DeligationPaper);
            Controls.Add(cboPaperType);
            Controls.Add(lblPaperType);
            Controls.Add(btnBrowseDoc);
            Controls.Add(txtDocPath);
            Controls.Add(label1);
            Controls.Add(txtErrorCCCD);
            Controls.Add(btnScan);
            Controls.Add(btnSaveFolder);
            Controls.Add(txtSaveFolder);
            Controls.Add(txtPathToCccd);
            Controls.Add(btnSelectCCCDFolder);
            Controls.Add(btnCancel);
            Controls.Add(btnCancelDeligationPaper);
            Controls.Add(btnReset);
            Controls.Add(btnResetDeligationPaper);
            Controls.Add(txtPathToCccdLandTransfer);
            Controls.Add(btnSelectCCCDFolderLandTransfer);
            Controls.Add(txtSaveFolderLandTransfer);
            Controls.Add(btnSaveFolderLandTransfer);
            Controls.Add(btnScanLandTransfer);
            Controls.Add(txtErrorCCCDLandTransfer);
            Controls.Add(label1LandTransfer);
            Controls.Add(btnCancelLandTransfer);
            Controls.Add(btnResetLandTransfer);
            Controls.Add(chkInputIssuePlaceLandTransfer);
            Controls.Add(txtPathToCccdLandChange);
            Controls.Add(btnSelectCCCDFolderLandChange);
            Controls.Add(txtSaveFolderLandChange);
            Controls.Add(btnSaveFolderLandChange);
            Controls.Add(btnScanLandChange);
            Controls.Add(txtErrorCCCDLandChange);
            Controls.Add(label1LandChange);
            Controls.Add(btnCancelLandChange);
            Controls.Add(btnResetLandChange);
            Controls.Add(chkInputPhoneEmailLandChange);
            Controls.Add(txtPathToCccdLandUseChange);
            Controls.Add(btnSelectCCCDFolderLandUseChange);
            Controls.Add(txtSaveFolderLandUseChange);
            Controls.Add(btnSaveFolderLandUseChange);
            Controls.Add(btnScanLandUseChange);
            Controls.Add(txtErrorCCCDLandUseChange);
            Controls.Add(label1LandUseChange);
            Controls.Add(btnCancelLandUseChange);
            Controls.Add(btnResetLandUseChange);
            Controls.Add(chkInputContactLandUseChange);
            Controls.Add(txtPathToCccdAttachedLand);
            Controls.Add(btnSelectCCCDFolderAttachedLand);
            Controls.Add(txtSaveFolderAttachedLand);
            Controls.Add(btnSaveFolderAttachedLand);
            Controls.Add(btnScanAttachedLand);
            Controls.Add(txtErrorCCCDAttachedLand);
            Controls.Add(label1AttachedLand);
            Controls.Add(btnCancelAttachedLand);
            Controls.Add(btnResetAttachedLand);
            Controls.Add(chkInputPhoneEmailAttachedLand);
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CCCD Scanner";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblPaperType;
        private ComboBox cboPaperType;

        private Button btnSelectCCCDFolder;
        private TextBox txtPathToCccd;
        private TextBox txtSaveFolder;
        private Button btnSaveFolder;
        private Button btnScan;
        private RichTextBox txtErrorCCCD;
        private Label label1;
        private TextBox txtDocPath;
        private Button btnBrowseDoc;
        
        private TextBox txtPathToCccdDeligationPaper;
        private Button btnSelectCCCDFolderDeligationPaper;
        private TextBox txtSaveFolderDeligationPaper;
        private Button btnSaveFolderDeligationPaper;
        private Button btnScanDeligationPaper;
        private RichTextBox txtErrorCCCDDeligationPaper;
        private Label label1DeligationPaper;
        private Button btnCancel;
        private Button btnCancelDeligationPaper;
        private Button btnReset;
        private Button btnResetDeligationPaper;
        private TextBox txtPathToCccdLandTransfer;
        private Button btnSelectCCCDFolderLandTransfer;
        private TextBox txtSaveFolderLandTransfer;
        private Button btnSaveFolderLandTransfer;
        private Button btnScanLandTransfer;
        private RichTextBox txtErrorCCCDLandTransfer;
        private Label label1LandTransfer;
        private Button btnCancelLandTransfer;
        private Button btnResetLandTransfer;
        private CheckBox chkInputIssuePlaceLandTransfer;
        private TextBox txtPathToCccdLandChange;
        private Button btnSelectCCCDFolderLandChange;
        private TextBox txtSaveFolderLandChange;
        private Button btnSaveFolderLandChange;
        private Button btnScanLandChange;
        private RichTextBox txtErrorCCCDLandChange;
        private Label label1LandChange;
        private Button btnCancelLandChange;
        private Button btnResetLandChange;
        private CheckBox chkInputPhoneEmailLandChange;

        private TextBox txtPathToCccdLandUseChange;
        private Button btnSelectCCCDFolderLandUseChange;
        private TextBox txtSaveFolderLandUseChange;
        private Button btnSaveFolderLandUseChange;
        private Button btnScanLandUseChange;
        private RichTextBox txtErrorCCCDLandUseChange;
        private Label label1LandUseChange;
        private Button btnCancelLandUseChange;
        private Button btnResetLandUseChange;
        private CheckBox chkInputContactLandUseChange;
        private TextBox txtPathToCccdAttachedLand;
        private Button btnSelectCCCDFolderAttachedLand;
        private TextBox txtSaveFolderAttachedLand;
        private Button btnSaveFolderAttachedLand;
        private Button btnScanAttachedLand;
        private RichTextBox txtErrorCCCDAttachedLand;
        private Label label1AttachedLand;
        private Button btnCancelAttachedLand;
        private Button btnResetAttachedLand;
        private CheckBox chkInputPhoneEmailAttachedLand;
    }
}