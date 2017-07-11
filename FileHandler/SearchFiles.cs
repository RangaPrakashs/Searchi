using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileHandler
{
    class SearchFiles
    {
        static string _FileName;
        public void PromptUser()
        {
            //Menu
            string _FileExtention;
            while(true)
            {
                Console.WriteLine("Enter The Name of File To Search");              
                string fileName = Console.ReadLine();
                Console.WriteLine("Enter File Extention");
                string fileExtention = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(fileName)|| (!string.IsNullOrWhiteSpace(fileExtention)))
                {
                    _FileName = fileName;
                    _FileExtention = fileExtention;
                    Console.WriteLine("Searching...");
                    SearchFileName(_FileName, _FileExtention);
                        break;
                }
                else
                {
                    Console.WriteLine("Invalid FileName");
                }
                
            }

        }

        public void SearchFileName(string FileName, string fileExtention)
        {
            string[] directories = Directory.GetDirectories("C:\\");
            //split Extention and File name
            var fileName = Path.GetFileName(FileName);

        }

        public static void AddFileNameToList(string sourceDir , List<string>allfiles)
        {
            string[] fileEntries = Directory.GetFiles(sourceDir);
            foreach(string fileName in fileEntries)
            {
                allfiles.Add(_FileName);

            }
            //Recursion
            string[] subdirectoryEntries = Directory.GetDirectories(sourceDir);
            foreach(string item in subdirectoryEntries)
            {
                //Avoid reparse Points
                if ((File.GetAttributes(item) & FileAttributes.ReparsePoint) != FileAttributes.ReparsePoint)
                {

                    AddFileNameToList(item, allfiles);

                }






            }



        }

    }
}
    