using System;
using System.Collections;
using System.Collections.Generic;
using TestGrid.Core.Animations;
using UnityEngine;
using UnityEngine.UI;

namespace TestGrid.Grids.GridView
{
    public class GridView : MonoBehaviour
    {
        [SerializeField] private Text _textPrefab;
        [SerializeField] private GridLayoutGroup _gridLayoutGroup;
        [SerializeField] private RectTransform _rectTransform;
    
        private List<Text> _cells = new List<Text>();
        public void Show(Grid grid)
        {
            foreach (var cell in _cells)
                Destroy(cell.gameObject);
            _cells.Clear();


            var sizeDelta = _rectTransform.sizeDelta;
            _gridLayoutGroup.cellSize = new Vector2(
                sizeDelta.x / grid.Width,
                sizeDelta.y / grid.Height);
        
            for (int y = 0; y < grid.Height; y++)
            for (int x = 0; x < grid.Width; x++)
            {
                Text cell = Instantiate(_textPrefab, transform);
                cell.text = grid.GetChar(x, y).ToString();
                _cells.Add(cell);
            }
            _gridLayoutGroup.enabled = true;
        }

        public void ShowAnimation(GridAnimation gridAnimation, Action onComplete)
        {
            _gridLayoutGroup.enabled = false;
        
            List<Tween> targetPositions = new List<Tween>();

            int counter = 0;
            foreach (var node in gridAnimation.EndKeyFrame)
            {
                Vector2 newPosition = _cells[node].transform.position;
                float distance = Vector3.Distance(newPosition, _cells[counter].transform.position);
                Tween tween = new Tween(newPosition,distance/gridAnimation.AnimationTime);
                targetPositions.Add(tween);
                counter++;
            }

            StartCoroutine(AnimationYield(gridAnimation.AnimationTime,targetPositions,onComplete));
        }
    
    

        private float _animationTime;
        private IEnumerator AnimationYield(float time, List<Tween> tweens, Action onComplete)
        {
            yield return null;
            _animationTime = 0;
            while (_animationTime<time)
            {
                for (var i = 0; i < _cells.Count; i++)
                {
                    _cells[i].transform.position = Vector3.MoveTowards(_cells[i].transform.position,
                        tweens[i].TargetPosition, tweens[i].Speed*Time.deltaTime);
                }

                _animationTime += Time.deltaTime;
                yield return null;
            }
            onComplete?.Invoke();
        }
    }
}
