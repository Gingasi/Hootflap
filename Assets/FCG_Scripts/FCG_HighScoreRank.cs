using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class FCG_HighScoreRank : MonoBehaviour
{
    public TMP_Text[] scoreRanks;

    public void UpdateHighScorePanel() //we update the UI to show the new scoreBoard Updated
    {
        scoreRanks[0].text = FCG_DataPersistance.SharedInstance.FirstrstPlace.ToString();
        scoreRanks[1].text = FCG_DataPersistance.SharedInstance.SecondPlace.ToString();
        scoreRanks[2].text = FCG_DataPersistance.SharedInstance.ThirdPlace.ToString();
        scoreRanks[3].text = FCG_DataPersistance.SharedInstance.FourthPlace.ToString();
        scoreRanks[4].text = FCG_DataPersistance.SharedInstance.FifthPlace.ToString();
    }

    void Start()
    {
        UpdateHighScorePanel();
    }
}
