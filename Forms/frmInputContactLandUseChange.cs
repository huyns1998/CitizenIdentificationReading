using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CitizenIdentificationReading.Forms
{
    public partial class frmInputContactLandUseChange : Form
    {
        private List<string> _names;
        private CheckBox _parentCheckBox;
        private TextBox txtContactInput;
        public string ContactText { get; private set; } = "";

        public frmInputContactLandUseChange(List<string> names, CheckBox parentCheckBox = null)
        {
            InitializeComponent();
            _names = names;
            _parentCheckBox = parentCheckBox;

            if (_parentCheckBox != null)
            {
                chkSyncContact.Checked = _parentCheckBox.Checked;
                chkSyncContact.CheckedChanged += (s, e) => {
                    _parentCheckBox.Checked = chkSyncContact.Checked;
                };
            }

            GenerateInputs();
        }

        private void GenerateInputs()
        {
            // Static Label
            var lblContact = new Label
            {
                Text = "Nhập thông tin liên hệ:",
                Font = new Font(this.Font, FontStyle.Bold),
                Width = 440,
                Margin = new Padding(0, 15, 0, 5),
                AutoSize = true
            };
            pnlInputs.Controls.Add(lblContact);

            // Single Contact TextBox
            txtContactInput = new TextBox
            {
                Width = 440,
                PlaceholderText = "Nhập SĐT, email, fax...",
                Margin = new Padding(0, 5, 0, 5)
            };
            pnlInputs.Controls.Add(txtContactInput);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            ContactText = txtContactInput.Text.Trim();
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
