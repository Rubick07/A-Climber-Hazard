using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Data", menuName = "Data")]
public class DataSO : ScriptableObject
{
    public string NamaBarang;
    public Sprite gambar;
    [TextArea(3,10)]
    public string penjelasan;


}
