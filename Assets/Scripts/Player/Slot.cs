using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Slot: MonoBehaviour
{
    [SerializeField] private int _count;

    [SerializeField] private string _currAbilityName;

    [SerializeField] private GameObject _abilityTemplate;

    [SerializeField] private Ability _abilityComponent;

    [SerializeField] private Button _button;

    private IAbility _abilityEffect;

    [SerializeField] private UnityEvent<int> _countChanged;
    [SerializeField] private UnityEvent _abilityCountIsZero;
    [SerializeField] private UnityEvent _slotReseted;
    [SerializeField] private UnityEvent<Ability> _abilityAdded;
    [SerializeField] private UnityEvent<Sprite> _abilityUsed;

    public bool IsEmpty => _abilityTemplate == null;

    public string CurrAbilityName => _currAbilityName;

    private void Start()
    {
        _count = 0;
    }

    public void SetAbilityToSlot(GameObject template)
    {
        _abilityComponent = template.GetComponent<Ability>();
        _abilityEffect = template.GetComponent<IAbility>();

        _currAbilityName = _abilityComponent.Name;
        _abilityTemplate = template;

        _button.onClick.AddListener(_abilityEffect.Use);
        _abilityAdded?.Invoke(_abilityComponent);

        IncreaseCount();
    }

    public void UseSlot()
    {
        Debug.Log("UseSlot");
        if (!IsEmpty)
        {
            _abilityUsed?.Invoke(_abilityComponent.AbilityIcon);
            _abilityComponent.Effect.Use();

            DecreaseCount();
        }
    }

    public void ResetSlot()
    {
        if (!IsEmpty)
        {
            _button.onClick.RemoveListener(_abilityEffect.Use);
        }

        _abilityComponent = null;
        _abilityEffect = null;
        _abilityTemplate = null;
        _currAbilityName = string.Empty;
        _count = 0;
        
        _slotReseted?.Invoke();
    }

    public void IncreaseCount()
    {
        _count++;
        _countChanged?.Invoke(_count);
    }

    public void DecreaseCount()
    {
        if(_count != 0)
        {
            _count--;
            _countChanged?.Invoke(_count);

            if(_count == 0)
            {
                ResetSlot();
                _abilityCountIsZero?.Invoke();
            }
        }
    }
}
