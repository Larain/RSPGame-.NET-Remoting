using System;
using System.Windows.Forms;

namespace RSPClient
{
    public partial class PortForm : Form
    {
        public PortForm()
        {
            InitializeComponent();
        }

        public string Port
        {
            get { return tbInput.Text; }
            set { tbInput.Text = value; }
        }

        private void btEnter_Click(object sender, EventArgs e)
        {
            Port = tbInput.Text;
            if (ActiveForm != null) ActiveForm.Close();
        }
    }
}