using System;
using UnityEngine;

public class PlayerStatsPresenter : MonoBehaviour, IPresenter
{
    [SerializeField] private Player _player;

    [SerializeField] private PlayerStatsRenderer _playerStatsRenderer;

    [SerializeField] private string _noFreeSlotsMsg;

    private void Start()
    {
        if (_player != null && _playerStatsRenderer != null)
        {
            Subscribe();
        }
    }

    private void OnDestroy()
    {
        if (_player != null && _playerStatsRenderer != null)
        {
            Unsubscribe();
        }
    }

    public void Subscribe()
    {
        _player.Stats.CollectedStarsCountChanged.AddListener(CollectedStarsCountChanged);
        _player.Stats.PassedObstaclesCountChanged.AddListener(OnPassedObstaclesCountChanged);
        _player.AbilityCollected.AddListener(OnAbilityCollected);
        _player.AbilityNotCollected.AddListener(OnAbilityNotCollected);
        _player.Stats.PassedObstaclesCounted.AddListener(OnPassedObstaclesCounted);
    }

    public void Unsubscribe()
    {
        _player.Stats.CollectedStarsCountChanged.RemoveListener(CollectedStarsCountChanged);
        _player.Stats.PassedObstaclesCountChanged.RemoveListener(OnPassedObstaclesCountChanged);
        _player.AbilityCollected.RemoveListener(OnAbilityCollected);
        _player.AbilityNotCollected.RemoveListener(OnAbilityNotCollected);
        _player.Stats.PassedObstaclesCounted.RemoveListener(OnPassedObstaclesCounted);
    }

    private void CollectedStarsCountChanged(int count)
    {
        _playerStatsRenderer.UpdateCollectedStarsCount(count);
    }

    private void OnPassedObstaclesCountChanged(int count)
    {
        _playerStatsRenderer.UpdatePassedObstaclesCount(count);
    }

    private void OnPassedObstaclesCounted(int count)
    {
        _playerStatsRenderer.SetFinalScoreCount(count);
    }

    private void OnAbilityCollected(GameObject ability)
    {
        string abilityName = ability.GetComponent<Ability>().Name;
        _playerStatsRenderer.ShowPickedAbilityName(abilityName);
    }

    private void OnAbilityNotCollected()
    {
        _playerStatsRenderer.ShowPickedAbilityName(_noFreeSlotsMsg);
    }
}
