using UnityEngine;
using UnityEngine.Events;

namespace clicker
{
    public class ScreenClicker : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private float _maxDistance = 10f;
        [SerializeField] private UnityEvent _onClickSuccess;
        public GameObject _tent;

        private RaycastHit[] _hits;

        protected void Awake()
        {
            _hits = new RaycastHit[1];
            
        }

        //Tent annimation that occurs every click
        private void TentAnimation(){
            _tent = GameObject.Find("tent");
            Animator animator = _tent.GetComponent<Animator>();
                if(animator != null){
                    animator.SetTrigger("clicked");
                }
        }

        protected void Update()
        {

            if (!Input.GetMouseButtonDown(0))
            {
                return;
            }
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            int hitsAmount = Physics.RaycastNonAlloc(ray, _hits, _maxDistance, _layerMask.value);
            if (hitsAmount > 0)
            {
                TentAnimation();
                _onClickSuccess?.Invoke();
            }
        }
    }
}
