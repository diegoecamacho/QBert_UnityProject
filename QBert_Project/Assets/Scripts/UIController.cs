using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour {

    public GameObject InGameUI;
    public GameObject PauseMenu;
    public TextMeshProUGUI PlayerScore;
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
            }
            else
            {
                Time.timeScale = 0;
            }
            InGameUI.SetActive(!InGameUI.activeSelf);

            PauseMenu.SetActive(!PauseMenu.activeSelf);
        }
		
	}
}
