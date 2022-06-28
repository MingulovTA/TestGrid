using UnityEngine;

namespace TestGrid.GridOperations
{
    public class GridFiller
    {
        public static void RandomFill(Grid grid)
        {
            for (int y = 0; y < grid.Height; y++)
            for (int x = 0; x < grid.Width; x++)
            {
                grid.SetChar(x,y,(char)Random.Range(65,90));
            }
        }
    }
}
