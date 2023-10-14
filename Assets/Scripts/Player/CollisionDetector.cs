using UnityEngine;
using UnityEngine.Events;

public class CollisionDetector : MonoBehaviour
{
    [SerializeField] private UnityEvent _collideObstacle;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent<ObstacleSegment>(out ObstacleSegment obstacle))
        {
            _collideObstacle?.Invoke();
        }
    }
}
