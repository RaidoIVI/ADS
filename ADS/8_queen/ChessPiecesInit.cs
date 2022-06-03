using System.Reflection;

namespace ADS
{
    internal class ChessPiecesInit
    {
        internal ChessPiecesInit()
        {
            List<Type> chessPieceTypeList = new();
            chessPieceTypeList.AddRange(Assembly.GetExecutingAssembly().GetTypes()); //.Where(t => t is IChessPiece));

            Queen q = new(0, 0);

            List<IChessPiece> chessPiece = new();

            //var w = q is IChessPiece;

            //chessPiece.Add(q);

            //IO.SendLine(Queen.Description);
            for (int i = 0; i < chessPieceTypeList.Count; i++)
            {
                if (chessPieceTypeList is IChessPiece) chessPiece.Add(chessPieceTypeList as IChessPiece);
            }


            IO.SendLine("Выберете фигуру:");
            //string name;
            //string description;

            //for (int i = 0; i < chessPieceTypeList.Count; i++)
            //{
            //    IO.SendLine($"{i + 1}. {(chessPieceTypeList[i] as IChessPiece).Name} {(chessPieceTypeList[i] as IChessPiece).Description}");
            //}

        }
    }
}
