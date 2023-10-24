using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OtusHomework17
{
    public class FileSearcher
    {
        public event EventHandler<FileFoundArgs>? FileFound;
        public event Action? SearchCancelled;



        public void Search(string directoryPath)
        {
            try
            {
                foreach (var file in Directory.GetFiles(directoryPath, "*", SearchOption.AllDirectories))
                {
                    var args = RaiseFileFound(file);

                    if (args.CancelRequested)
                    {
                        SearchCancelled?.Invoke();
                        break; 
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private FileFoundArgs RaiseFileFound(string fileName)
        {
            var args = new FileFoundArgs(fileName);
            FileFound?.Invoke(this, args);
            return args;
        }

    }


    public class FileFoundArgs : EventArgs
    {
        public string FileName { get; }
        public bool CancelRequested { get; set; }

        public FileFoundArgs(string fileName) => FileName = fileName;
        
    }
}
