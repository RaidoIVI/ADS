using System.Reflection;

namespace ADS
{
    internal static class ChessmanInit
    {
        public static void Run()
        {
            Queue<IChessman> chessman = new();
            List<Type> tmp = new();
            tmp.AddRange(Assembly.GetExecutingAssembly().GetTypes());
            for (int i = 0; i < tmp.Count; i++)
            {
                if (tmp[i].GetInterfaces().Where(t => t == typeof(IChessman)).ToList().Count > 0)
                {
                    var tmpOject = Activator.CreateInstance(tmp[i]);
                    if (((IChessman)tmpOject).Code != 0)
                    {
                        var userEnter = IO.Get($"Фигура {((IChessman)tmpOject).Name} Введите количество для помещения на доску: ");
                        if (int.TryParse(userEnter, out int userChoice))
                        {
                            for (int j = 0; j < userChoice; j++)
                            {
                                chessman.Enqueue(Activator.CreateInstance(tmp[i]) as IChessman);
                            }
                        }
                    }
                }
            }

            IO.SendLine();
            int x = int.Parse(IO.Get("Введите размер по X: "));
            int y = int.Parse(IO.Get("Введите размер по Y: "));
            IO.SendLine();

            ChessEnum.Init(x, y);
            ChessEnum.Start(chessman);

            IO.SendLine();
            IO.SendLine($"Всего найдено {ChessEnum.Result.Count} вариантов");
            if ("y" != IO.Get("Для отображения вариантов нажмите y").ToLower()) return;
            foreach (Board board in ChessEnum.Result)
            {
                board.Draw();
            }
            IO.SendLine();
        }
    }
}
