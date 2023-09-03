using UnityEngine;
using UnityEngine.Events;

public class BombAttack : MonoBehaviour, IAbility
{
    [SerializeField] private GameObject _bombTemplate;

    public void Use()
    {
        Debug.Log("USE BombAttack");
    }
}
