using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour, ISpawner
{
    [SerializeField] private List<Transform> _spawnPoints;

    [SerializeField] private List<ObstaclesVariant> _templates;

    public List<Transform> SpawnPoints { get => _spawnPoints; }

    public void Spawn(Transform parent)
    {
        var obstacleVariant = _templates[Random.Range(0, _templates.Count)].Obstacles;

        Instantiate(obstacleVariant[Random.Range(0, obstacleVariant.Count - 1)],
            _spawnPoints[Random.Range(0, _spawnPoints.Count - 1)].position,
             Quaternion.identity).transform.SetParent(Instantiate(parent));
    }
}
