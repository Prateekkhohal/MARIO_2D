using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHit : MonoBehaviour
{
    private new AudioManager audio;
    public Text GameOverTxt;

    private Animator anim;
    private void Start()
    {
        GameOverTxt.text = "";
        audio = FindObjectOfType<AudioManager>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if(transform.position.y <= -6)
        {
            audio.StopSound();
            audio.DeathSound();
            GameOverTxt.text = "GAME OVER";
            Destroy(gameObject);
            audio.RestartGame();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            audio.StopSound();
            audio.DeathSound();
            GameOverTxt.text = "GAME OVER";
            Destroy(gameObject);
            audio.RestartGame();

        }
        if (collision.gameObject.CompareTag("Finish"))
        {
            audio.StopSound();
            audio.WinSound();
            GameOverTxt.text = "LEVEL CLEARED";
            audio.RestartGame();
        }
    }

}