using System.Collections.Generic;
using UnityEngine;

public class ObstacleSegmentGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _segmentTemplate;

    [SerializeField] private ObstacleSegment _obstacleSegment;

    [SerializeField] private Transform _segmentSpawnPoint;

    private void Start()
    {
        if(_segmentTemplate != null)
        {
            _obstacleSegment = _segmentTemplate.GetComponent<ObstacleSegment>();
        }
    }

    public void GenerateObstacleSegment()
    {
        _obstacleSegment.Setup();
    }
}
