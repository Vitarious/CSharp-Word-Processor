using System;
namespace CSharp_Word_Processor
{
    public partial class Form1 : Form
    {
        string fileLocationString = "";
        string filePath = "";
        string[] paths = Environment.GetCommandLineArgs();

        public Form1()
        {
            InitializeComponent();

            if (paths.Length > 1)
            {
                filePath = Environment.GetCommandLineArgs()[1];
            }

            if (filePath != "")
            {
                System.IO.StreamReader sr = new System.IO.StreamReader(filePath);
                richTextBox1.Text = sr.ReadToEnd();
                fileLocationString = filePath;
                this.Text = "C# Word Processor                                                     " + filePath;
                sr.Close();
            }

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            fileLocationString = "";
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files (.txt)|*.txt";
            openFileDialog.Title = "Open a File...";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamReader sr = new System.IO.StreamReader(openFileDialog.FileName);
                richTextBox1.Text = sr.ReadToEnd();
                fileLocationString = openFileDialog.FileName;
                this.Text = "C# Word Processor                                                     " + openFileDialog.FileName;
                sr.Close();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if(fileLocationString == "")
            {
                saveFileDialog.Filter = "Text Files (.txt)|*.txt";
                saveFileDialog.Title = "Save File...";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    System.IO.StreamWriter sr = new System.IO.StreamWriter(saveFileDialog.FileName);
                    sr.Write(richTextBox1.Text);
                    fileLocationString = saveFileDialog.FileName;
                    sr.Close();
                }
            }
            else
            {
                System.IO.StreamWriter sr = new System.IO.StreamWriter(fileLocationString);
                sr.Write(richTextBox1.Text);
                fileLocationString = saveFileDialog.FileName;
                sr.Close();
            }

        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files (.txt)|*.txt";
            saveFileDialog.Title = "Save File...";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamWriter sr = new System.IO.StreamWriter(saveFileDialog.FileName);
                sr.Write(richTextBox1.Text);
                fileLocationString = saveFileDialog.FileName;
                sr.Close();
            }
        }

    }
}