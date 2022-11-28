using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FCG_CharacterScript : MonoBehaviour
{
    public float Velocity = 1f;
    private Rigidbody2D HootyCharacter;


    // Start is called before the first frame update
    void Start()
    {
        HootyCharacter = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
         HootyCharacter.velocity = Vector2.up * Velocity;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
