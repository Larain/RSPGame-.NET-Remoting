using System;
using System.Windows.Forms;
using RSPModel;

namespace RSPClient
{
    public partial class ChooseFigureForm : Form
    {
        public ChooseFigureForm()
        {
            InitializeComponent();
        }

        public Figure PlayerChoose { get; set; }

        private void btRock_Click(object sender, EventArgs e)
        {
            PlayerChoose = Figure.Rock;
            if (ActiveForm != null) ActiveForm.Close();
        }

        private void btScissors_Click(object sender, EventArgs e)
        {
            PlayerChoose = Figure.Scissors;
            if (ActiveForm != null) ActiveForm.Close();
        }

        private void btPaper_Click(object sender, EventArgs e)
        {
            PlayerChoose = Figure.Paper;
            if (ActiveForm != null) ActiveForm.Close();
        }
    }
}