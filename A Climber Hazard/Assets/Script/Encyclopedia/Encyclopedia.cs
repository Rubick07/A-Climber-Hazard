using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Encyclopedia : MonoBehaviour
{
    [SerializeField] private DataSO[] Data;
    [SerializeField] private TMP_Text nama;
    [SerializeField] private Image gambar;
    [SerializeField] private TMP_Text penjelasan;

    int index = 0;
    int Panjang_Array;
    private void Start()
    {
        nama.text = Data[0].NamaBarang;
        gambar.sprite = Data[0].gambar;
        penjelasan.text = Data[0].penjelasan;
        Panjang_Array = Data.Length;
    }
    public void NextPage()
    {
        if(index + 1 == Panjang_Array)
        {
            index = 0;
        }
        else
        {
            index++;
        }
        UpdatePage();
    }

    public void PrevPage()
    {
        if (index == 0)
        {
            index = Panjang_Array - 1;
        }
        else
        {
            index--;
        }
        UpdatePage();
    }

    public void UpdatePage()
    {
        nama.text = Data[index].NamaBarang;
        gambar.sprite = Data[index].gambar;
        penjelasan.text = Data[index].penjelasan;
    }

}
