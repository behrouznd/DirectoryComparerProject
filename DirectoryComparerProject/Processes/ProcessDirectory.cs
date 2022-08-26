using DirectoryComparerProject.Infrastructure;
using System.Collections.Generic;
using System.IO;

namespace DirectoryComparerProject.Processes
{
    public class ProcessDirectory
    {
        public string _oldPath { get; }
        public string _newPath { get; }

        public ProcessDirectory(string oldPath , string newPath)
        {
            _oldPath = oldPath;
            _newPath = newPath;
        }

        public List<DirectoryProcess> CompareDirectory()
        {
            List<DirectoryProcess> processList = new List<DirectoryProcess> ();
            Compare(_oldPath, _newPath, processList);
            return processList;
        }


        private void Compare(string oldDir, string newDir, List<DirectoryProcess> processList)
        {
            string[] oldDireEntries;
            //Find deleted folders
            if (Directory.Exists(oldDir))
            {
                oldDireEntries = Directory.GetDirectories(oldDir);
                foreach (string subdir in oldDireEntries)
                {
                    Compare(subdir, subdir.Replace(oldDir, newDir), processList);
                    if (!Directory.Exists(subdir.Replace(oldDir, newDir)))
                    {
                        processList.Add(new DirectoryProcess { TypeFile = TypeFile.dir, Path = subdir.Replace(_oldPath ,"" ), State = FileState.Delete });
                    }
                }
            }

            //Find created folders
            string[] newDireEntries;
            if (Directory.Exists(newDir))
            {
                newDireEntries = Directory.GetDirectories(newDir);
                foreach (string subdir in newDireEntries)
                {
                    if (!Directory.Exists(subdir.Replace(newDir, oldDir)))
                    {
                        processList.Add(new DirectoryProcess { TypeFile = TypeFile.dir, Path = subdir.Replace(_newPath,""), State = FileState.Create });
                        Compare(subdir.Replace(newDir , oldDir), subdir, processList);
                    }
                   
                }
            }

            //Find Deleted files
            string[] oldfileEntries;
            if (Directory.Exists(oldDir))
            {
                oldfileEntries = Directory.GetFiles(oldDir);
                foreach (string fileName in oldfileEntries)
                {
                    if (!File.Exists(fileName.Replace(oldDir, newDir)))
                    {
                        processList.Add(new DirectoryProcess { TypeFile = TypeFile.file, Path = fileName.Replace(_oldPath , ""), State = FileState.Delete });
                    }
                }

            }

            //Find created files
            string[] newfileEntries;
            if (Directory.Exists(newDir))
            {
                newfileEntries = Directory.GetFiles(newDir);
                foreach (string fileName in newfileEntries)
                {
                    if (!File.Exists(fileName.Replace(newDir, oldDir)))
                    {
                        processList.Add(new DirectoryProcess { TypeFile = TypeFile.file, Path = fileName.Replace(_newPath,""), State = FileState.Create });
                    }
                }
            }
        }


    }
}
