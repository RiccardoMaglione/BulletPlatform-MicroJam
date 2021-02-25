using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject PanelPause;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            PanelPause.SetActive(true);
            Time.timeScale = 0;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PanelPause.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
