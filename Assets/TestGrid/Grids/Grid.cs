namespace TestGrid.Grids
{
    public class Grid
    {
        private readonly char[,] _grid;
        public int Height { get; }
        public int Width { get; }

        public Grid(int width, int height)
        {
            Width = width;
            Height = height;
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
}
