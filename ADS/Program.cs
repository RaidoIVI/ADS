namespace ADS
{
    internal class Program
    {
        static void Main()
        {
            var homeWorkList = Launcher.HW.GetList();
            if (homeWorkList.Length > 0)
            {
                string userEnter;
                do
                {
                    for (int i = 0; i < homeWorkList.Length; i++)
                    {
                        IO.SendLine($"{i + 1}. {homeWorkList[i]}");
                    }

                    userEnter = IO.Get("Введите номер строки для проверки, для выхода наберите -1: ");

                    if (int.TryParse(userEnter, out int userChoice))
                    {
                        if (userChoice - 1 < homeWorkList.Length && userChoice > 0)
                        {
                            Launcher.HW.Run(userChoice - 1);
                        }
                    }
                }
                while (userEnter != "-1");

            }
        }
    }
}