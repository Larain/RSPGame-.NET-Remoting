using System;
using System.Windows.Forms;

namespace RSPClient
{
    public partial class ChooseFigureForm : Form
    {
        public ChooseFigureForm()
        {
            InitializeComponent();
        }

        public string PlayerChoose { get; set; }

        private void btRock_Click(object sender, EventArgs e)
        {
            PlayerChoose = "rock";
            if (ActiveForm != null) ActiveForm.Close();
        }

        private void btScissors_Click(object sender, EventArgs e)
        {
            PlayerChoose = "scissors";
            if (ActiveForm != null) ActiveForm.Close();
        }

        private void btPaper_Click(object sender, EventArgs e)
        {
            PlayerChoose = "paper";
            if (ActiveForm != null) ActiveForm.Close();
        }
    }
}