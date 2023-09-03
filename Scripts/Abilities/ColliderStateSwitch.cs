using UnityEngine;
using UnityEngine.Events;

public class ColliderStateSwitch : MonoBehaviour
{
    [SerializeField] private EdgeCollider2D[] _edgeColliders;

    [SerializeField] private UnityEvent _collidersDisabled;

    private void Start()
    {
        _edgeColliders = gameObject.GetComponentsInChildren<EdgeCollider2D>();
    }

    public void SetColliderState(bool state)
    {
        foreach(EdgeCollider2D collider in _edgeColliders)
        {
            collider.enabled = state;
        }

        _collidersDisabled?.Invoke();
    }
}
