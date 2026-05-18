namespace CitizenIdentificationReading.Forms
{
    public partial class frmInputIssuePlace : Form
    {
        private List<string> _names;
        private CheckBox _parentCheckBox;
        public Dictionary<int, string> IssuePlaces { get; private set; } = new Dictionary<int, string>();

        public frmInputIssuePlace(List<string> names, CheckBox parentCheckBox = null)
        {
            InitializeComponent();
            _names = names;
            _parentCheckBox = parentCheckBox;

            if (_parentCheckBox != null)
            {
                chkSyncIssuePlace.Checked = _parentCheckBox.Checked;
                chkSyncIssuePlace.CheckedChanged += (s, e) => {
                    _parentCheckBox.Checked = chkSyncIssuePlace.Checked;
                };
            }

            GenerateInputs();
        }

        private void GenerateInputs()
        {
            for (int i = 0; i < _names.Count; i++)
            {
                var lbl = new Label { Text = $"{i + 1}. {_names[i]}", Width = 400, Margin = new Padding(0, 10, 0, 0) };
                var txt = new TextBox { Width = 400, Tag = i };
                pnlInputs.Controls.Add(lbl);
                pnlInputs.Controls.Add(txt);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in pnlInputs.Controls)
            {
                if (ctrl is TextBox txt && txt.Tag is int index)
                {
                    IssuePlaces[index] = txt.Text;
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
