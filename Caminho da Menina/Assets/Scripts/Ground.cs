using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.transform.parent.gameObject.GetComponent<Player>();
    }
    //quando comecar a colidir
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            player.isJumping = false;
            Debug.Log("COLIDIU");
        }
    }
    //quando parar de colidir
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            player.isJumping = true;
            Debug.Log("PAROU DE COLIDIR");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
