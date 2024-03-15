using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public GameObject piso;
	public GameObject obstaculo1;
	public GameObject obstaculo2;
	public GameObject menuPrincipal;
	public GameObject menuFinal;
	public Renderer background;
	public float velocidad=2;

	public List<GameObject> pisos;
	public List<GameObject> obstaculos;
	public List<GameObject> escaladas;
	public bool gameOver = false;
	public bool start = false;
	

	// Start is called before the first frame update
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		if(start == false)
		{
			if(Input.GetKeyDown(KeyCode.Space))
			{
				start = true;
				menuPrincipal.SetActive(false);
				
			}
		}
		if(start == true && gameOver ==true)
		{
			if(Input.GetKeyDown(KeyCode.Space))
			{
				menuFinal.SetActive(true);
				SceneManager.LoadScene(SceneManager.GetActiveScene().name);
				
				
			}
		}
		if(start == true && gameOver == false)
		{
			
			menuFinal.SetActive(false);
		
		
		}
		
	}
}
