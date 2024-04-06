using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public void ChangeScene(string SceneName)
    {
        Debug.Log("Masuk");
        SceneManager.LoadScene(SceneName);
    }
}
