using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FCG_Score : MonoBehaviour
{
    public GameObject StartPos;
    public TMP_Text ScoresUp;
    public float Distance;



    // Start is called before the first frame update
    void Start()
    {

    }

    public void ScoreUp()
    {
        Distance = (StartPos.transform.position.x + this.transform.position.x);
        ScoresUp.text = Distance.ToString();


    }

    private void Update()
    {
        
    }

}
