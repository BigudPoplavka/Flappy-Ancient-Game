using System.Collections.Generic;
using UnityEngine;

public interface ISpawner
{
    public List<Transform> SpawnPoints { get; }
    public void Spawn(Transform parent);
}
