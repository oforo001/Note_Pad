using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Note_Console_App
{
    internal class NoteMananger
    {
        List<Note> notes = new List<Note>();

        public NoteMananger()
        {
            notes = new List<Note>();
        }


        public void CreateNewNoteAndCheckExistensOfFile()
        {
            Note note = new Note();

            Console.Write("Create a Header name: ");
            note.Header = Console.ReadLine();
            bool ifHeaderExist = HeaderExist(note.Header);

            if (!ifHeaderExist)
            {
                Console.WriteLine("Give content: ");
                note.Body = Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Error,the Note with a same Headername alrady exist");
            }

            if (!ifHeaderExist)
            {
                notes.Add(note);
                string filepath = $@"D:\Training with Visual Studio\Note_Console_App\NotesDB\{note.Header}.txt";
                using (StreamWriter sw = new StreamWriter(filepath))
                {
                    sw.WriteLine(note.Header);
                    Console.WriteLine("______________________________");
                    Console.WriteLine(" ");
                    sw.WriteLine(note.Body);
                }
                Console.WriteLine("Note added successfully");
            }
            Console.ReadLine();

        }
        private bool HeaderExist(string targetHeader)
        {
            string filepath = $@"D:\Training with Visual Studio\Note_Console_App\NotesDB\{targetHeader}.txt";
            return File.Exists(filepath);
        }

        public void ReadFromFile()
        {
            Note note = new Note();

            Console.WriteLine("Chose the file witch you wont to read...\n");
            ListAllHeaders();
            note.Header = Console.ReadLine() + ".txt";
            string filePath = Path.Combine(@"D:\Training with Visual Studio\Note_Console_App\NotesDB", note.Header);
            if (File.Exists(filePath))
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string content = sr.ReadToEnd();
                    Console.WriteLine(content);
                }
                Console.ReadLine();
            }


        }
        public void EditExistingNote()
        {
            Note note = new Note();

            Console.WriteLine("Chose the file witch you wont to edit...\n");
            ListAllHeaders();
            note.Header = Console.ReadLine() + ".txt";

            string filePath = Path.Combine(@"D:\Training with Visual Studio\Note_Console_App\NotesDB", note.Header);

            if (File.Exists(filePath))
            {
                Process.Start("notepad.exe", filePath);
            }
            else
            {
                Console.WriteLine("File with this name can`t be find...");
            }

        }
        private void ListAllHeaders()
        {
            string path = @"D:\Training with Visual Studio\Note_Console_App\NotesDB";
            string[] files = Directory.GetFiles(path);
            foreach (string file in files)
            {
                string fileName = Path.GetFileNameWithoutExtension(file);
                Console.WriteLine(fileName);
            }

        }
    }
}
