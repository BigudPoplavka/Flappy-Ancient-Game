using UnityEngine;

public class SelfResizing : MonoBehaviour, ISelfActingEffect, IAbility
{
    [SerializeField] private Transform _target;

    [SerializeField] private Vector3 _reducedSize;
    [SerializeField] private Vector3 _defaultSize;

    [SerializeField] private float _effectDuration;
    [SerializeField] private float _duration;
    [SerializeField] private float _elapsedTime;
    [SerializeField] private float _transformedStateTime;

    private void Start()
    {
        _target = FindObjectOfType<Player>().transform;
        _defaultSize = _target.localScale;
    }

    private void Update()
    {
        Use();

        if(IsEffectTimeIsOver())
        {
            RemoveEffect();
        }
    }

    public void AplyEffect()
    {
        _elapsedTime += Time.deltaTime;

        float currentPercentage = _elapsedTime / _duration;

        transform.localScale = Vector3.Lerp(_target.localScale, _reducedSize, currentPercentage);
    }


    public void RemoveEffect()
    {
        _elapsedTime += Time.deltaTime;

        float currentPercentage = _elapsedTime / _duration;

        transform.localScale = Vector3.Lerp(_target.localScale, _defaultSize, currentPercentage);
    }

    private bool IsEffectTimeIsOver()
    {
        _effectDuration += Time.deltaTime;

        if (_effectDuration >= _transformedStateTime)
        {
            _elapsedTime = 0;

            return true;
        }

        return false;
    }

    public void Use()
    {
        AplyEffect();
    }
}
