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

            if (!IsInteger(_ifWidth.text))
            {
                _popupManager.ShowMessagePopup("Ширина должна быть целым положительным числом");
                return;
            }
            
            int width = Convert.ToInt32(_ifWidth.text);

            if (width < 2 || width > 50)
            {
                _popupManager.ShowMessagePopup("Ширина должна быть в диапазоне 2-50");
                return;
            }
            
            if (!IsInteger(_ifHeight.text))
            {
                _popupManager.ShowMessagePopup("Высота должна быть целым положительным числом");
                return;
            }

            int height = Convert.ToInt32(_ifHeight.text);
            
            if (height < 2 || height > 50)
            {
                _popupManager.ShowMessagePopup("Высота должна быть в диапазоне 2-50");
                return;
            }
        
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
            
            if (_grid==null)
            {
                _popupManager.ShowMessagePopup("Сетка не создана.");
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

        private bool IsInteger(string str)
        {
            foreach (var c in str)
            {
                if (!Char.IsDigit(c))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
