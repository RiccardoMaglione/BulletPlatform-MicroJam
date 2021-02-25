using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    public int ScoreInt;
    public Text ScoreText;
    public GameObject Player;

    void Update()
    {
        if(ScoreInt < Player.transform.position.y)
        {
            ScoreInt = (int)Player.transform.position.y;

            ScoreText.text = ScoreInt.ToString();
        }
    }
}
