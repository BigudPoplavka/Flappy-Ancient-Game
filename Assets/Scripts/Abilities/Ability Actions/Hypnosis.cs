using UnityEngine;
using UnityEngine.Events;

public class Hypnosis : MonoBehaviour, IAbility
{
    [SerializeField] private UnityEvent _abilityUsed;

    public void Use()
    {
        _abilityUsed?.Invoke();

        Debug.Log("USE Hypnosis");
    }
}
