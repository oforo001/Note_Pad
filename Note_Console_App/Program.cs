using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Diagnostics;
using Note_Console_App;

class Program
{
    static void Main(string[] args)
    {
        NoteMananger noteMananger = new NoteMananger();
        List<string>headers = new List<string>();

        do
        {
            Console.WriteLine("\n\t\tWelcome to my Program 'NOTE'\n");
            Console.WriteLine("1. Create new note");
            Console.WriteLine("2. Read the note");
            Console.WriteLine("3. Edit existing note");
            Console.WriteLine("0. Exit");
            Console.Write("Press [1/2/3/0]: ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        noteMananger.CreateNewNoteAndCheckExistensOfFile();
                        break;
                    case 2:
                        noteMananger.ReadFromFile();
                        break;
                    case 3:
                       noteMananger.EditExistingNote();
                        break;
                    case 0:
                        Environment.Exit(0);
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid option.");
            }

            Console.WriteLine("\nPress Enter to continue...");
            Console.ReadLine();          
            Console.Clear();
        }
        while (true);
    }
}


   