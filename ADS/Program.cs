namespace ADS
{
    internal class Program
    {
        static void Main()
        {
            var HomeWorkList = Launcher.HW.GetList();
            if (HomeWorkList.Length > 0)
            {
                string UserEnter;
                do
                {
                    for (int i = 0; i < HomeWorkList.Length; i++)
                    {
                        IO.SendLine($"{i + 1}. {HomeWorkList[i]}");
                    }

                    UserEnter = IO.Get("Введите номер строки для проверки, для выхода наберите -1: ");

                    if (int.TryParse(UserEnter, out int UserChoice))
                    {
                        if (UserChoice - 1 < HomeWorkList.Length && UserChoice > 0)
                        {
                            Launcher.HW.Run(UserChoice - 1);
                        }
                    }
                }
                while (UserEnter != "-1");

            }
        }
    }
}