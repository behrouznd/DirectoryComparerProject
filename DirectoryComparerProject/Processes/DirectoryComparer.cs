using System.Xml;

namespace DirectoryComparerProject.Processes
{
    static class DirectoryComparer
    {
        public static XmlDocument Compare(string oldPath, string newPath)
        {
            IOutput<XmlDocument> output = new XmlOutput();

            //List of changes
            ProcessDirectory processDirectory = new ProcessDirectory(oldPath, newPath);

            //Return changes as XML
            return output.Print(processDirectory.CompareDirectory());
        }


        
    }
}
