using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBlock : MonoBehaviour
{
    private Animator anim;
    private bool iscollided = false;
    public GameObject coin;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!iscollided && collision.gameObject.CompareTag("Player"))
        {
            iscollided = true;
            anim.Play("Used");
            Vector2 coinPosition = new Vector2(transform.position.x, transform.position.y + 1f);
            coin = Instantiate(coin, coinPosition, transform.rotation);
        }
    }
}