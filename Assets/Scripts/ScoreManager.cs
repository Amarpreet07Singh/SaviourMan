using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI score;
     

    // Update is called once per frame
    public void UpdateScore()
    {
        score.text = (int.Parse(score.text)+1).ToString();
    }
}
