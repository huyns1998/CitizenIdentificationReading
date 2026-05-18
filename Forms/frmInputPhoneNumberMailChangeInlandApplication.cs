using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CitizenIdentificationReading.Forms
{
    public partial class frmInputPhoneNumberMailChangeInlandApplication : Form
    {
        private List<string> _names;
        private CheckBox _parentCheckBox;
        public Dictionary<int, string> PhoneNumbers { get; private set; } = new Dictionary<int, string>();
        public Dictionary<int, string> Emails { get; private set; } = new Dictionary<int, string>();

        public frmInputPhoneNumberMailChangeInlandApplication(List<string> names, CheckBox parentCheckBox = null)
        {
            InitializeComponent();
            _names = names;
            _parentCheckBox = parentCheckBox;

            if (_parentCheckBox != null)
            {
                chkSyncPhoneEmail.Checked = _parentCheckBox.Checked;
                chkSyncPhoneEmail.CheckedChanged += (s, e) => {
                    _parentCheckBox.Checked = chkSyncPhoneEmail.Checked;
                };
            }

            GenerateInputs();
        }

        private void GenerateInputs()
        {
            for (int i = 0; i < _names.Count; i++)
            {
                // Title/Name label
                var lblName = new Label
                {
                    Text = $"{i + 1}. {_names[i]}",
                    Font = new Font(this.Font, FontStyle.Bold),
                    Width = 440,
                    Margin = new Padding(0, 10, 0, 2)
                };
                pnlInputs.Controls.Add(lblName);

                // Horizontal container for Phone and Email fields
                var pnlFields = new FlowLayoutPanel
                {
                    FlowDirection = FlowDirection.LeftToRight,
                    Width = 440,
                    Height = 30,
                    Margin = new Padding(0, 0, 0, 5),
                    WrapContents = false
                };

                // Phone Label & TextBox
                var lblPhone = new Label
                {
                    Text = "SĐT:",
                    Width = 40,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Margin = new Padding(0, 5, 0, 0)
                };
                var txtPhone = new TextBox
                {
                    Width = 150,
                    Tag = "phone_" + i
                };

                // Email Label & TextBox
                var lblEmail = new Label
                {
                    Text = "Email:",
                    Width = 50,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Margin = new Padding(10, 5, 0, 0)
                };
                var txtEmail = new TextBox
                {
                    Width = 180,
                    Tag = "email_" + i
                };

                pnlFields.Controls.Add(lblPhone);
                pnlFields.Controls.Add(txtPhone);
                pnlFields.Controls.Add(lblEmail);
                pnlFields.Controls.Add(txtEmail);

                pnlInputs.Controls.Add(pnlFields);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // Collect all inputs
            foreach (Control outerCtrl in pnlInputs.Controls)
            {
                if (outerCtrl is FlowLayoutPanel pnlFields)
                {
                    string phoneVal = "";
                    string emailVal = "";
                    int index = -1;

                    foreach (Control ctrl in pnlFields.Controls)
                    {
                        if (ctrl is TextBox txt && txt.Tag is string tag)
                        {
                            if (tag.StartsWith("phone_"))
                            {
                                phoneVal = txt.Text;
                                int.TryParse(tag.Substring(6), out index);
                            }
                            else if (tag.StartsWith("email_"))
                            {
                                emailVal = txt.Text;
                                int.TryParse(tag.Substring(6), out index);
                            }
                        }
                    }

                    if (index >= 0)
                    {
                        PhoneNumbers[index] = phoneVal;
                        Emails[index] = emailVal;
                    }
                }
            }

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
