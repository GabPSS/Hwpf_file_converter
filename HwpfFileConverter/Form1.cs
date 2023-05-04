using HomeworkPlanner;
using System.Text.Json;

namespace HwpfFileConverter
{
    public partial class Form1 : Form
    {
        
        NewTaskSystem.NewSaveFile nTS;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog() { Title = "Select a save file...", Filter = "HWPF files|*.hwpf" };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                SaveFile OldSaveFile = SaveFile.FromJSON(File.ReadAllText(dialog.FileName));
                nTS = Converter.ConvertToNewTaskSystem(OldSaveFile);
                label1.Text = "Tasks: " + nTS.Tasks.Items.Count + "\nSubjects: " + nTS.Subjects.Items.Count;
                button2.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog() { Title = "Save file as...", Filter = "HWPF converted files|*.hwpf" };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(sfd.FileName, JsonSerializer.Serialize<NewTaskSystem.NewSaveFile>(nTS));
            }
        }
    }
}