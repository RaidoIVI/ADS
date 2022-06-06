namespace Launcher
{
    public interface IHomeWork
    {
        public string Name { get; }

        public string Lession { get; }

        public string Description { get; }

        public void Run();
    }
}
