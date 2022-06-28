using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridAnimation
{
    private List<int> _endKeyFrame;
    private float _animationTime;

    public float AnimationTime => _animationTime;
    public List<int> EndKeyFrame => _endKeyFrame;

    public GridAnimation(List<int> endKeyFrame, float animationTime)
    {
        _endKeyFrame = endKeyFrame;
        _animationTime = animationTime;
    }
}
