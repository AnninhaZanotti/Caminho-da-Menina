using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //variavel para o rigidBody
    private Rigidbody2D rig;
    //vetor da posicao Inicial do Player
    private Vector3 posInicial;
    //variavel da velocidade
    private float speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        posInicial = new Vector3(-1.7f, 0.89f, 0f);
        transform.position = posInicial;
    }

    // Update is called once per frame
    void Update()
    {
        rig.velocity = new Vector2(speed, rig.velocity.y);
        rig.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rig.velocity.y);
        //verificar se a tecla A foi pressionada e o valor x da Scale esta positivo
        if (Input.GetKeyDown(KeyCode.A) && transform.localScale.x > 0)
        {
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            //Debug.Log("Tecla A pressionada")
        }
        //verificar se a tecla D foi pressionada e o valor x da Scale esta negativo
        if (Input.GetKeyDown(KeyCode.D) && transform.localScale.x < 0)
        {
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            //Debug.Log("Tecla D pressionada")
        }
    }
}
