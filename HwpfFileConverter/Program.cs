using System.Text.Json;
using HomeworkPlanner;

namespace HwpfFileConverter
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            
            if (args.Length == 2) {
                Console.WriteLine("Converting project from .NET hwpf to dart hwpf...");
                SaveFile OldSaveFile = SaveFile.FromJSON(File.ReadAllText(args[0]));
                NewTaskSystem.NewSaveFile newSaveFile = Converter.ConvertToNewTaskSystem(OldSaveFile);
                File.WriteAllText(args[1], JsonSerializer.Serialize<NewTaskSystem.NewSaveFile>(newSaveFile));
                Console.WriteLine("Success");
            }
            else {
                Console.WriteLine("Usage: HwpfFileConverter <old_file> <new_file>\n");
            }
        }
    }
}