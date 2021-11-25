using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    int score = 0;
    void Start()
    {
        Enemy.scoreEvent.AddListener(updatescore);
        Enemy2.scoreEvent.AddListener(updatescore);
        Enemy3.scoreEvent.AddListener(updatescore);
    }
    void updatescore()
    {
        score += 10;
        scoreText.text = "Score : 000" + score.ToString();
        if (score == 0)
        {
            return;
        }
        if (Mathf.Abs(score % 50) == 0)
        {
            EnemySpawner.instance.currentCount += 1;
        }
    }
}
