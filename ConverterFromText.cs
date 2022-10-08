namespace Pare_task
{
    internal class ConverterFromText
    {
        public ClassData ConvertFromTextToClassData(string path)
        {
            string[] lines = GetFile(path);

            string classNameLine = lines[0];
            string classFieldsLine = lines[1];
            var fields = GetAllFields(classFieldsLine);

            string className = GetClassName(classNameLine);
            List<ClassField> classPrivateFields = GetPrivateFields(fields);
            List<ClassField> classProperties = GetPublicFields(fields);

            return new ClassData(classPrivateFields, classProperties, className);
        }

        private string[] GetFile(string path)
        {
            return File.ReadAllLines(path);
        }

        private string GetClassName(string classNameLine)
        {
            return classNameLine.Split(' ')[1];
        }

        private List<ClassField> GetAllFields(string classFieldsLine)
        {
            string[] clearLines = classFieldsLine.Split(": ");
            string[] fields = clearLines[1].Split(", ");

            ClassField classField;

            List<ClassField> classFields = new List<ClassField>();

            string validatedName;
            string validatedType;
            string validatedModificator;

            foreach(var word in fields)
            {
                var elements = word.Split(' ');      
                
                validatedModificator = FieldElementsValidator.GetValidatedModificator(elements.Length);
                
                if(elements.Length == 3)
                {
                    validatedName = FieldElementsValidator.GetValidatedName(elements[2], validatedModificator);
                    validatedType = FieldElementsValidator.GetValidatedType(elements[1]);
                }
                else
                {
                    validatedName = FieldElementsValidator.GetValidatedName(elements[1], validatedModificator);
                    validatedType = FieldElementsValidator.GetValidatedType(elements[0]);
                }

                classField = new ClassField(validatedName, validatedType, validatedModificator);
                classFields.Add(classField);
            }
            return classFields;
        }

        private List<ClassField> GetPrivateFields(List<ClassField> classFields)
        {
            List<ClassField> privateFields = new List<ClassField>();
            foreach(var item in classFields)
            {
                if (item.Modificator == "private") privateFields.Add(item);
            }

            return privateFields;
        }
        private List<ClassField> GetPublicFields(List<ClassField> classFields)
        {
            List<ClassField> privateFields = new List<ClassField>();
            foreach (var item in classFields)
            {
                if (item.Modificator == "public") privateFields.Add(item);
            }

            return privateFields;
        }
    }
}
