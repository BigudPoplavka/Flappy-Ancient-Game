using System.Collections.Generic;
using UnityEngine;

public class ObstacleSegment : MonoBehaviour
{
    [SerializeField] private Transform _parent;

    [SerializeField] private List<GameObject> _spawnersObjects;

    [SerializeField] private float _movingSpeed;

    public void Setup()
    {
        foreach (GameObject spawner in _spawnersObjects)
        {
            spawner.GetComponent<ISpawner>().Spawn(_parent);         
        }
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.left * _movingSpeed * Time.fixedDeltaTime);
    }
}
