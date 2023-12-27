using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scoring : MonoBehaviour
{
    public MapdragHandler[] score;
    public TextMeshProUGUI scoreText;
    public float netscore;

    // Update is called once per frame
    public void Updatescore()
    {
        netscore =0;
        foreach(MapdragHandler s in score){
            netscore = netscore + s.Score;
        }

        scoreText.text = string.Format("Score: {0:0}", netscore);
    }
}
