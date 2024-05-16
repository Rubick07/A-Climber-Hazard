using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManajer : MonoBehaviour
{
    public TMP_Text ScoreText, MiniGamestext;
    public float Score;
    public float MinigamesClear;
    public GameObject LoseMenu;
    public bool SpawnMinigames = false;

    int ScoreCount = 0;
    MoveByTouch move;
    MiniGamesSpawner gamesSpawner;
    private void Start()
    {
        Time.timeScale = 1f;
        move = FindAnyObjectByType<MoveByTouch>();
        gamesSpawner = FindAnyObjectByType<MiniGamesSpawner>();
    }
    void Update()
    {
  
        //Spawn Minigames button
        if(Mathf.Round(Score) % 10 == 0 && !SpawnMinigames && Mathf.Round(Score) != 0 && Score > ScoreCount)
        {
            ScoreCount = Mathf.RoundToInt(Score) + 5;
            SpawnMinigames = true;
            gamesSpawner.Spawn();
        }

        //Update Score
        Score += move.Arah * Time.deltaTime;
        MiniGamestext.text = MinigamesClear.ToString();
        ScoreText.text = Score.ToString("0");
    }
    
    public void LoseGame()
    {
        Time.timeScale = 0f;
        LoseMenu.SetActive(true);
    }


}
