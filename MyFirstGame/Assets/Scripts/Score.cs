using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public Transform player;
    public int score, highscore;
    public TextMeshProUGUI scoretext, highscoretext, speed;
    public Movement move;
    void Start()
    {
        highscore = PlayerPrefs.GetInt("Highscore");
        highscoretext.text = "Highscore: " + highscore.ToString();
    }
    void LateUpdate()
    {
        score = Mathf.RoundToInt(player.transform.position.x - transform.position.x);
        scoretext.text = "Score: " + score.ToString();
        speed.text = "Speed: " + (move.speed - 4).ToString();
    }

    public void End()
    {
        if (score > highscore)
        {
            highscore = score;
            highscoretext.text = "Highscore: " + highscore.ToString();
            PlayerPrefs.SetInt("Highscore",highscore);
            PlayerPrefs.Save();
        }
    }
}
