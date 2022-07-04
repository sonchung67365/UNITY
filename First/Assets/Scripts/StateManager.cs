using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public string state;
    public Movement move;
    public Score score;
    public FloorSpawn floor;
    public SpriteRenderer sprite;
    public MusicManager music;
    public Menu menu;
    // Start is called before the first frame update
    void Start()
    {
        state = "Idle";
        music.Play();
        move.SetGravity(0);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Die();
        }
    }

    public void Die()
    {
        state = "Dead";
        music.PlayDie();
        sprite.enabled = false;
        move.SetGravity(0);
        score.End();
        floor.ClearStorage();
        StartCoroutine(Delay());
    }

    public void Respawn()
    {
        transform.position = new Vector3(-5, -1, transform.position.z);
        sprite.enabled = true;
        menu.ChangeMenu(true);
    }

    public void StartGame()
    {
        move.SetGravity(5);
        state = "Playing";
        menu.ChangeMenu(false);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        menu.ChangePause(true);
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        menu.ChangePause(false);
    }

    public void Quit()
    {
        Application.Quit();
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1);
        Respawn();
    }
}
