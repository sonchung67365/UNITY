﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Text livesText;
    public Text endText;
    public Button play;
    public Button pause;
    public Button resume;
    public Button replay;
    public Button quit;
    public GameObject panel;
    public Text score;
    public Text scoreCombo;
    private void FixedUpdate()
    {
        livesText.text = "Lives: " + GameManager.lives.ToString();
        score.text = "Score: " + GameManager.score.ToString();
        scoreCombo.text = "Combo: " + GameManager.scoreCombo.ToString();
    }
    public void ChangeStart(bool x)
    {
        play.gameObject.SetActive(!x);
        pause.gameObject.SetActive(x);
        livesText.gameObject.SetActive(x);
        score.gameObject.SetActive(x);
        scoreCombo.gameObject.SetActive(x);
    }

    public void ChangePause(bool x)
    {
        resume.gameObject.SetActive(x);
        quit.gameObject.SetActive(x);
        pause.gameObject.SetActive(!x);
        panel.SetActive(x);
    }

    public void ChangeDie(bool x)
    {
        endText.gameObject.SetActive(x);
        //replay.gameObject.SetActive(x);
        pause.gameObject.SetActive(!x);
    }

    public void ChangeReplay(bool x)
    {
        endText.gameObject.SetActive(!x);
        replay.gameObject.SetActive(!x);
        pause.gameObject.SetActive(x);
        livesText.gameObject.SetActive(x);
        score.gameObject.SetActive(x);
        scoreCombo.gameObject.SetActive(x);
    }
}
