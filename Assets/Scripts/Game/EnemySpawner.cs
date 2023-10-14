using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour, ISpawner
{
    private const int MIN_PROBALITY = 1;

    [SerializeField] private List<Transform> _spawnPoints;

    [SerializeField] private List<GameObject> _templates;

    [SerializeField] private int _spawnProbalityToOne;

    public List<Transform> SpawnPoints { get => _spawnPoints; }

    public void Spawn(Transform parent)
    {
        if (Random.Range(MIN_PROBALITY, _spawnProbalityToOne) == 1)
        {
            Instantiate(_templates[Random.Range(0, _templates.Count)],
                _spawnPoints[0].position,
                 Quaternion.identity).transform.SetParent(Instantiate(parent));
        }
    }
}
