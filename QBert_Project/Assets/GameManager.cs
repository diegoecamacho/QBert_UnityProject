using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    UIController ui;

    public static int score = 0000;
    GameObject[] gameCubes;
    bool gameOver;
    Color cubeColor;
    // Use this for initialization
    void Start () {

        ui = GameObject.FindGameObjectWithTag("UIController").GetComponent<UIController>();
        gameCubes = GameObject.FindGameObjectsWithTag("Cube");
        cubeColor = Color.red;
        InvokeRepeating("IsGameOver", 0.0f, 3.0f);
	}
	
	// Update is called once per frame
	void Update ()
    {
        ui.PlayerScore.text = score.ToString();
      
    }

    private void IsGameOver()
    {
        Debug.Log("Hello");
        gameOver = true;
        foreach (GameObject cube in gameCubes)
        {
            CubeObjectScript cubeScript = cube.GetComponent<CubeObjectScript>();
            if (!cubeScript.cubeFinished)
            {
                gameOver = false;
            }

        }
        if (gameOver)
        {
            //TODO: implement Win Screen
            score += 1000;
            score += 100 * GameObject.FindGameObjectsWithTag("Elevator").Length;
            Debug.Log("gAMEoVER");
        }
    }
}
