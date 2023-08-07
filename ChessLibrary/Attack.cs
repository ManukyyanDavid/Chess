using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;
using ChessLibrary.GameFigures;
namespace ChessLibrary;
public class Attack
{
    /// <summary>
    /// Depending on segment of black king, organizes 1st level attack(cutting black king from white king segment)
    /// Depending on segment two strategies for attack are proposed: Horizontal and Vertical.
    /// </summary>
    /// <param name="boardObj">Board type object representing chess board and everything related to it.</param>
    /// <returns>Returns new Board type object with 1st level attack implemented.</returns>
    public static Board FirstAttackBySegment(Board boardObj, string segment, List<IFigure> whiteAttackers)
    {
        int coordinate = 0;
        //HARD CODE
        IFigure bk = boardObj.Figures[4];
        switch (segment)
        {
            case "upper":
                {
                    coordinate = bk.Row + 1;
                    boardObj = HorizontalSegmentation(boardObj, coordinate, whiteAttackers,3);
                    break;
                }
            case "lower":
                {
                    coordinate = bk.Row - 1;
                    boardObj = HorizontalSegmentation(boardObj, coordinate, whiteAttackers,3);
                    break;
                }
            case "left":
                {
                    coordinate = bk.Column + 1;
                    boardObj = VerticalSegmentation(boardObj, coordinate, whiteAttackers);
                    break;
                }
            case "right":
                {
                    coordinate = bk.Column - 1;
                    boardObj = VerticalSegmentation(boardObj, coordinate, whiteAttackers);
                    break;
                }
        }
        return boardObj;
    }
    /// <summary>
    /// Organizes 2nd level attack placing a second white figure on the opposite side.
    /// </summary>
    /// <param name="boardObj">Board type object representing chess board and everything related to it.</param>
    /// <returns>Returns new Board type object with 1st level attack implemented.</returns>
    public static Board SecondAttackBySegment(Board boardObj, string segment, List<IFigure> whiteAttackers)
    {
        int coordinate = 0;
        //HARD CODE
        IFigure bk = boardObj.Figures[4];
        switch (segment)
        {
            case "upper":
                {
                    coordinate = bk.Row - 1;
                    boardObj = HorizontalSegmentation(boardObj, coordinate, whiteAttackers,2);
                    break;
                }
            case "lower":
                {
                    coordinate = bk.Row + 1;
                    boardObj = HorizontalSegmentation(boardObj, coordinate, whiteAttackers,2);
                    break;
                }
            case "left":
                {
                    coordinate = bk.Column - 1;
                    boardObj = VerticalSegmentation(boardObj, coordinate, whiteAttackers);
                    break;
                }
            case "right":
                {
                    coordinate = bk.Column + 1;
                    boardObj = VerticalSegmentation(boardObj, coordinate, whiteAttackers);
                    break;
                }
        }
        return boardObj;
    }
    /// <summary>
    /// Organizes 3rd level attack placing a third figure on black king row/coumn if black king stayed on the initial row.
    /// </summary>
    /// <param name="boardObj">Board type object representing chess board and everything related to it.</param>
    /// <returns>Returns new Board type object with 1st level attack implemented.</returns>
    public static Board ThirdAttackBySegment(Board boardObj, string segment, List<IFigure> whiteAttackers)
    {
        int coordinate = 0;
        //HARD CODE
        IFigure bk = boardObj.Figures[4];
        switch (segment)
        {
            case "upper":
            case "lower":
                {
                    coordinate = bk.Row;
                    boardObj = HorizontalSegmentation(boardObj, coordinate, whiteAttackers, 1);
                    break;
                }
            case "left":
            case "right":
                {
                    coordinate = bk.Column;
                    boardObj = VerticalSegmentation(boardObj, coordinate, whiteAttackers);
                    break;
                }
    
        }
        return boardObj;
    }
    /// <summary>
    /// Organizes 4th level placing a white figure on BK row/column, if Chack and Mate was not achieved on 3rd level of attack.
    /// This is the final stage of endgame.
    /// </summary>
    /// <param name="boardObj">Board type object representing chess board and everything related to it.</param>
    /// <returns>Returns new Board type object with 1st level attack implemented.</returns>
    public static Board FourthAttackBySegment(Board boardObj, string segment, List<IFigure> whiteAttackers)
    {
        int coordinate = 0;
        //HARD CODE
        IFigure bk = boardObj.Figures[4];
        switch (segment)
        {
            case "upper":
            case "lower":
                {
                    coordinate = bk.Row;
                    foreach (IFigure figure in whiteAttackers)  
                    {
                        if (Math.Abs(figure.Row - bk.Row) == 2)
                        {
                            whiteAttackers.Insert (0,figure);
                            boardObj = HorizontalSegmentation(boardObj, coordinate, whiteAttackers, 1);
                            break;
                        }
                    }
                    break;
                }
            case "left":
            case "right":
                {
                    coordinate = bk.Column;
                    foreach (IFigure figure in whiteAttackers)
                    {
                        if (Math.Abs(figure.Row - bk.Row) == 2)
                        {
                            boardObj = VerticalSegmentation(boardObj, coordinate, whiteAttackers);
                        }
                    }
                    break;
                }
        }
        return boardObj;
    }
    /// <summary>
    /// Devides the board in two base don the kings' positions. For upper & lower segmentation.
    /// </summary>
    /// <param name="boardObj">Board type object.</param>
    /// <returns>Returns Board type object to update the chess board.</returns>
    public static Board HorizontalSegmentation(Board boardObj, int coordinate, List<IFigure> whiteAttackers, int index1)
    {
        //
        foreach (IFigure _figure in whiteAttackers)
        {
            //checks if any item in the list/figure has already done a step, it is deleted from the list
            //and edded in the end
            if (_figure.Row == coordinate)
            {
                //update 
                EndGame.StepUpdate(whiteAttackers, _figure);
                
                //run new endgame with the updated list
                EndGame endgame = new EndGame(boardObj, whiteAttackers);
                boardObj = endgame.RunEndgame(boardObj, whiteAttackers);
                return boardObj;
            }
        }

        //HARD CODE
        IFigure bk = boardObj.Figures[4];
        bool shouldBreak = false;
        
        //
        int index = 0;
        
        foreach (IFigure figure in whiteAttackers)
        {
            if (index != index1)
            {
                for (int i = 0; i < 8; i++)
                {
                    if (boardObj.BoardWithFiguresSteps[coordinate, i] != null &&
                        boardObj.BoardWithFiguresSteps[coordinate, i].Contains(figure.StepSymbol)&&
                         boardObj.BoardWithFiguresSteps[coordinate, i].All(c => !char.IsLetter(c)))
                    {
                        if (Math.Abs(bk.Column - i) > 1)
                        {
                            if (Defence.CheckPat(boardObj, figure, coordinate, i) == false)
                            {
                                boardObj = Board.UpdateBoard(boardObj, boardObj.Figures, figure, coordinate, i);
                                switch (figure.Name)
                                {
                                    case "b":
                                        EndGame.StepUpdate(whiteAttackers, boardObj.Figures[1]);
                                        break;
                                    case "c":
                                        EndGame.StepUpdate(whiteAttackers, boardObj.Figures[2]);
                                        break;
                                    case "d":
                                        EndGame.StepUpdate(whiteAttackers, boardObj.Figures[3]);
                                        break;
                                }
                                shouldBreak = true;
                                //break;
                                
                                return boardObj;
                            }
                        }
                    }
                }
                index++;
            }
            else
            {
                boardObj=Improvements.ImprovePositonHorizontal(boardObj, whiteAttackers[0]);
                shouldBreak = true;
            }
            if (shouldBreak)
                break;
        }
        return boardObj;
    }
    /// <summary>
    /// Devides the board in two base don the kings' positions. For left & right segmentation.
    /// </summary>
    /// <param name="boardObj">Board type object.</param>
    /// <returns>Returns Board type object to update the chess board.</returns>
    public static Board VerticalSegmentation(Board boardObj, int coordinate, List<IFigure> whiteAttackers)
    {
        foreach (IFigure _figure in whiteAttackers)
        {
            if (_figure.Column == coordinate)
            {
                EndGame.StepUpdate(whiteAttackers, _figure);
                EndGame endgame = new EndGame(boardObj, whiteAttackers);
                break;
            }
        }

        IFigure[] figures = new IFigure[] { boardObj.Figures[1], boardObj.Figures[2], boardObj.Figures[3] };
        //HARD CODE
        IFigure bk = boardObj.Figures[4];
        bool shouldBreak = false;
        foreach (IFigure figure in whiteAttackers)
        {
            for (int i = 0; i < 8; i++)
            {
                if (boardObj.BoardWithFiguresSteps[i, coordinate] != null &&
                    boardObj.BoardWithFiguresSteps[i, coordinate].Contains(figure.StepSymbol))
                {
                    if (Math.Abs(bk.Row - i) >= 2)
                    {
                        if (Defence.CheckPat(boardObj, figure, i, coordinate) != true)
                        {
                            boardObj = Board.UpdateBoard(boardObj, boardObj.Figures, figure, i, coordinate);
                            EndGame.StepUpdate(whiteAttackers, figure);
                            shouldBreak = true;
                            break;
                        }
                    }
                }
            }
            if (shouldBreak)
                break;
        }
        return boardObj;
    }
}