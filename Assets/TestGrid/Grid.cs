public class Grid
{
    private char[,] _grid;
    private int _width;
    private int _height;
    
    public int Height => _height;
    public int Width => _width;

    public Grid(int width, int height)
    {
        _width = width;
        _height = height;
        _grid = new char[width,height];
    }

    public void SetChar(int x, int y, char newChar)
    {
        _grid[x, y] = newChar;
    }

    public char GetChar(int x, int y)
    {
        return _grid[x, y];
    }
}
