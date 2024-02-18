using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    private float life = 1f;

    private new AudioManager audio;
    private Player player;

    private void Awake()
    {
        Destroy(gameObject, life);
    }

    private void Start()
    {
        audio = FindObjectOfType<AudioManager>();
        player = FindObjectOfType<Player>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            audio.GoombaSound();
            Destroy(collision.gameObject);
            player.UpdateScore(20);
        }
    }
}
