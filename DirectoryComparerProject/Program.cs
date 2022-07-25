using DirectoryComparerProject.Processes;
using System.Xml;

namespace DirectoryComparerProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            XmlDocument xml = DirectoryComparer.Compare(@"C:\NewPath", @"C:\NewPath2");
        }
    }
}
