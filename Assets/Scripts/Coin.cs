using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private new AudioManager audio;
    private Player player;

    private void Start()
    {
        audio = FindObjectOfType<AudioManager>();
        player = FindObjectOfType<Player>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            audio.CoinSound();
            Destroy(gameObject);
            player.UpdateScore(10);
        }
    }
}