using ChessLibrary.GameFigures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessLibrary;


namespace ChessLibrary;

public class Improvements
{
    public static Board ImprovePositonHorizontal(Board boardObj, IFigure figure)
    {
        IFigure bk = boardObj.Figures[4];
        bool check = false;
        if (bk.Column <= 3)
        {
            for (int i = 7; i > 3; i--)
            {
                if (boardObj.BoardWithFiguresSteps[figure.Row, i].Contains(figure.StepSymbol) &&
                    !boardObj.BoardWithFiguresSteps[figure.Row, i].Contains("a") &&
                    !boardObj.BoardWithFiguresSteps[figure.Row, i].Contains("b") &&
                    !boardObj.BoardWithFiguresSteps[figure.Row, i].Contains("c") &&
                    !boardObj.BoardWithFiguresSteps[figure.Row, i].Contains("d"))
                {
                   // check if in column there are any other figures
                    //for (int j = 0; j < 7; j++)
                    //{
                    //    if (boardObj.BoardWithFiguresSteps[j, i].Contains("b") ||
                    //        boardObj.BoardWithFiguresSteps[j, i] ==null ||
                    //         boardObj.BoardWithFiguresSteps[j, i].Contains("c") ||
                    //         boardObj.BoardWithFiguresSteps[j, i].Contains("d"))
                    //    {
                    //        check = true;
                    //        break;
                    //    }
                    //}
                    //if (!check)
                    //{
                        boardObj = Board.UpdateBoard(boardObj, boardObj.Figures, figure, figure.Row, i);
                        break;
                    //}
                    //check= false;
                }
            }
        }
        else
        {
            for (int i = 0; i < 4; i++)
            {
                if (boardObj.BoardWithFiguresSteps[figure.Row, i].Contains(figure.StepSymbol) &&
                    !boardObj.BoardWithFiguresSteps[figure.Row, i].Contains("a") &&
                    !boardObj.BoardWithFiguresSteps[figure.Row, i].Contains("b") &&
                    !boardObj.BoardWithFiguresSteps[figure.Row, i].Contains("c") &&
                    !boardObj.BoardWithFiguresSteps[figure.Row, i].Contains("d"))
                {
                    boardObj = Board.UpdateBoard(boardObj, boardObj.Figures, figure, figure.Row, i);
                    break;
                }
            }
        }
        return boardObj;
    }
}
