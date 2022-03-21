using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
{
    public Text ScoreText;
    public Text BestScoreTxt;

    public void SetScoreTxt(int points)
    {
        ScoreText.text = $"Score : {points}";
    }

    public void SetBestScoretxt(string name, int points)
    {
        BestScoreTxt.text = $"Best Score: {name} : {points}";
    }
}
