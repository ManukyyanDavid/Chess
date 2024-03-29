﻿namespace ChessProject;
using ChessLibrary;
using ChessLibrary.GameFigures;

using ChessLibrary;
public class Game02
{
    public void RunGame()
    {
        //get user input for figures, create board object.
        Board boardObj = new Board(UserDataHandler.GetFigures02());
        List<IFigure> whiteAttackers = new List<IFigure>();
        whiteAttackers.Add(boardObj.Figures[1]);
        whiteAttackers.Add(boardObj.Figures[2]);
        //runs the endgame while chack&mate is not achieved.
        while (Defence.CheckShakhAndMate(boardObj, boardObj.Figures[4]) == false)
        {
            BoardIllustrator.PrintBoard(boardObj.BoardWithFiguresSteps);
            //if black king is under attack, write a message 
            if (Defence.IsUnderShakh(boardObj, boardObj.Figures[4])) //BUG
                Console.WriteLine("King is under attack !!!!!");

            //input BK new position and move on the board
            boardObj = new Board(UserDataHandler.MoveBlackKing(boardObj, whiteAttackers));
            BoardIllustrator.PrintBoard(boardObj.BoardWithFiguresSteps);
            Board.BoardPrinterForDebug(boardObj.BoardWithFiguresSteps);

            //pass the board object to endgame class, create an endgame object
            EndGame endgame = new EndGame(boardObj, whiteAttackers);
            boardObj = endgame.RunEndgame02(boardObj, whiteAttackers);
        }
        BoardIllustrator.PrintBoard(boardObj.BoardWithFiguresSteps);
        Console.BackgroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("Game is Over!!!");
        Console.BackgroundColor = ConsoleColor.White;


    }
}