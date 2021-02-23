using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DragonController : MonoBehaviour
{

    public AudioClip crash;
    public AudioClip flap;
    public AudioClip point;
    public AudioSource audioSource;
    Rigidbody myBod;
    public Animator anim;
    public Text gameover;
    public bool isPaused = false;
    int score = 0;
    Text scoreCounter;

    // Start is called before the first frame update
    void Start()
    {

        scoreCounter = GameObject.Find("Score").GetComponent<Text>();

        anim = GetComponent<Animator>();
        myBod = GetComponent<Rigidbody>();
        myBod.velocity = new Vector3(10,0,0);
        audioSource = GetComponent<AudioSource>();
        gameover = GameObject.Find("GameOver").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update() {

        if (Input.GetButtonDown("Jump")) {
            if (isPaused == false)
            {
                jump();
                anim.Play("Flap");
                audioSource.PlayOneShot(flap, 0.7f);
            }
         
            {
                if (isPaused == true)
                {
                    Time.timeScale = 1;
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
            }
        }

    }

    private void jump()
    {     
             myBod.velocity = new Vector3(10, 15, 0);
       
    }


    void OnTriggerEnter(Collider other) {
        
        audioSource.PlayOneShot(point, 0.7f);
        score++;
        scoreCounter.text = "Score: " + score;

    }

    void OnCollisionEnter(Collision collision) {

     
        if (collision.gameObject.name == "Top" || collision.gameObject.name == "Bottom")
        {
            audioSource.PlayOneShot(crash, 0.7f);
            Time.timeScale = 0;
            gameover.text = "Game Over \n Press Jump to Play again";
            isPaused = true;

        }
      
    }
}
