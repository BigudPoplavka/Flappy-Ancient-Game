using System.Collections.Generic;
using UnityEngine;

public class GameScreen : MonoBehaviour, IScreen
{
    [SerializeField] private List<GameObject> _uiElements;

    public void Hide()
    {
        _uiElements.ForEach(x => x.SetActive(false));
    }

    public void Show()
    {
        _uiElements.ForEach(x => x.SetActive(true));
    }
}
