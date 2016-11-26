using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class cutscene : MonoBehaviour {

    public void nextLevel()
    {
        SceneManager.LoadScene("LevelSelect");
    }
	void Update () {
	
	}
}
