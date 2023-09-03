using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AbilitiesList: MonoBehaviour
{
    [SerializeField] private List<Slot> _abilitiesSlots;

    public bool IsAnySlotFree => _abilitiesSlots.Any(x => x.IsEmpty);

    public bool TryAddAbility(GameObject ability)
    {
        var abilityComponent = ability.GetComponent<Ability>();

        if(IsThisAbilityInSlot(abilityComponent))
        {
            _abilitiesSlots.Find(x => x.CurrAbilityName == abilityComponent.Name)
                .IncreaseCount();

            return true;
        }
        else if(IsAnySlotFree)
        {
            _abilitiesSlots.Find(x => x.IsEmpty).SetAbilityToSlot(ability);

            return true;
        }

        return false;
    }

    private bool IsThisAbilityInSlot(Ability ability)
    {
        return _abilitiesSlots.Any(x => x.CurrAbilityName == ability.Name);
    }

    public void ResetAllSlots()
    {
        foreach (Slot slot in _abilitiesSlots)
        {
            slot.ResetSlot();
        }
    }
}
 