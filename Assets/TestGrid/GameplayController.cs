using System;
using TestGrid.GridOperations;
using UnityEngine;
using UnityEngine.UI;

public class GameplayController : MonoBehaviour
{
    [SerializeField] private InputField _ifWidth;
    [SerializeField] private InputField _ifHeight;
    [SerializeField] private GridView _gridView;
    private Grid _grid;

    public void GenerateNewGrid() //Reflection invokation
    {
        int width = Convert.ToInt32(_ifWidth.text);
        int height = Convert.ToInt32(_ifHeight.text);
        
        _grid = GridFactory.GenerateRandomGrid(width, height);
        GridFiller.RandomFill(_grid);
        _gridView.Show(_grid);
    }
    
    public void ShuffleGrid() //Reflection invokation
    {
        
        GridAnimation gridShuffleAnimation = GridShuffler.ShuffleWithAnimation(_grid);
        _gridView.ShowAnimation(gridShuffleAnimation,CompleteAnimaiton);
        
    }

    private void CompleteAnimaiton()
    {
        Debug.Log("CompleteAnimaiton");
        _gridView.Show(_grid);
    }
}
