using ChessLibrary;

    /// <summary>

    /// <summary>
        //row change -> step up 
        while (row >= 0)
                //Board.FigureNames.Contains(board[row, column][0].ToString())
                board[row, column].Any(x => char.IsLetter(x)) &&
            {
            {

        row = Row + 1;
        //row change -> step down
        while (row < 8)
            {
        //column change -> step left
        while (column >= 0)
            {

        column = Column + 1;
        //column change -> step right
        while (column < 8)
            {

        row = Row - 1;
        //diagonally left and up
        while (row >= 0 && column >= 0)
            {

        row = Row + 1;
        //diagonally right and down
        while (row < 8 && column < 8)
            {

        row = Row - 1;
        //diagonally right and up
        while (row >= 0 && column < 8)
            {

        row = Row + 1;
        //diagonally left and down
        while (row < 8 && column >= 0)
            {

    //collects figure's legal steps as two-digit integers into list
    public List<int> LegalStepsToArray(Board boardObj, IFigure queen)

    //the following mehtods of IFigure interface will be implemented upon need
    public bool IsProtected(Board boardObj, IFigure protectable)