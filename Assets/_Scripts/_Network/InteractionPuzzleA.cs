using UnityEngine;
using GooglePlayGames;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InteractionPuzzleA : MonoBehaviour {

    NetworkManager _net = new NetworkManager();
    public GameObject _aController, _aCanvas, _bController, _bCanvas;
    public GameObject _a2Controller, _b2Controller, _b2Canvas;
    public GameObject _pipe;
	public AudioManager Music;
    public AudioManager Effect;

    public TutorialFase1 Tutorial1;


    void Start () {
        splitScreens();

	}
	
	// Update is called once per frame
	public void nextStage()
    {
        byte[] message = System.Text.Encoding.UTF8.GetBytes("nextStageA");
        PlayGamesPlatform.Instance.RealTime.SendMessageToAll(true, message);
        nextStageAll();
    }
    public void nextStageAll()
    {
        SceneManager.LoadScene("CutsceneDOIS");
    }
    public void diminuiVida()
    {
        byte[] message = System.Text.Encoding.UTF8.GetBytes("levelStage");
        PlayGamesPlatform.Instance.RealTime.SendMessageToAll(true, message);
    }
    public void VidaMenos()
    {
        _pipe.GetComponent<canoVapor>().diminuiVida();
    }
    public void levelStage()
    {
        byte[] message = System.Text.Encoding.UTF8.GetBytes("levelStage");
        PlayGamesPlatform.Instance.RealTime.SendMessageToAll(true, message);
        levelStageAll();
    }
    public void levelStageAll()
    {
        SceneManager.LoadScene("LevelStage");
    }
    public void vapor()
    {
        byte[] message = System.Text.Encoding.UTF8.GetBytes("ligaVapor");
        PlayGamesPlatform.Instance.RealTime.SendMessageToAll(true, message);
    }
    void splitScreens()
    {
        if (InteractionPlayers.isAntonio)
        {
            _aController.SetActive(true);
            _aCanvas.SetActive(true);
            _bCanvas.SetActive(false);
            _bController.SetActive(false);

            _a2Controller.SetActive(false);
            _b2Canvas.SetActive(false);
            _b2Controller.SetActive(false);
            _pipe.SetActive(false);

			Music.playSound ("PUZZLE 1 EGITO");

        }
        else
        {
            _aController.SetActive(false);
            _aCanvas.SetActive(false);
            _bCanvas.SetActive(true);
            _bController.SetActive(true);

            _a2Controller.SetActive(false);
            _b2Canvas.SetActive(true);
            _b2Controller.SetActive(false);
            _pipe.SetActive(true);

			Music.playSound ("PUZZLE 1 LAB");

        }
    }
    public void StartPuzzle2()
    {
        StartPuzzle2All();
        byte[] message = System.Text.Encoding.UTF8.GetBytes("startPuzzleB");
        PlayGamesPlatform.Instance.RealTime.SendMessageToAll(true, message);
    }
    public void StartPuzzle2All()
    {
        tapTabuleiro.puzzleAtivo = 1;
        if (InteractionPlayers.isAntonio)
        {
            _aController.SetActive(false);
            _aCanvas.SetActive(true);
            _bCanvas.SetActive(false);
            _bController.SetActive(false);

            _a2Controller.SetActive(true);
            _b2Canvas.SetActive(false);
            _b2Controller.SetActive(false);
        }
        else
        {
            Effect.playSound("VirarPagina");

            _aController.SetActive(false);
            _aCanvas.SetActive(false);
            _bCanvas.SetActive(false);
            _bController.SetActive(false);

            _a2Controller.SetActive(false);
            _b2Canvas.SetActive(true);
            _b2Controller.SetActive(true);
        }
    }
}
