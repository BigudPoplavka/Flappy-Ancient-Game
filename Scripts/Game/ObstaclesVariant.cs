using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Obstacle", menuName = "Obstacles variant", order = 16)]
public class ObstaclesVariant: ScriptableObject
{
    [SerializeField] private List<GameObject> _obstacles;

    public List<GameObject> Obstacles { get => _obstacles; }
}
