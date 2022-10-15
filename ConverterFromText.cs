namespace Pare_task
{
    internal class ConverterFromText
        /*
         Название класса не дает понимания о его сути. Конвертер из текста... во что?
        + программисты ленивые а буквы платные так что обычно слова From, Of не используют
        Предлагаемое название: TextToCSharpConverter, CSharpParser
         */
    {
        public ClassData ConvertFromTextToClassData(string path)
        {
            string[] lines = GetFile(path);

            string classNameLine = lines[0];
            string classFieldsLine = lines[1];
            var fields = GetAllFields(classFieldsLine);
            /*
            Использовать var в таком контексте не стоит, он *допустим* если сразу явно указать тип
            (var i = 7, var fields = new List<string>)
            В противном случае имя типа писать нужно
            (без IDE (в гите или редакторе текста) тип var смотреть будет неудобно)
             */

            string className = GetClassName(classNameLine);
            List<ClassField> classPrivateFields = GetPrivateFields(fields); //Можно упростить до privateFields
            List<ClassField> classProperties = GetPublicFields(fields); //Можно упростить до publicProperties

            return new ClassData(classPrivateFields, classProperties, className);
        }

        private string[] GetFile(string path)
            /*
             Делать алиасы для существующих методов это плохо потому что
            1) Вместо общеизвестного метода ты добавляешь свой который еще нужно искать
            2) Ты уменьшаешь его функционал, так как у метода изначально несколько перегрузок
             */
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
            //Если clearLines больше не используется то сохранять не обязательно, можно в одну строку 2 метода

            ClassField classField; //совершенно не ясно для чего она. Либо не нужна, либо имя непонятное

            List<ClassField> classFields = new List<ClassField>();

            string validatedName; //validated длинно и непонятно, достаточно valid или checked
            string validatedType;
            string validatedModificator;

            foreach(var word in fields) //Пока я читал я тыщу раз забыл про fields, лучше указать тип вместо var
            {
                var elements = word.Split(' '); 
                /*
                проблема var усугубилась, я не помнил что такое word, а теперь я не понимаю
                что такое elements
                 */
                
                validatedModificator = FieldElementsValidator.GetValidatedModificator(elements.Length);
                /*
                проблема объявления переменных заранее - я забыл какого она типа
                + здесь нет смысла объявлять все эти переменные (classField, validated строки) заранее
                Они вполне успешно могли быть объявлены в теле метода
                 */
                
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
                //Его не обязательно объявлять так, можно было просто сделать
                //classFields.Add(new ClassField(validatedName, validatedType, validatedModificator));
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
            //Я понимаю что это копипаст но почему private-то, тут публичные теперь же
            foreach (var item in classFields)
            {
                if (item.Modificator == "public") privateFields.Add(item);
            }

            return privateFields;
        }
    }
}
