using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class rules : MonoBehaviour
{
    public void SkipPlay()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1;
    }
}
