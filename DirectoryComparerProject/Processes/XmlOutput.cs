using DirectoryComparerProject.Infrastructure;
using System;
using System.Collections.Generic;
using System.Xml;

namespace DirectoryComparerProject.Processes
{
    public class XmlOutput : IOutput<XmlDocument>
    {
        public XmlDocument Print(List<DirectoryProcess> directoryProcesses)
        {
            XmlDocument xml = new XmlDocument();

            XmlDeclaration xmlDeclaration = xml.CreateXmlDeclaration("1.0", "UTF-8", null);


            XmlElement root = xml.DocumentElement;
            xml.InsertBefore(xmlDeclaration, root);
            XmlElement element1 = xml.CreateElement(string.Empty, "Diff", string.Empty);
            xml.AppendChild(element1);


            foreach (var item in directoryProcesses)
            {
                Console.WriteLine($"<{item.State.ToString()} {item.TypeFile.ToString()}=\"{ item.Path  }\"/>");

                XmlElement element2 = xml.CreateElement(string.Empty, item.State.ToString(), string.Empty);
                element2.SetAttribute(item.TypeFile.ToString(), item.Path);
                element1.AppendChild(element2);

            }

            return xml;
        }
    }
}
