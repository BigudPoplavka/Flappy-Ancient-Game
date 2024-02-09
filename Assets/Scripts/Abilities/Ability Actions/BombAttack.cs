using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
using System.Linq;

public class BombAttack : MonoBehaviour, IAbility
{
    [SerializeField] private ObstacleSegment[] _frontObstacles;

    [SerializeField] private Vector3 _minDistancePointPosition;

    [SerializeField] private float _offset;

    public void Use()
    {
        Debug.Log("USE BombAttack");

        _minDistancePointPosition = GameObject.FindObjectOfType<Player>().transform.position;

        Destroy(FindNearestObstacle());
    }

    private GameObject FindNearestObstacle()
    {
        _frontObstacles = GameObject.FindObjectsOfType<ObstacleSegment>();
        return _frontObstacles.Where(x => x.gameObject.transform.position.x > _minDistancePointPosition.x + _offset)
                                          .ToArray()[0].gameObject;
    }
}
