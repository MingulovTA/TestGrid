using System;
using TestGrid.GridOperations;
using TestGrid.Grids;
using TestGrid.Grids.GridView;
using TestGrid.Popups;
using UnityEngine;
using UnityEngine.UI;
using Grid = TestGrid.Grids.Grid;

namespace TestGrid.Core
{
    public class GameplayController : MonoBehaviour
    {
        [SerializeField] private InputField _ifWidth;
        [SerializeField] private InputField _ifHeight;
        [SerializeField] private GridView _gridView;
        
        private Grid _grid;
        private bool _animationIsPlaying;

        private PopupManager _popupManager;
        private void Start()
        {
            _popupManager = ProjectContext.I.PopupManager;
        }
        
        public void GenerateNewGrid() //Reflection invokation
        {
            if (_animationIsPlaying)
            {
                _popupManager.ShowMessagePopup("Невозможно сгенерировать новую сетку. \nВыполняется анимация");
                return;
            }
            int width = Convert.ToInt32(_ifWidth.text);
            int height = Convert.ToInt32(_ifHeight.text);
        
            _grid = GridFactory.GenerateRandomGrid(width, height);
            GridFiller.RandomFill(_grid);
            _gridView.Show(_grid);
        }
    
        public void ShuffleGrid() //Reflection invokation
        {
            if (_animationIsPlaying)
            {
                _popupManager.ShowMessagePopup("Невозможно проиграть следующую анимацию, пока проигрывается предыдущая.");
                return;
            }
            _animationIsPlaying = true;
            GridAnimation gridShuffleAnimation = GridShuffler.ShuffleWithAnimation(_grid);
            _gridView.ShowAnimation(gridShuffleAnimation,CompleteAnimaitonHandler);
        }

        private void CompleteAnimaitonHandler()
        {
            _gridView.Show(_grid);
            _animationIsPlaying = false;
        }
    }
}
