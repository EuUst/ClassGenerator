using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pare_task
{
    internal class CSFileCreater
    {
        public void CreateCSFile(ClassData data, string path)
        {
            string endOfString = ";";

            string firstLine = $"namespace {data.ClassName}";
            string namespaceOpen = "\n" + "{";
            string className = "\n"+ "\t" + "class " + data.ClassName;
            string classOpen = "\n" + "\t{";
            string privateFields = "";
            string publicFields = "";
            foreach(var privateField in data.PrivateClassFields)
            {
                privateFields += "\n" + "\t\t" + privateField.Modificator + " " + privateField.Type + " " + privateField.Name + endOfString;
            }
            foreach (var publicField in data.PublicClassFields)
            {
                publicFields += "\n" + "\t\t" + publicField.Modificator + " " + publicField.Type + " " + publicField.Name + " { get; set; }";
            }

            string classClose = "\n" + "\t}";

            string namespaceClose = "\n" + "}";

            string[] file = new string[] { firstLine, namespaceOpen, className, classOpen, privateFields, 
                                           publicFields, classClose, namespaceClose };
            File.WriteAllLines(path, file);
        }
    }
}
