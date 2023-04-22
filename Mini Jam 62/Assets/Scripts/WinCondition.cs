using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class WinCondition : MonoBehaviour
{
    public bool win = false;
    public bool lose = false;
    public Text result;
    public Text restart;
    public Text progress;
    
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (FindObjectsOfType<Zombie>().Length <= 0 && !win)
        {
            lose = true;
            result.text = "failure";
            result.gameObject.SetActive(true);
            restart.gameObject.SetActive(true);


        }
        if (FindObjectsOfType<Citizen>().Length <= 0 && !lose)
        {
            win = true;
            result.text = "Nice job";
            result.gameObject.SetActive(true);
            if(SceneManager.GetActiveScene().name == "Level 10")
            {
                progress.text = "Thanks for Playing";
            }
            progress.gameObject.SetActive(true);


        }


    }

    public void SceneLoad(string level)
    {
        SceneManager.LoadScene(level);
    }
}
