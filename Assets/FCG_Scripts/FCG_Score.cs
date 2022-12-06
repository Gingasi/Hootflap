using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FCG_Score : MonoBehaviour
{
    
    public TMP_Text ScoresUp;
    public int score;
    private int NextLevel = 5;
    private AudioSource Aaah;
    public AudioClip HootHoot;

    private FCG_SpawnManager FCG_SpawnManagerScript ;



    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        ScoresUp.text = score.ToString();
        FCG_SpawnManagerScript = GameObject.Find("FCG_ObstacleSpawn").GetComponent<FCG_SpawnManager>();
        Aaah = GetComponent<AudioSource>();
    }

    public void ScoreUp()
    {
        score++; 
        ScoresUp.text = score.ToString();

    }

    public void LevelUp()
    {
        if (score >= NextLevel)
        {
            Aaah.PlayOneShot(HootHoot, 1f);
        }
    }
  
}
