using System.Collections.Generic;
using UnityEngine;

public class Sacrifice : MonoBehaviour, IAbility, ISpawner
{
    [SerializeField] private GameObject _template;

    [SerializeField] private List<Transform> _spawnPoints;

    public List<Transform> SpawnPoints => _spawnPoints;

    public void Spawn(Transform parent)
    {
        Instantiate(_template, _spawnPoints[0].position, Quaternion.identity);
    }

    public void Use()
    {
        Debug.Log("USE Sacrifice");

        //Spawn(_spawnPoints[0]);
    }
}
