using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;  


public class PlayerController : MonoBehaviour
{
    public float playerJumpForce = 20f;
    public float playerSpeed = 5f;
    public Sprite[] mySprites;
    private int index = 0;

    private Rigidbody2D myrigidbody2d;
    private SpriteRenderer mySpriteRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myrigidbody2d = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>(); 
        StartCoroutine(WalkCoRutine());

    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        // Movimiento de personaje (1: derecha, -1: izquierda)
        myrigidbody2d.linearVelocity = new Vector2(
            horizontal * playerSpeed,
            myrigidbody2d.linearVelocity.y);

        // Cambio de direccion de personaje dependiendo de la direccion del movimiento
        if (horizontal > 0)
        {
            mySpriteRenderer.flipX = false; // Mira a la derecha
        }
        else if (horizontal < 0)
        {
            mySpriteRenderer.flipX = true;  // Mira a la izquierda
        }
        // Salto de personaje
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myrigidbody2d.linearVelocity = new Vector2(
                myrigidbody2d.linearVelocity.x,
                playerJumpForce);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Detectar colisiones con objetos etiquetados como "ItemGood" y destruirlos, falta agregar GameManager para sumar puntaje.
        if (collision.CompareTag("ItemGood"))
        {
            Destroy(collision.gameObject);
            // myGameManager.AddScore();
        }
        // Detectar colisiones con objetos etiquetados como "EnemyN" y destruirlos
        if (collision.CompareTag("Enemy3") || collision.CompareTag("Enemy2") || collision.CompareTag("Enemy1"))
        {
            Destroy(collision.gameObject);
            PlayerDeath();
        }
        if (collision.CompareTag("DeathZone"))
        {
            PlayerDeath();
        }
    }
    // Muerte de personaje (AGREGAR TAG PLAYER)
    void PlayerDeath() 
    {
        SceneManager.LoadScene("DeathScene");
    }

    IEnumerator WalkCoRutine()
    {
        yield return new WaitForSeconds(0.1f);
        mySpriteRenderer.sprite = mySprites[index];
        index++;
        if (index >= mySprites.Length)
        {
            index = 0;
        }
        StartCoroutine(WalkCoRutine());
    }
}
