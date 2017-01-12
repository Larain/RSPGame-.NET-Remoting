using System;
using System.Windows.Forms;

namespace RSPClient
{
    public partial class PlayerName : Form
    {
        public PlayerName()
        {
            InitializeComponent();
        }

        public string PName
        {
            get { return tbInput.Text; }
            set { tbInput.Text = value; }
        }

        private void btEnter_Click(object sender, EventArgs e)
        {
            PName = tbInput.Text;
            ActiveForm?.Close();
        }
    }
}