using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool GaneIsOver;

    public GameObject gameOverUI;

    void Start()
    {
        GaneIsOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GaneIsOver)
        {
            return;
        }
        if (Input.GetKeyDown("e"))
        {
            EndGame();
        }
        if (PlayerStates.Lives <=0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        GaneIsOver = true;
        gameOverUI.SetActive(true);
    }
}
