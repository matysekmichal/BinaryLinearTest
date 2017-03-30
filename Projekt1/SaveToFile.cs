using System;
using System.IO;

namespace Projekt1
{
    public class SaveToFile
    {
        public FileStream Bundle { get; }
        public string Stream { get; set; }

        public SaveToFile(string fileName = "file.txt")
        {
            Bundle = File.Create(fileName);
        }

        public void SetStream(string stream)
        {
            Stream += stream + "\n";
        }

        public void Save()
        {
            StreamWriter file = new StreamWriter(Bundle);
            file.WriteLine(Stream);
            file.Dispose();
        }
    }
}