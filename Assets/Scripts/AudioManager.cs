using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
	public AudioClip coin;
	public AudioClip goomba;
	public AudioClip game;
	public AudioClip jump;
	public AudioClip death;
	public AudioClip win;

	private AudioSource sound;

    private void Start()
    {
		sound = GetComponent<AudioSource>();
    }

    public void CoinSound()
    {
        sound.PlayOneShot(coin);
    }

    public void GoombaSound()
    {
        sound.PlayOneShot(goomba);
    }

    public void GameSound()
    {
        sound.PlayOneShot(game);
    }

    public void JumpSound()
    {
        sound.PlayOneShot(jump);
    }

    public void DeathSound()
    {
        sound.PlayOneShot(death);
    }

    public void WinSound()
    {
        sound.PlayOneShot(win);
    }

    public void StopSound()
    {
        sound.Stop();
    }

    public void RestartGame()
    {
        StartCoroutine(Restart());
    }

    IEnumerator Restart()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("StartScene");
    }
}
