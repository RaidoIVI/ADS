namespace ADS
{
    internal class Program
    {
        static void Main()
        {
            var homeWorkList = Launcher.Hw.GetList();
            if (homeWorkList.Length > 0)
            {
                string userEnter;
                do
                {
                    for (int i = 0; i < homeWorkList.Length; i++)
                    {
                        Io.SendLine($"{i + 1}. {homeWorkList[i]}");
                    }

                    userEnter = Io.Get("Введите номер строки для проверки, для выхода наберите -1: ");

                    if (int.TryParse(userEnter, out int userChoice))
                    {
                        if (userChoice - 1 < homeWorkList.Length && userChoice > 0)
                        {
                            Launcher.Hw.Run(userChoice - 1);
                        }
                    }
                }
                while (userEnter != "-1");

            }
        }
    }
}