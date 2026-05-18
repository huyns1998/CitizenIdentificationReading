using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CitizenIdentificationReading.Forms
{
    public partial class frmInputMailAndPhoneNumberAttachedLand : Form
    {
        private CheckBox _parentCheckBox;
        public string PhoneNumber { get; private set; } = "";
        public string Email { get; private set; } = "";

        public frmInputMailAndPhoneNumberAttachedLand(List<string> names, CheckBox parentCheckBox = null)
        {
            InitializeComponent();
            _parentCheckBox = parentCheckBox;

            if (_parentCheckBox != null)
            {
                chkSyncPhoneEmail.Checked = _parentCheckBox.Checked;
                chkSyncPhoneEmail.CheckedChanged += (s, e) => {
                    _parentCheckBox.Checked = chkSyncPhoneEmail.Checked;
                };
            }

            pnlInputs.Controls.Add(lblPhone);
            pnlInputs.Controls.Add(txtPhone);
            pnlInputs.Controls.Add(lblEmail);
            pnlInputs.Controls.Add(txtEmail);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            PhoneNumber = txtPhone.Text.Trim();
            Email = txtEmail.Text.Trim();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
