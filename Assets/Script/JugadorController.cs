using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class JugadorController : MonoBehaviour
{
	public float velocidad = 3;
	public float salto=2;
	public int contarMonedas = 0;
	Rigidbody2D jugador;
	Animator jugadorAnim;
	Transform jugadorTransform;
	bool enSuelo = true;
	public GameManager gameManager;

	public bool gameOver = false;
	public Camera mainCamera;
	// Start is called before the first frame update
	void Start()
	{
		jugador = GetComponent<Rigidbody2D>();		
		jugadorTransform = GetComponent<Transform>();
		jugadorAnim = GetComponent<Animator>();
		

	}

	// Update is called once per frame
	void Update() 
	
	{
		if(Input.GetKey(KeyCode.D))
		{
			jugador.velocity = new Vector2(velocidad, jugador.velocity.y);
			jugadorTransform.rotation = new Quaternion(0, 0, 0, 0);
			jugadorAnim.SetBool("run", true);

		}
		else if (Input.GetKey(KeyCode.A))
		{
			jugador.velocity = new Vector2(-velocidad, jugador.velocity.y);
			jugadorTransform.rotation = new Quaternion(0, 180f, 0, 0);
			jugadorAnim.SetBool("run", true);

			
		}
		else
		{
			jugadorAnim.SetBool("run", false);
		}
		
		if (Input.GetKey(KeyCode.W) && enSuelo)
		{
			jugador.velocity = new Vector2(jugador.velocity.x, salto);
			enSuelo = false;
			jugadorAnim.SetBool("jump", true);
		}
		
		
		Vector3 viewportPosition = mainCamera.WorldToViewportPoint(transform.position);

        if (viewportPosition.x < 0 || viewportPosition.x > 1 ||
            viewportPosition.y < 0 || viewportPosition.y > 1)
        {
            gameManager.gameOver = true;
        }

       
        if (transform.position.y < -10) 
        {
            gameManager.gameOver = true;
        }
		
	}
	
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag == "suelo")
		{
			enSuelo = true;
			jugadorAnim.SetBool("jump", false);
		}
		if(collision.gameObject.tag == "obstaculos")
		{
			gameManager.gameOver = true;
		}
		
	}
	
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.tag == "moneda")
		{
			contarMonedas++;
			Destroy(collision.gameObject);
			Text contadorMoneda = GameObject.FindWithTag("contadorMoneda").GetComponent<Text>();
			contadorMoneda.text = contarMonedas.ToString();
		}
	}
}