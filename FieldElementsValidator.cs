namespace Pare_task
{
    internal class FieldElementsValidator
    {
        public static string GetValidatedType(string type)
        {
            Console.WriteLine(type);
            switch (type)
            {
                case "символ":
                    return "char";
                case "строка":
                    return "string";
                case "число":
                    return "int";
                case "флаг":
                    return "bool";
                default:
                    return "object";
            }
        }

        public static string GetValidatedName(string name, string modificator)
        {
            if(modificator == "private")   
                return name.ToLower();

            return (Char.ToUpper(name[0]) + name.Substring(1));
        }

        public static string GetValidatedModificator(int lineLength)
        {
            if (lineLength == 3) 
                return "private";
            return "public";
        }
    }
}
