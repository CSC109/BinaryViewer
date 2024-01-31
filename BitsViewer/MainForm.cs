using System.Collections;
using System.Diagnostics;

namespace BitsViewer
{
    public partial class MainForm : Form
    {
        private string fileName;

        public MainForm()
        {
            InitializeComponent();
            binaryDisplay.Visible = false;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                binaryDisplay.Visible = false;
                return;
            }

            binaryDisplay.Visible = true;

            this.fileName = openFileDialog.FileName;
            this.Text = $"Binary Viewer - {fileName}";

            byte[] bytes = File.ReadAllBytes(fileName);

            string[] binaryValues = bytes.Select(byteValue => Convert.ToString(byteValue, 2).PadLeft(8, '0')).ToArray();

            foreach (string binaryValue in binaryValues)
            {
                binaryDisplay.AppendText(binaryValue + "    ");
            }
        }
    }
}