using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour, IScreen
{
    [SerializeField] private RawImage _background;

    [SerializeField] private Texture2D _gameOverBackground;
    [SerializeField] private Texture2D _gameBackground;

    [SerializeField] private List<Animator> _animators;

    [SerializeField] private GameObject _stats;
    [SerializeField] private GameObject _topImage;
    [SerializeField] private GameObject _bottomImage;

    private Dictionary<GameObject, Vector3> _UIPartsAndAppearingPositions;

    private void Start()
    {
        _UIPartsAndAppearingPositions = new Dictionary<GameObject, Vector3>();

        _UIPartsAndAppearingPositions.Add(_stats, _stats.transform.position);
        _UIPartsAndAppearingPositions.Add(_topImage, _topImage.transform.position);
        _UIPartsAndAppearingPositions.Add(_bottomImage, _bottomImage.transform.position);
    }

    public void Show()
    {
        gameObject.SetActive(true);

        _stats.SetActive(true);
        _background.texture = _gameOverBackground;

        HideRemainsObjects();
        ShowAnimation();
    }

    public void Hide()
    {
        ResetUIPartsPositions();

        gameObject.SetActive(false);
        _stats.SetActive(false);

        _background.texture = _gameBackground;
    }

    private void ShowAnimation()
    {
        _animators.ForEach(x => x.SetTrigger("GameOver"));
    }

    private void ResetUIPartsPositions()
    {
        foreach(KeyValuePair<GameObject, Vector3> pair in _UIPartsAndAppearingPositions)
        {
            pair.Key.gameObject.transform.position = pair.Value;
        }
    }

    private void HideRemainsObjects()
    {
        var list = FindObjectsOfType<ObstacleSegment>();

        foreach(ObstacleSegment segment in list)
        {
            segment.gameObject.SetActive(false);
        }
    }
}
