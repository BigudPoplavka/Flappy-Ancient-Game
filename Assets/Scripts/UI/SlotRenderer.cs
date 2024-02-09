using UnityEngine;
using UnityEngine.Events;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class SlotRenderer : MonoBehaviour
{
    [SerializeField] private Sprite _defaultSprite;
    [SerializeField] private SpriteRenderer _usageEffectHolder;

    [SerializeField] private Image _buttonImage;

    [SerializeField] private TextMeshProUGUI _abilityUsesCount;

    [SerializeField] private Button _button;

    private float _cooldown;

    void Start()
    {
        RenderEmptySlot();
    }

    public void RenderEmptySlot()
    {
        Debug.Log("RenderEmptySlot");
        _buttonImage.sprite = _defaultSprite;
        _cooldown = 0;

        RenderAbilityCount(0);
    }

    public void RenderSlotOnAbilityGetting(Ability ability)
    {
        _buttonImage.sprite = ability.AbilityIcon;
        _cooldown = ability.Cooldown;
    }

    public void RenderAbilityCount(int count)
    {
        _abilityUsesCount.text = count.ToString();
    }

    public void SetSlotUninteractable()
    {
        StartCoroutine(WaitAbilityCooldown());
    }

    public void SetAbilityIconToEffect(Sprite sprite)
    {
        Debug.Log("SetAbilityIconToEffect");
        _usageEffectHolder.sprite = sprite;

        StartCoroutine(WaitUsageEffect());
    }

    public IEnumerator WaitAbilityCooldown()
    {
        if(_cooldown > 0)
        {
            _button.interactable = false;

            yield return new WaitForSeconds(_cooldown);

            _button.interactable = true;
        }
    }

    public IEnumerator WaitUsageEffect()
    {
        if (_cooldown > 0)
        {
            _usageEffectHolder.gameObject.SetActive(true);

            yield return new WaitForSeconds(2f);

            _usageEffectHolder.gameObject.SetActive(false);
        }
    }

    public void ResetSlotRenderer()
    {
        _cooldown = 0;
        _usageEffectHolder.sprite = null;
    }
}
