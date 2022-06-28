using System.Collections.Generic;
using TestGrid.Grids;

namespace TestGrid.GridOperations
{
    public static class GridShuffler
    {
        private static readonly System.Random Random = new System.Random();
        
        public static GridAnimation ShuffleWithAnimation(Grid grid)
        {
            List<int> endKeyFrame = new List<int>();
            List<char> tempCharsList = new List<char>();

            int counter = 0;
            for (int y = 0; y < grid.Height; y++)
            for (int x = 0; x < grid.Width; x++)
            {
                tempCharsList.Add(grid.GetChar(x,y));
                endKeyFrame.Add(counter);
                counter++;
            }
            
            var n = endKeyFrame.Count;  
            while (n > 1) {  
                n--;  
                var k = Random.Next(n + 1);  
                var value = endKeyFrame[k];  
                endKeyFrame[k] = endKeyFrame[n];  
                endKeyFrame[n] = value;  
            }
            //Todo Move right one step if 3 items left
            
            counter = 0;
            foreach (int posIndex in endKeyFrame)
            {
                int y = posIndex / grid.Width;
                int x = posIndex - y*grid.Width;
                grid.SetChar(x, y,tempCharsList[counter]);
                counter++;
            }

            return new GridAnimation(endKeyFrame,2);
        }
    }
}
