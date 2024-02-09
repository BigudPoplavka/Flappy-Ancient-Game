using UnityEngine;
using UnityEngine.Events;

public class PlayerStats: MonoBehaviour
{
    [SerializeField] private int _collectedStarsCount;
    [SerializeField] private int _passedObstaclesCount;

    [SerializeField] private UnityEvent<int> _collectedStarsCountChanged;
    [SerializeField] private UnityEvent<int> _passedObstaclesCountChanged;
    [SerializeField] private UnityEvent<int> _passedObstaclesCounted;

    public UnityEvent<int> CollectedStarsCountChanged { get => _collectedStarsCountChanged; }
    public UnityEvent<int> PassedObstaclesCountChanged { get => _passedObstaclesCountChanged; }
    public UnityEvent<int> PassedObstaclesCounted { get => _passedObstaclesCounted; }

    public int CollectedStars { get => _collectedStarsCount; }

    public void IncreaseStarsCount()
    {
        _collectedStarsCount++;

        _collectedStarsCountChanged?.Invoke(_collectedStarsCount);
    }

    public void IncreasePassedObstaclesCount()
    {
        _passedObstaclesCount++;

        _passedObstaclesCountChanged?.Invoke(_passedObstaclesCount);
    }

    public void ShareFinalResultsOnWin()
    {

    }

    public void ShareFinalResultsOnDefeat()
    {
        _passedObstaclesCounted?.Invoke(_passedObstaclesCount);
    }

    public void ResetStats()
    {
        _passedObstaclesCount = 0;

        //_collectedStarsCountChanged?.Invoke(_collectedStarsCount);
        _passedObstaclesCountChanged?.Invoke(_passedObstaclesCount);
    }
}
