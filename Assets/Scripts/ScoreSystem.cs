using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    public int ScoreInt;    //Variabile che identifica lo score
    public Text ScoreText;  //Variabile dove verrà visualizzato lo score
    public GameObject Player;   //Rappresenta il player

    void Update()
    {
        ScoreCalculate();
    }

    /// <summary>
    /// Calcola lo score del player in base alla altezza raggiunta
    /// </summary>
    public void ScoreCalculate()
    {
        if (ScoreInt < Player.transform.position.y)
        {
            ScoreInt = (int)Player.transform.position.y;

            ScoreText.text = ScoreInt.ToString();
        }
    }
}
