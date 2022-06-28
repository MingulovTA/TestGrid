using System.Collections.Generic;

namespace TestGrid.Grids
{
    public class GridAnimation
    {
        public float AnimationTime { get; }
        public List<int> EndKeyFrame { get; }

        public GridAnimation(List<int> endKeyFrame, float animationTime)
        {
            EndKeyFrame = endKeyFrame;
            AnimationTime = animationTime;
        }
    }
}
