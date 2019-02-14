using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{

    public Rigidbody rb;
    private float speed;
    public float JumpHeight;
    public bool onGround;
    public GameObject spawn;
    public GameObject spawn2;
    public GameObject spawn3;
    public GameObject spawn4;
    public GameObject spawn5;
    public GameObject spawn6;
    public GameObject EmptyObject;
    public GameObject winImage;
    public Text instructionText;
    public Text goalText;
    public Text leveltxt;
    public Text quotestext;
    public Text livestext;
    private float timer;
    private float timer2;
    private float timer3;
    private float timer4;
    private bool nextText;
    private int level;
    public int quotes;
    private int lives;

    //touchscreen
    private Vector3 startTouch;
    private Vector3 endTouch; 
    private float startTime;
    private float endTime;
    private float maxTime;
    private float minSwipeDis;
    private float swipeDistance;
    private float swipeTime;
    private Vector2 touchDistance;
    

    void Start()
    {
        instructionText.text = "Use arrows for control, space to jump, shift to switch camera";
        

        rb = GetComponent<Rigidbody>();
        timer = 3.7f;
        timer2 = 5.0f;
        timer3 = 5.0f;
        timer4 = 3.0f;
        level = 1;
        lives = 3;
       

    }

    void FixedUpdate()
    {
        transform.parent = EmptyObject.transform;
        timer2 -= Time.deltaTime;

        if (lives == 0)
        {
            transform.position = spawn.transform.position;
        }
            
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                startTime = Time.time;
                startTouch = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                endTime = Time.time;
                endTouch = touch.position;

                swipeDistance = (endTouch - startTouch).magnitude;
                swipeTime = endTime - startTime;

                if (swipeTime < maxTime && swipeDistance > minSwipeDis)
                {
                    swipe ();
                }
            }
        }

    
        switch (quotes)
        {
            case 1:
                quotestext.text = "";
                  timer4 = 3.0f;
                break;
            case 2:
                quotestext.text = "This is more disturbing than your icognito tabs";
                break;
            case 3:
                quotestext.text = "Have you even played a game before?";               
                break;
            case 4:
                quotestext.text = "Well, I hope you are good at something else";             
                break;
            case 5:
                quotestext.text = "Error 404, skills not found";              
                break;
            case 6:
                quotestext.text = "I hope you're not actually trying";              
                break;
            case 7:
                quotestext.text = "Please practice next time";               
                break;
            case 8:
                quotestext.text = "That move just gave me a virus, please open the antivirus program";
                break;
            case 9:
                quotestext.text = "You make Windows Vista look cool";        
                break;
            case 10:
                quotestext.text = "Seiji should've made the game a lot easier for you";
                break;
        }

        if (Input.GetKey("escape"))
        { Application.Quit(); }
        if (timer2 < 0) { instructionText.text = "";goalText.text = "Reach the green platform"; nextText = true; }
        if (nextText) { timer3 -= Time.deltaTime; }
        if (timer3 < 0) { goalText.text = ""; }

        if (Input.GetButton("Jump") && onGround || Input.touchCount == 1 && onGround)

        {
            rb.AddForce(new Vector3(0, JumpHeight, 0));
            onGround = true;
        }
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        //rb.AddForce(movement * speed);

      rb.MovePosition(transform.position + movement * speed);
        //rb.MovePosition(transform.position + BackwardDir * moveHorizontal);

   
        if (onGround == false)
        {
            timer -= Time.deltaTime;

            if (onGround == false && timer < 1 && lives > 0)
            {
                // Application.LoadLevel(Application.loadedLevel);
                // transform.position = new Vector3(16, 138, -6);
             

                switch (level)
                {
                    case 1: transform.position = spawn.transform.position;
                        level = 1;
                        break;
                    case 2:
                        transform.position = spawn2.transform.position;
                        level = 2;
                        
                        break;
                    case 3:
                        transform.position = spawn3.transform.position;
                        level = 3;
                        break;
                    case 4:
                        transform.position = spawn4.transform.position;
                        level = 4;
                        break;
                    case 5:
                        transform.position = spawn5.transform.position;
                        level = 5;
                        break;
                    case 6:
                        transform.position = spawn6.transform.position;
                        level = 6;
                        break;

                }

               

                onGround = true;
                JumpHeight = 0;
                quotes = Random.Range(2,10);
                lives--;
                   
                
            }

        }
        if (lives == 0)
        {
            level = 1;
            transform.position = spawn.transform.position;
            lives = 3;
        }

        if (onGround == true && timer >= 0)
        {
            timer = 3.7f;
        }
        if(quotes > 1)
        {
            timer4 -= Time.deltaTime;
        }

        if (timer4 < 0)

            quotes = 1;

        
  
        livestext.text = "Lives:" + lives;
          
    }

    void OnCollisionEnter(Collision col)
    {
        onGround = true;
        JumpHeight = 800;
        speed = 0.12f;
        if (col.gameObject.tag == "level2")
        {
            transform.position = spawn2.transform.position;
            level = 2;
        }

        if (col.gameObject.tag == "level3")
        {
            transform.position = spawn3.transform.position;
            level = 3;
        }
        if (col.gameObject.tag == "level4")
        {
            transform.position = spawn4.transform.position;
            level = 4;
        }
        if (col.gameObject.tag == "level5")
        {
            transform.position = spawn5.transform.position;
            level = 5;
        }
        if (col.gameObject.tag == "level6")
        {
            transform.position = spawn6.transform.position;
            level = 6;
        }
        if (col.gameObject.tag == "high")
            {
                JumpHeight += 2200;
            }

        leveltxt.text = "Level: " + level;

        if(col.gameObject.tag == "finish")
        {
            winImage.SetActive(true);
        }
    }

    void OnCollisionStay(Collision col)
    {
        
        if (col.gameObject.tag == "moving")
        {
           
           EmptyObject.transform.parent = col.transform;        
        }   
    }

    void OnCollisionExit(Collision col)
    {
        onGround = false;
        speed = 0.18f;
        if (col.gameObject.tag == "high")
        {
            JumpHeight -= 3000;
            timer = 7;
        }

        if (col.gameObject.tag == "moving")
        {
            EmptyObject.transform.parent = null;
        }
    }

    void swipe()
    {
        touchDistance = endTouch - startTouch;

        if(Mathf.Abs(touchDistance.x) > Mathf.Abs(touchDistance.y))
        {

        }

       else if (Mathf.Abs(touchDistance.x) < Mathf.Abs(touchDistance.y))
        {

        }
    }
}




