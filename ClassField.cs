namespace Pare_task
{
    internal class ClassField
    {
        public string Name { get; private set; }
        public string Type { get; private set; }
        public string Modificator { get; private set;} //Это называется Modifyer

        public ClassField(string name, string type, string modificator)
        {
            Name = name;
            Type = type;
            Modificator = modificator;  
        }
        /*
        Если значение свойства устанавливается в конструкторе то сеттер не нужен
        + для классов данных можно использовать record, они более краткие и неизменяемые

        public record ClassField(string Name, string Type, string Modifyer)

        он автоматически создаст все свойства с { get; init; }, позволяя устанавливать
        значения в конструкторе через названия полей

        ClassField result = new ClassField()
        {
            Name = name,
            Type = type,
            Modifyer = modifyer
        };

        Советую также узнать про перегрузки методов и перегрузить .ToString для вывода
         */
    }
}
