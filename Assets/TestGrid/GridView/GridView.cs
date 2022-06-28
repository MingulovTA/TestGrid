using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;

public class GridView : MonoBehaviour
{
    [SerializeField] private Text _textPrefab;
    [SerializeField] private GridLayoutGroup _gridLayoutGroup;
    [SerializeField] private RectTransform _rectTransform;
    
    private List<Text> _cells = new List<Text>();
    private Grid _grid;
    public void Show(Grid grid)
    {
        _grid = grid;
        foreach (var cell in _cells)
            Destroy(cell.gameObject);
        _cells.Clear();


        _gridLayoutGroup.cellSize = new Vector2(
            _rectTransform.sizeDelta.x / grid.Width,
            _rectTransform.sizeDelta.y / grid.Height);
        
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
        
        List<Vector3> targetPositions = new List<Vector3>();
        
        foreach (var node in gridAnimation.EndKeyFrame)
        {
            Vector2 newPosition = _cells[node].transform.position;
            targetPositions.Add(newPosition);
        }

        StartCoroutine(AnimationYield(gridAnimation,targetPositions,onComplete));
    }

    private float _animationTime;
    private IEnumerator AnimationYield(GridAnimation gridAnimation, List<Vector3> targetPositions, Action onComplete)
    {
        _animationTime = 0;
        while (_animationTime<gridAnimation.AnimationTime)
        {
            foreach (var cell in _cells)
            {
                cell.transform.position = Vector3.MoveTowards(cell.transform.position,
                    targetPositions[_cells.IndexOf(cell)], Time.deltaTime*1000);
            }

            _animationTime += Time.deltaTime;
            yield return null;
        }
        onComplete?.Invoke();
    }
}
