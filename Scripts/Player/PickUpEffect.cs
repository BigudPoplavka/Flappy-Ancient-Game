using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpEffect : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;

    public void PlayAbilityPickUpEffect(Ability ability)
    {
        _particleSystem.textureSheetAnimation.SetSprite(0, ability.AbilityIcon);
        _particleSystem.Play();
    }
}
