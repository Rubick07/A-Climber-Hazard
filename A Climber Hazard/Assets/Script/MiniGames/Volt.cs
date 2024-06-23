using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Volt : MonoBehaviour
{
    [SerializeField] private TMP_Text Currtxt, Targettxt, Tandatxt;
    private int target, curr;
    private int Chance;
    MiniGames miniGames;
    private void Start()
    {
        target = Random.Range(20, 40);
        target *= 10;
        curr = Random.Range(20, 40);
        curr *= 10;
        Targettxt.text = target.ToString();
        Currtxt.text = curr.ToString();
        miniGames = GetComponent<MiniGames>();
    }

    public void SetVolt()
    {
        if(target == curr)
        {
            Tandatxt.text = "Benar";
            miniGames.WinGames();
        }
        else
        {
            Chance++;
            if (Chance == 3)
            {
                Destroy(gameObject);
                GameManajer gameManajer = FindAnyObjectByType<GameManajer>();
                gameManajer.LoseGame();
            }
            Tandatxt.text = "Salah";
        }
    }



    public void VoltUP()
    {
        curr += 10;
        Currtxt.text = curr.ToString();
    }

    public void VoltDown()
    {
        curr -= 10;
        Currtxt.text = curr.ToString();
    }

}
