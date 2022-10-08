using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pare_task
{
    internal class ClassData
    {
        public List<ClassField> PrivateClassFields { get; private set; }
        public List<ClassField> PublicClassFields { get; private set; }
        public string ClassName { get; private set; }

        public ClassData(List<ClassField> privateClassFields, List<ClassField> publicClassFields, string className)
        {
            PrivateClassFields = privateClassFields;
            PublicClassFields = publicClassFields;
            ClassName = className;
        }
    }
}
