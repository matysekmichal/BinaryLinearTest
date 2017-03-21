using System.IO;

namespace Projekt1
{
    public class SaveToFile
    {
        public FileStream Bundle { get; }
        public string Stream { get; private set; };

        SaveToFile(string fileName = "file")
        {
            Bundle = File.Create(fileName);
        }

        public void SetStream(string stream)
        {
            Stream = stream;
        }

        public void Save()
        {
            StreamWriter file = new StreamWriter(Bundle);
            file.WriteLine(Stream);
            Bundle.Dispose();
        }
    }
}