using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavigationController : MonoBehaviour
{
    public string backSceneName;

    public void LoadMenuScene()
    {
        SceneManager.LoadScene(backSceneName);
    }
}
