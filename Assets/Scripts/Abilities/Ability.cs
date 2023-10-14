using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class Ability : MonoBehaviour
{
    [SerializeField] private string _name;

    [SerializeField] private float _cooldown;

    [SerializeField] private ParticleSystem _particleSystem;

    [SerializeField] private Sprite _icon;

    [SerializeField] private EdgeCollider2D _edgeCollider;

    [SerializeField] private IAbility _ability;

    public string Name => _name;
    public float Cooldown => _cooldown;
    public Sprite AbilityIcon => _icon;
    public IAbility Effect => _ability;

    private void Start()
    {
        _ability = GetComponent<IAbility>();
        _edgeCollider = gameObject.GetComponent<EdgeCollider2D>();
    }

    private void OnBecameInvisible()
    {
        _edgeCollider.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.transform.TryGetComponent<Player>(out Player player))
        {
            PlayEffect();
        }
    }

    private void PlayEffect()
    {
        _edgeCollider.enabled = false;

        _particleSystem.textureSheetAnimation.SetSprite(0, _icon);
        _particleSystem.Play();
    }
}
