using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FCG_MoveLeft : MonoBehaviour
{
   //The object attached with this script has to move left every time its spawned

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * movespeed);
    }
}
