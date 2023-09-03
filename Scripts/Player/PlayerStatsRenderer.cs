using System.Collections;
using UnityEngine;

public class PlayerStatsRenderer: MonoBehaviour  
{
    [SerializeField] private TMPro.TMP_Text _collectedStarsCountText;
    [SerializeField] private TMPro.TMP_Text _passedObstaclesCountText;
    [SerializeField] private TMPro.TMP_Text _pickedAbilityName;
    [SerializeField] private TMPro.TMP_Text _scoreText;

    [SerializeField] private float _appearedObjectsShowTime;

    [SerializeField] private Animator _scoreChangingAnimator;


    public void UpdateCollectedStarsCount(int count)
    {
        //_collectedStarsCountText.text = count.ToString();
    }

    public void UpdatePassedObstaclesCount(int count)
    {
        _passedObstaclesCountText.text = count.ToString();
        _scoreChangingAnimator.SetTrigger("Score Changed");
    }

    public void ShowPickedAbilityName(string name)
    {
        StartCoroutine(WaitBeforeDisableText(name));
    }

    public void SetFinalScoreCount(int count)
    {
        _scoreText.text = count.ToString();
    }

    private IEnumerator WaitBeforeDisableText(string name)
    {
        _pickedAbilityName.text = name;
        _pickedAbilityName.gameObject.SetActive(true);

        yield return new WaitForSeconds(_appearedObjectsShowTime);

        _pickedAbilityName.gameObject.SetActive(false);
    }
}
