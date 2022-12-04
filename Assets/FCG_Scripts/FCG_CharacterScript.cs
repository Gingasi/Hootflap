using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FCG_CharacterScript : MonoBehaviour
{
    public float Velocity = 1f;
    private Rigidbody2D HootyCharacter;

    private AudioSource HootyChar;
    public AudioClip HootHoot;
    public AudioClip BoomDeath;
    public ParticleSystem DeathPart;

    public bool gameOver = false;
 

    public GameObject DeathMenuUI;
    private FCG_Score FCG_ScoreScript;



    // Start is called before the first frame update
    void Start()
    {
        FCG_ScoreScript = GameObject.Find("FCG_ObstacleSpawn").GetComponent<FCG_Score>();
        HootyCharacter = GetComponent<Rigidbody2D>();
        HootyChar = GetComponent<AudioSource>();
        DeathMenuUI.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        MovementHooty();
    }

    private void OnCollisionEnter2D(Collision2D othercollision)
    {
      if (othercollision.gameObject.CompareTag("Hoot"))
        {
            HootyChar.PlayOneShot(HootHoot, 1f);
            FCG_ScoreScript.ScoreUp();
        }

      if (othercollision.gameObject.CompareTag("Obstacle")) 
        {
            //HootyChar.PlayOneShot(BoomDeath, 1f); 
            DeathPart.Play();
            Death();
        }
      if (othercollision.gameObject.CompareTag("Floor"))
        {
            Death();
            //HootyChar.PlayOneShot(BoomDeath, 1f); 
            DeathPart.Play();
         
        }
    }

    public void Death()
    {
        gameOver = true;
        Time.timeScale = 0f;
        DeathMenuUI.SetActive(true);
    }

    public void MovementHooty()
    {
        if (Input.GetMouseButtonDown(0))
        {
            HootyCharacter.velocity = Vector2.up * Velocity;
            
        }
    }
}
