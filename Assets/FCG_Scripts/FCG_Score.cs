using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FCG_Score : MonoBehaviour
{

   //This script detectsthe score in the game and shows it to the ui so the player has some feedback
     

    public TMP_Text ScoresUp;
    public int score;
    private int NextLevel = 5;
    private AudioSource Aaah;
    public AudioClip HootHoot;

    private FCG_SpawnManager FCG_SpawnManagerScript;

    private bool goToScoreBoard;

    void Start()
    {
        score = 0;
        ScoresUp.text = score.ToString();
        FCG_SpawnManagerScript = GameObject.Find("FCG_ObstacleSpawn").GetComponent<FCG_SpawnManager>();
        Aaah = GetComponent<AudioSource>();
        goToScoreBoard = false;
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


    public List<int> currentHighScores = new List<int>();

    private void Awake()
    {
        currentHighScores.Add(PlayerPrefs.GetInt("firstrstplace")); 
        currentHighScores.Add(PlayerPrefs.GetInt("SecondPlace")); 
        currentHighScores.Add(PlayerPrefs.GetInt("ThirdPlace")); 
        currentHighScores.Add(PlayerPrefs.GetInt("FourthPlace")); 
        currentHighScores.Add(PlayerPrefs.GetInt("FifthPlace")); 
    }

    public void SearchUserRank() //Before showing the rank it search wich other score it has so it can array according to the highest five scores. If you dont qualify within those five you dont appear in the ranking score
    {
        { int scoreRank = 5;

        for (int i = 0; i < 5; i++)
            if (score > currentHighScores[i])
            {
                scoreRank = i;

                break;
            }

        if (scoreRank < 5)
        {
            FCG_DataPersistance.SharedInstance.scoreBeated = scoreRank;
            int scoreInt = (int)Mathf.Round(score);

            goToScoreBoard = true;

            currentHighScores.Insert(scoreRank, scoreInt);
            currentHighScores.RemoveAt(5);
        }

        else
        {
            return;
        }

        }
    }

    public void RankingUpdate() 
    {
        FCG_DataPersistance.SharedInstance.FirstrstPlace = currentHighScores[0];
        FCG_DataPersistance.SharedInstance.SecondPlace = currentHighScores[1];
        FCG_DataPersistance.SharedInstance.ThirdPlace = currentHighScores[2];
        FCG_DataPersistance.SharedInstance.FourthPlace = currentHighScores[3];
        FCG_DataPersistance.SharedInstance.FifthPlace = currentHighScores[4];

        FCG_DataPersistance.SharedInstance.SaveForFutureGames(); //we save our changes on PlayerPrefs
    }
}






