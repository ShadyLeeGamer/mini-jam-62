using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public void SceneLoad(string level)
    {
        SceneManager.LoadScene(level);
    }
}
