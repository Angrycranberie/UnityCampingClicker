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
        [SerializeField] private UnityEvent _goByouKeika; //subtil Jojo reference

        private float _time = 0.0f;
        private float _go = 5.0f;
        private RaycastHit[] _hits;

        protected void Awake()
        {
            _hits = new RaycastHit[1];
        }

        protected void Update()
        {
            //InvokeRepeating("_goByoukeika", 5.0f, 5.0f);
           /* _time = Time.deltaTime;
            if (_time >= _go) { _goByouKeika?.Invoke(); }*/

            if (!Input.GetMouseButtonDown(0))
            {
                return;
            }
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            int hitsAmount = Physics.RaycastNonAlloc(ray, _hits, _maxDistance, _layerMask.value);
            if (hitsAmount > 0)
            {
                _onClickSuccess?.Invoke();
            }
        }
    }
}
