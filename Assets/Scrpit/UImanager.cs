using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UImanager : MonoBehaviour
{
    public GameObject endcanves;
    //void Start()
    //{
    //    endcanves.SetActive(false);
    //}
    public void Endgame()
    {
        endcanves.SetActive(true);
        Time.timeScale = 0.1f;
    }
    public void reload()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1;
    }
    public void Mianmenu()
    {
        SceneManager.LoadScene(0);
    }
}
