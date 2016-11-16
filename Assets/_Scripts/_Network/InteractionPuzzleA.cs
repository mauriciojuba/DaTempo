using UnityEngine;
using GooglePlayGames;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InteractionPuzzleA : MonoBehaviour {

    public GameObject _aController, _aCanvas, _bController, _bCanvas;


	void Start () {
        splitScreens();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void splitScreens()
    {
        if (InteractionPlayers.isAntonio)
        {
            _aController.SetActive(true);
            _aCanvas.SetActive(true);
            _bCanvas.SetActive(false);
            _bController.SetActive(false);
        }
        else
        {
            _aController.SetActive(false);
            _aCanvas.SetActive(false);
            _bCanvas.SetActive(true);
            _bController.SetActive(true);
        }
    }
}
