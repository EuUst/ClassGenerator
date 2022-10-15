namespace Pare_task
{
    internal class FieldElementsValidator
        /*
        Названия методов длинные, так как класс назвается Validator то можно не писать снова
        что он валидирует данные. Кстати класс можно сделать статическим
         */
    {
        public static string GetValidatedType(string type) 
        {
            Console.WriteLine(type);
            switch (type) //Можно заменить на switch-выражение
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
            if (modificator == "private")
                return name.ToLower(); //Некорректно, в camelCase слова начиная со второго с большой буквы
            //Изменяем только первую букву

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
