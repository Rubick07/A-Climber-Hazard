using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManajer : MonoBehaviour
{
    public TMP_Text ScoreText, MiniGamesCleartext, MiniGamesTargetText;
    public float Score;
    public float TargetScore;
    public float MinigamesClear;
    public GameObject LoseMenu;
    public GameObject WinMenu;
    public GameObject BelomSelesaiText;
    public bool SpawnMinigames = false;
    [SerializeField] private Animator animator;
    int ScoreCount = 0;
    MoveByTouch move;
    MiniGamesSpawner gamesSpawner;
    bool Lose = false;
    private void Start()
    {
        Time.timeScale = 1f;
        move = FindAnyObjectByType<MoveByTouch>();
        gamesSpawner = FindAnyObjectByType<MiniGamesSpawner>();
        MiniGamesCleartext.text = MinigamesClear.ToString();
        MiniGamesTargetText.text = TargetScore.ToString();
    }
    void Update()
    {
        if(Lose)
        {
            return;
        }


        /*
        //Spawn Minigames button
        if(Mathf.Round(Score) % 10 == 0 && !SpawnMinigames && Mathf.Round(Score) != 0 && Score > ScoreCount)
        {
            ScoreCount = Mathf.RoundToInt(Score) + 5;
            SpawnMinigames = true;
            gamesSpawner.Spawn();
        }
        */

        //Update Score
        Score += move.Arah * Time.deltaTime;
        animator.speed = Mathf.Abs(move.Arah);
        //MiniGamestext.text = MinigamesClear.ToString();
        ScoreText.text = Score.ToString("0");
    }
    

    public void WinGame()
    {
        Time.timeScale = 0f;
        WinMenu.SetActive(true);
    }
    public void LoseGame()
    {
        Lose = true;
        Time.timeScale = 0f;
        LoseMenu.SetActive(true);
    }

    public void BelomSelesai()
    {
        GameObject BelomselesaiObject = Instantiate(BelomSelesaiText, transform);
        MoveByTouch moveByTouch = GetComponent<MoveByTouch>();
        moveByTouch.diam();
        Destroy(BelomselesaiObject, 1f);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("finish"))
        {
            if (TargetScore == MinigamesClear)
            {
                WinGame();
                return;
            }
            else
            {
                BelomSelesai();
                return;
            }

        }

        
    }
}
