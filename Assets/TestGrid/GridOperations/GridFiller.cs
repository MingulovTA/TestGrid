using UnityEngine;
using Grid = TestGrid.Grids.Grid;

namespace TestGrid.GridOperations
{
    public static class GridFiller
    {
        private const int CHAR_A_CODE = 65;
        private const int CHAR_Z_CODE = 90;
        public static void RandomFill(Grid grid)
        {
            for (int y = 0; y < grid.Height; y++)
            for (int x = 0; x < grid.Width; x++)
            {
                grid.SetChar(x,y,(char)Random.Range(CHAR_A_CODE,CHAR_Z_CODE));
            }
        }
    }
}
