using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManajer : MonoBehaviour
{
    public TMP_Text ScoreText;
    public float Score;
    public GameObject LoseMenu;

    MoveByTouch move;

    private void Start()
    {
        Time.timeScale = 1f;
        move = FindAnyObjectByType<MoveByTouch>();
    }
    void Update()
    {
        //Debug.Log(move.Arah);
        Score += move.Arah * Time.deltaTime;
        ScoreText.text = Score.ToString("0");
    }
    
    public void LoseGame()
    {
        Time.timeScale = 0f;
        LoseMenu.SetActive(true);
    }
}
