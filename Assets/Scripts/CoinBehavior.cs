using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehavior : MonoBehaviour
{

    public GameObject player;
    //float gravScale;
    // Start is called before the first frame update
    void Start()
    {
        //gravScale = player.GetComponent<Rigidbody2D>().gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(gravScale);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //  gravScale += 9.8f;
            //  player.GetComponent<Rigidbody2D>().gravityScale += 1.2f;
            player.GetComponent<Movement>().moveSpeed -= 0.1f;
            player.GetComponent<Movement>().jumpSpeed -= 0.1f;
            // Debug.Log("Gravity scale: " + player.GetComponent<Rigidbody2D>().gravityScale);
            
            //increment player coin value
            player.GetComponent<PlayerStats>().Coins++;
            
            Destroy(this.gameObject);
        }

    }
}
