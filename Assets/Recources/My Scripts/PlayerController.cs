using System;
using System.Collections;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

	//public CharacterController2D controller;
	public float speed;
	private Rigidbody2D rb2d;
	public float jumpHeight;
	public SpriteRenderer spriteRenderer;
	private static int count = 0;



	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		SpriteRenderer = GetComponent<SpriteRenderer>();
		Scene currentScene = SceneManager.GetActiveScene();
		
		if (!currentScene.isLoaded){
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Console.Out.WriteLine(count);
		float moveHorizontal = Input.GetAxis ("Horizontal");
		//Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
		Vector2 movement = new Vector2 (moveHorizontal, 0);
		//Vector2 Nmovement = new Vector2 (moveHorizontal * -1, 0);
		Vector2 jump = new Vector2 (0f, 2f);
		if (Input.GetKeyDown (KeyCode.W)) {
			rb2d.AddForce (jump * jumpHeight, ForceMode2D.Impulse);
			
		}

		rb2d.AddForce (movement * speed);
		//controller.Move(moveHorizontal * Time.deltaTime, false, jump);
		
        if (Input.GetKeyDown (KeyCode.A)) {
			rb2d.AddForce (movement * speed);
		}
			
		if (Input.GetKeyDown (KeyCode.D)) {
			rb2d.AddForce (movement * -speed);
		}

		if (Input.GetKeyDown (KeyCode.J)) {
			
		}

		}
	}