using UnityEngine;

public class ObstaclesRenderer : MonoBehaviour
{
    [SerializeField] private SpriteRenderer[] _spriteRenderers;

    [SerializeField] private Color _baseColor;
    [SerializeField] private Color _changedColor;

    private void Start()
    {
        _spriteRenderers = gameObject.GetComponentsInChildren<SpriteRenderer>();
    }

    public void RenderPassableThroughState()
    {
        foreach (SpriteRenderer renderer in _spriteRenderers)
        {
            renderer.color = _changedColor;
        }
    }

    public void RenderDefaultState()
    {
        foreach (SpriteRenderer renderer in _spriteRenderers)
        {
            renderer.color = _baseColor;
        }
    }
}
