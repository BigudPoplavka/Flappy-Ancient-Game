using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class AbilityVisualEffect : MonoBehaviour
{
    [SerializeField] private float _effectValue;
    [SerializeField] private float _defaultValue;
    [SerializeField] private float _speed;

    [SerializeField] private PostProcessVolume _volume;
    [SerializeField] private ChromaticAberration _chromaticAberration;

    private void Start()
    {
        _volume = GetComponent<PostProcessVolume>();
        _chromaticAberration = _volume.profile.GetSetting<ChromaticAberration>();
        _defaultValue = _chromaticAberration.intensity.value;

    }

    private void Update()
    {
        
    }

    public void ShowEffect()
    {
    }

   
}
