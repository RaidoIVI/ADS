namespace ADS
{
    abstract class HomeWork
    {
        protected readonly string Lession;
        protected readonly string Name;
        protected readonly string Description;

        public HomeWork(string lession, string name, string description)
        {
            Lession = lession;
            Name = name;
            Description = description;
        }

        public virtual string GetLession()
        {
            return Lession;
        }

        public virtual string GetName()
        {
            return Name;
        }

        public virtual string GetDescription()
        {
            return Description;
        }

        public abstract void Run();

    }
}
