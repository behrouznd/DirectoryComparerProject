using DirectoryComparerProject.Processes;
using System.Xml;

namespace DirectoryComparerProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            XmlDocument xml = DirectoryComparer.Compare(@"C:\New folder", @"C:\New folder (2)");
        }
    }
}
