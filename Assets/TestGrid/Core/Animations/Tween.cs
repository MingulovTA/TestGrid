using UnityEngine;

namespace TestGrid.Core.Animations
{
    public struct Tween
    {
        private Vector3 _targetPosition;
        private float _speed;
        
        public float Speed => _speed;
        public Vector3 TargetPosition => _targetPosition;
        public Tween(Vector3 targetPosition, float speed)
        {
            _targetPosition = targetPosition;
            _speed = speed;
        }
    }
}