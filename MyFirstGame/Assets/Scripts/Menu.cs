using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Menu : MonoBehaviour
{
    public TextMeshProUGUI score, highscore, speed;
    public Button play, pause, resume, quit;
    public void ChangeMenu(bool x)
    {
        play.gameObject.SetActive(x);
        score.gameObject.SetActive(!x);
        highscore.gameObject.SetActive(!x);
        speed.gameObject.SetActive(!x);
        pause.gameObject.SetActive(!x);
    }

    public void ChangePause(bool x)
    {
        pause.gameObject.SetActive(!x);
        resume.gameObject.SetActive(x);
        quit.gameObject.SetActive(x);
    }
}
