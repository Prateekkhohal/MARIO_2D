using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float movementSpeed = 3f;
    public float detectionRange = 20f;

    private Transform player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (player != null)
        {
            // Calculate the horizontal distance between the enemy and the player
            float horizontalDistanceToPlayer = player.position.x - transform.position.x;

            // Check if the player is within the detection range
            if (Mathf.Abs(horizontalDistanceToPlayer) <= detectionRange)
            {
                // Move towards the player in the horizontal direction only
                Vector3 movement = new Vector3(horizontalDistanceToPlayer, 0f, 0f).normalized * movementSpeed * Time.deltaTime;
                transform.Translate(movement);
            }
        }

        if(transform.position.y <= -6)
        {
            Destroy(gameObject);
        }
    }
}
