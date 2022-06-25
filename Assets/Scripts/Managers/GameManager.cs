using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public enum GameState { Started, Paused, GameOver }
    public GameState gameState;

    public int currentLevel = 1;

    [SerializeField] TouchControls touchControls;
    [SerializeField] PlayerManager playerManager;
    [SerializeField] NPCPool npcPool;
    [SerializeField] GameObject startScreen;
    [SerializeField] GameObject gameOverScreen;
    GameObject currentEnemy;
    [SerializeField] TMP_Text levelNoText;
    [Header("Level Colors")]
    [SerializeField] Color level1Color;
    [SerializeField] Color level10Color;
    [SerializeField] Color level20Color;

    private void Start()
    {
        Time.timeScale = 0;
        startScreen.SetActive(true);
        gameOverScreen.SetActive(false);
        gameState = GameState.Paused;

        playerManager.playerMaterial.color = level1Color;

        currentEnemy = npcPool.GetNextCar();
        StartCoroutine(PoolAccess());
    }

    private void Update()
    {
        CheckPrimaryTouch();

    }

    private IEnumerator PoolAccess()
    {
        while (true)
        {
            yield return new WaitForSeconds(20);
            currentEnemy.SetActive(false);
            currentEnemy = npcPool.GetNextCar();
            Debug.Log(currentEnemy.name);
        }
    }

    private void CheckPrimaryTouch()
    {
        if (gameState == GameState.Paused && touchControls.Touched)
        {
            Play();
        }
    }

    private void Play()
    {
        Time.timeScale = 1;
        startScreen.SetActive(false);
        gameState = GameState.Started;
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        gameOverScreen.SetActive(true);
        gameState = GameState.GameOver;
    }

    public void ChangeLevel(int levelAmount)
    {
        currentLevel += levelAmount;
        if (currentLevel > 0)
        {
            if (currentLevel / 10 == 1)
            {
                playerManager.playerMaterial.color = level10Color;
            }
            else if (currentLevel / 10 == 2)
            {
                playerManager.playerMaterial.color = level20Color;
            }

            levelNoText.text = currentLevel.ToString();
        }

        else
        {
            GameOver();
        }
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}