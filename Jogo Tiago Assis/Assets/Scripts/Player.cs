using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour {
  private Rigidbody2D player2D;
  private int gravidade = 0;
  public float speed = 0;
  private SpriteRenderer posicao;

  // Use this for initialization
    void Start () {

      //pegar as propriedades
      player2D = GetComponent<Rigidbody2D>();
      posicao = GetComponent<SpriteRenderer> ();

    }

  // Update is called once per frame
    void Update () {

      print (transform.position.x.ToString ());


      //comando para subir o player
        if (Input.GetKeyDown (KeyCode.UpArrow)) {
          gravidade = -2;
          player2D.gravityScale = gravidade;
        }

      //comando para descer o player
        if (Input.GetKeyUp (KeyCode.UpArrow)) {
          gravidade = 10;
          player2D.gravityScale = gravidade;
        }


      //Move para a direita quando aperta a tecla
        if (Input.GetKeyDown (KeyCode.RightArrow)) {
          //inverte o lado da imagem (espelhamento)
          posicao.flipX = false;
          player2D.transform.Translate ((speed * 10) * (Time.deltaTime / 2), 0, 0);
        }


        if (Input.GetKeyDown (KeyCode.LeftArrow)) {
          //inverte o lado da imagem (espelhamento)
          posicao.flipX = true;
          player2D.transform.Translate ((speed * -10) * (Time.deltaTime / 2), 0, 0);
        }

      MoveKeyboard ();
    }


  void MoveKeyboard()


    {
      float horizontal = Input.GetAxisRaw ("Horizontal");
      float vertical = Input.GetAxisRaw ("Vertical");

      if (horizontal != 0 || vertical != 0) 

        {
          Vector2 moviment = new Vector2 (horizontal, vertical);

          Rigidbody2D rigid2d = GetComponent<Rigidbody2D> ();

          rigid2d.MovePosition (rigid2d.position + moviment * speed * Time.deltaTime);

        }        

    }

  void OnTriggerEnter2D (Collider2D coll)

    {
      if (coll.gameObject.name == "Portal") 
        {
          transform.position = new Vector3(-5.8f, transform.position.y,transform.position.z); 
        }

      if (coll.gameObject.name == "Portal (1)") 
        {
          transform.position = new Vector3(5f, transform.position.y,transform.position.z);
        }
    }
}