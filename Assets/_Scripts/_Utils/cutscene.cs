using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class cutscene : MonoBehaviour {

    public void nextLevel()
    {
        SceneManager.LoadScene("LevelSelect");
    }
    public void cutscene2()
    {
        SceneManager.LoadScene("Fase2A");
    }

}
