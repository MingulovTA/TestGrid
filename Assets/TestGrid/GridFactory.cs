public static class GridFactory
{
    public static Grid GenerateRandomGrid(int width, int height)
    {
        Grid grid = new Grid(width,height);
        return grid;
    }
}
