using System;
using System.IO;
using FileTransferApi.Interface;
using static System.String;

namespace FileTransferApi.Service
{
    public class FileService : IFileService
    {
        private readonly object _fileLock = new object();
        public void EnterIntoFile(string someText, string fileName = "testFile.txt")
        {

            var mainPath = Concat("C://Test", "//");
            lock (_fileLock)
            {
                if (!Directory.Exists(mainPath)) 
                    Directory.CreateDirectory(mainPath);
                if (!File.Exists(Path.Combine(mainPath, fileName))) 
                    File.Create(Path.Combine(mainPath, fileName));

                File.AppendAllText(Path.Combine(mainPath, fileName), Concat(someText, Environment.NewLine));
            }
        }
    }
}
