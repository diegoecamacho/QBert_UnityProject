using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtomController : MonoBehaviour {

    UIController ui;

    private void Start()
    {
        ui = GameObject.FindGameObjectWithTag("UIController").GetComponent<UIController>();
    }

    public void LoadScene(string sceneName){
        SceneManager.LoadScene(sceneName);
    }

    public void ResumeButtom()
    {
        Time.timeScale = 1;
        ui.InGameUI.SetActive(!ui.InGameUI.activeSelf);
        ui.PauseMenu.SetActive(!ui.PauseMenu.activeSelf);
    }

    public void ExitGame() {
        Application.Quit();
    }
}
