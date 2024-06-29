using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGames : MonoBehaviour
{
    public GameObject MiniGamesPanel;
    private Player player;

    private void Start()
    {
        player = FindAnyObjectByType<Player>().GetComponent<Player>();
    }
    public void SpawnMinigamesPanel()
    {
        Button button = GetComponentInChildren<Button>();
        button.interactable = false;
        GameObject minigames =  Instantiate(MiniGamesPanel, player.transform);
        minigames.transform.parent = null;
        Destroy(gameObject);
        Time.timeScale = 0f;
    }


    public void MinigamesTali()
    {
        GameManajer gameManajer = FindAnyObjectByType<GameManajer>();
        gameManajer.MinigamesClear++;
        gameManajer.MiniGamesCleartext.text= gameManajer.MinigamesClear.ToString();
        gameManajer.SpawnMinigames = false;
        Destroy(gameObject);
        Time.timeScale = 1f;
    }

    public void WinGames()
    {
        GameManajer gameManajer = FindAnyObjectByType<GameManajer>();
        gameManajer.MinigamesClear++;
        gameManajer.MiniGamesCleartext.text = gameManajer.MinigamesClear.ToString();
        gameManajer.SpawnMinigames = false;
        Destroy(gameObject);
        Time.timeScale = 1f;

    }

    public void LoseGames()
    {

    }

}
