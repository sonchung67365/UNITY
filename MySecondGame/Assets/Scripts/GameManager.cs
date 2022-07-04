using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static int lives = 3;
    public static string state;
    public Menu menu;
    public GameObject enemies;
    public Transform storage;
    public MusicManager music;
    public static int score;
    public static int scoreCombo;
    private void Start()
    {
        state = "Idle";
        music.PlaySoundtrack();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //livesText.text = "Lives: " + lives.ToString();
        if (lives == 0) 
        {
            Die();
        }
    }

    public void StartGame()
    {
        state = "Play";
        menu.ChangeStart(true);
        GameObject enemiesclone = Instantiate(enemies) as GameObject;
        enemiesclone.transform.position = new Vector3(-5, 4, 0);
        enemiesclone.transform.SetParent(storage);
    }

    public void Die()
    {
        state = "Dead";
        menu.ChangeDie(true);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        menu.ChangePause(true);
        music.StopSoundtrack();
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        menu.ChangePause(false);
        music.PlaySoundtrack();
    }

    public void Quit()
    {
        Application.Quit();
    }
}
