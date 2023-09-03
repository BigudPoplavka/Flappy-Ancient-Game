using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private GameObject _player;

    [SerializeField] private Player _playerComponent;

    [SerializeField] private Transform _playerSpawnPoint;

    [SerializeField] private GameScreen _gameScreen;
    [SerializeField] private PauseScreen _pauseScreen;
    [SerializeField] private GameOverScreen _endGameScreen;

    [SerializeField] private PlayerStatsPresenter _playerStatsPresenter;
    [SerializeField] private ObstacleSegmentGenerator _segmentGenerator;

    [SerializeField] private float _segmentsSpawnCooldown;

    [SerializeField] private bool _gameEnded;

    private void Start()
    {
        _playerComponent = _player.GetComponent<Player>();

        StartGame();
    }

    private void Update()
    {
        
    }

    private void SpawnPlayer()
    {
        gameObject.SetActive(true);
    }

    private IEnumerator SpawnSegments()
    {
        while (!_gameEnded)
        {
            _segmentGenerator.GenerateObstacleSegment();

            yield return new WaitForSeconds(_segmentsSpawnCooldown);
        }
    }

    public void StartGame()
    {
        _player.SetActive(true);
        _gameEnded = false;

        SpawnPlayer();
        StartCoroutine(SpawnSegments());
    }

    public void RestartGame()
    {
        _endGameScreen.Hide();
        _gameScreen.Show();
        _playerComponent.ResetSlots();

        StartGame();
    }

    public void EndGame()
    {
        //StopCoroutine(SpawnSegments());
        StopAllCoroutines();
        DestroyRemainsObstacles();

        _gameEnded = true;
        _gameScreen.Hide();
        _endGameScreen.Show();
    }

    private void DestroyRemainsObstacles()
    {
        var obstaclesRemains = FindObjectsOfType<ObstacleSegment>();
        
        foreach(ObstacleSegment obstacle in obstaclesRemains)
        {
            Destroy(obstacle.gameObject);
        }
    }

    public void PauseGame()
    {
        _gameScreen.Hide();
        _pauseScreen.Show();
    }

    public void ResumeGame()
    {
        _gameScreen.Show();
        _pauseScreen.Hide();
    }
}
