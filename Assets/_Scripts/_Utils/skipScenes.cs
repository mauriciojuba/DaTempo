using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class skipScenes : MonoBehaviour {
    
    public void stageSelect()
    {
        SceneManager.LoadScene("LevelSelect");
    }
    public void playerSelect()
    {
        SceneManager.LoadScene("PlayerSelect");
    }
    public void mainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
