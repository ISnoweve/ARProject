using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void LoadStage1()
    {
        SceneManager.LoadScene("ARDemo1");
    }

    public void LoadStage2()
    {
        SceneManager.LoadScene("ARDemo2");
    }

    public void LoadStage3()
    {
        SceneManager.LoadScene("ARDemo3");
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("ARMenu");
    }
}
