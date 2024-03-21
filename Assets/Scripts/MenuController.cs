using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public string nextSceneName;
    public static string selectedItem = "";

    void Start()
    {

    }

    public void LoadItemScene(string itemName)
    {
        selectedItem = itemName;
        if (SceneManager.GetActiveScene() != SceneManager.GetSceneByName(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
