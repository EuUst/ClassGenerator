namespace Pare_task
{
    internal class ClassField
    {
        public string Name { get; private set; }
        public string Type { get; private set; }
        public string Modificator { get; private set;}

        public ClassField(string name, string type, string modificator)
        {
            Name = name;
            Type = type;
            Modificator = modificator;  
        }
    }
}
