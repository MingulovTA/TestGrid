using TestGrid.Popups;
using UnityEngine;

namespace TestGrid.Core
{
    public class ProjectContext : MonoBehaviour
    {
        private static ProjectContext _instance;
        
        public static ProjectContext I
        {
            get
            {
                if(_instance==null)
                {
                    var go = new GameObject("~" + nameof(ProjectContext));
                    _instance = go.AddComponent<ProjectContext>();
                    _instance.Init();
                }
                return _instance;
            }
        }

        private void Awake()
        {
            if(_instance!=null && _instance!=this)
            {
                Destroy(gameObject);
                return;
            }
            _instance = this;
            DontDestroyOnLoad(gameObject);
            Init();
        }



        [SerializeField] private PopupManager _popupManager;

        public PopupManager PopupManager => _popupManager;

        private void Init()
        {
            
        }
    }
}
