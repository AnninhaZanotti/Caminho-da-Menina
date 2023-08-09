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
    //componente animator
    public Animator animator;
    //variavel para saber se esta pulando
    public bool isJumping = false;
    private float JumpForce = 8;

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
        //se o player se movimentar na horizontal
        if (Input.GetAxis("Horizontal") != 0)
        {
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
        //verificar se a tecla espaco foi pressionada
        if (Input.GetKeyDown(KeyCode.Space) && isJumping == false) 
        {
            rig.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
        }
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //verifica se o objeto tem a Tag Line
        if (collision.gameObject.CompareTag("Line"))
        {
            Debug.Log("Morri");
            //retorno o personagem para´posicao inicial
            transform.position = posInicial;
        }
        //verifica se o objeto tem Checkpoint
        if (collision.gameObject.CompareTag("Checkpoint"))
        {
            Debug.Log("Checkpoint");
            //modifica a posicao inicial para a posicao do checkpoint
            posInicial = collision.gameObject.position;
        }
    }
}
