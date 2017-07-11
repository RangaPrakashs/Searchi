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
        static string _SourceFolder;
        string tempSource;
        string tempFileName;
        public void PromptUser()
        {
            //Menu
            while (true)
            {
                Console.WriteLine("Enter a File Name to Search");
                 tempFileName = Console.ReadLine();
                if(!string.IsNullOrWhiteSpace(tempFileName))
                {
                    _FileName = tempFileName;
                    Console.WriteLine("Enter a Source Folder!");
                    tempSource = Console.ReadLine();
                    if (System.IO.Directory.Exists(tempSource))
                    {                        
                        _SourceFolder = tempSource;
                        Console.WriteLine("Success");
                        break;
                    }else
                    {
                        Console.WriteLine("Directory doesn't Exist");
                        continue;
                    }                                       

                }else
                {
                    Console.WriteLine("File names cannot be empty!");
                }

            }
        }

        public void SearchFileName(string FileName, string sourceFolder)
        {
            List<string> allFiles = new List<string>();
            AddFileNamesToList(sourceFolder, allFiles);        

        }

        public static string FindFile(string fileName, List<string> allFiles)
        {
                        

            return null;

        }

        public static void AddFileNamesToList(string sourceFolder, List<string> allFiles)
        {
            string[] fileEntries = Directory.GetFiles(sourceFolder);
            foreach(string fileName in fileEntries)
            {
                allFiles.Add(fileName);
            }
            string[] subDirectoryEntries = Directory.GetDirectories(sourceFolder);
            foreach(string fileName in fileEntries)
            {
                if ((File.GetAttributes(fileName) & FileAttributes.ReparsePoint)!= FileAttributes.ReparsePoint)
                {
                    allFiles.Add(fileName);

                }
            }
            FindFile(_FileName, allFiles);
        }
        
        
    }
}
    