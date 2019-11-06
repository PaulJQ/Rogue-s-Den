using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehavior : MonoBehaviour
{

    public CharacterController2D controller;
    public float runSpeed = 20;
    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    public bool visable = true;
    public float time = 0;
    public GameObject currentInterObj = null;
    [SerializeField] private Collider2D hideDisableCollider;
    public int talk_int = 0;

    // Start is called before the first frame update
    void Start()
    {

    }
    void invis()
    {
        visable = !visable;
    }
    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        if (Input.GetKeyDown(KeyCode.T))
        {
            invis();
        }
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Hide"))
        {
            currentInterObj = other.gameObject;
            if (Input.GetKey("Interact"))
            {
                invis();
                runSpeed = 0;

            }
            if (Input.GetKey("Interact") && visable == false)
            {
                invis();
                runSpeed = 20;

            }
        }
        if (other.CompareTag("Slow"))
        {
            currentInterObj = other.gameObject;
            runSpeed = 7;

        }
        if (other.CompareTag("Death"))
        {
            currentInterObj = other.gameObject;
            SceneManager.LoadScene("demo 0.1");
        }
        if (other.CompareTag("Drop"))
        {
            currentInterObj = other.gameObject;

        }
        if (other.CompareTag("Pickup"))
        {
            currentInterObj = other.gameObject;
            

        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Talk"))
        {
            if (Input.GetKeyDown(KeyCode.J))
                other.GetComponent<Chef_Dialogue>().speak();
            //currentInterObj = other.gameObject;
            //if (Input.GetKeyDown(KeyCode.J) )
            //{
            //    Dialogue dialogue = (Dialogue)currentInterObj.GetComponent(typeof(Dialogue));
            //    dialogue.speak(talk_int);
            //    talk_int++;
            //    if (talk_int > dialogue.dialogue_limit)
            //    {
            //        talk_int = 0;
            //    }
            //}
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Hide"))
        {
            if (other.gameObject == currentInterObj)
            {
                currentInterObj = null;
            }
        }
        if (other.CompareTag("Slow"))
        {
            if (other.gameObject == currentInterObj)
            {
                currentInterObj = null;
                runSpeed = 20;

            }
        }
        if (other.CompareTag("Death"))
        {
            if (other.gameObject == currentInterObj)
            {
                currentInterObj = null;
            }
        }
        if (other.CompareTag("Talk"))
        {
            talk_int = 0;
            currentInterObj = other.gameObject;
            Dialogue dialogue = (Dialogue)currentInterObj.GetComponent(typeof(Dialogue));
            dialogue.clear();

        }
        if (other.CompareTag("Drop"))
        {
            if (other.gameObject == currentInterObj)
            {
                currentInterObj = null;
            }
        }
        if (other.CompareTag("Pickup"))
        {
            if (other.gameObject == currentInterObj)
            {
                currentInterObj = null;
            }
        }
    }
}
