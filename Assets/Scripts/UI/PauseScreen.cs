using UnityEngine;
class PauseScreen : MonoBehaviour, IScreen
{
    public void Hide()
    {
        gameObject.SetActive(false);

        Time.timeScale = 1;
    }

    public void Show()
    {
        gameObject.SetActive(true);

        Time.timeScale = 0;
    }
}
