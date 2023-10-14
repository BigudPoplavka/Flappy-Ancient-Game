using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class PassableThroughWall : MonoBehaviour, ISelfActingEffect, IAbility
{
    [SerializeField] private float _effectEnfluenceTime;

    [SerializeField] private UnityEvent _abilityUsed;

    public void AplyEffect()
    {
        Debug.Log("USE PassableThroughWall");

        SetColliderState(true);
        StartCoroutine(WaitAbilityActingTime());
        RemoveEffect();
    }

    public void RemoveEffect()
    {
        SetColliderState(false);
    }

    public void SetColliderState(bool state)
    {
        var colliderSwitches = FindObjectsOfType<ColliderStateSwitch>();

        foreach (ColliderStateSwitch colliderSwitch in colliderSwitches)
        {
            colliderSwitch.SetColliderState(state);
        }
    }

    public void Use()
    {
        _abilityUsed?.Invoke();

        AplyEffect();
    }

    private IEnumerator WaitAbilityActingTime()
    {
        yield return new WaitForSeconds(_effectEnfluenceTime);
    }
}
