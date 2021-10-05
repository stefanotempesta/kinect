using KinectQuizDesktop.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KinectQuizDesktop
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void buttonGB_Click(object sender, EventArgs e)
        {
            labelName.Text = "...";
            this.Refresh();

            MySpeechRecognizer recognizer = new MySpeechRecognizer(Language.English);

            string text = recognizer.Recognize();

            labelName.Text = text ?? "Not recognized, try again.";
        }

        private void buttonIT_Click(object sender, EventArgs e)
        {
            labelName.Text = "...";
            this.Refresh();

            MySpeechRecognizer recognizer = new MySpeechRecognizer(Language.Italian);
            string text = recognizer.Recognize();

            labelName.Text = text ?? "Not recognized, try again.";
        }
    }
}
