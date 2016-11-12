using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using GooglePlayGames;

public class UIController : MonoBehaviour {

    public Button _opt;
    public Text cenaAnteriorText, avisoSairText;
    public GameObject optionsPanel, areyousurePanel;
    public GameObject btnCenaAnterior;
    string currentScene;
    bool optionsOpenned = false, exiting = false;

    void Start()
    {
        currentScene = SceneManager.GetActiveScene().name;
        optionsPanel.SetActive(false);
        areyousurePanel.SetActive(false);
    }
	public void abreOptions()
    {
        optionsOpenned = !optionsOpenned;
        if (optionsOpenned)
        {
            optionsPanel.SetActive(true);
            handleTextOnScenes();
        }
        else
        {
            exiting = false;
            optionsPanel.SetActive(false);
            areyousurePanel.SetActive(false);
        }
    }
    public void toggleSoundEffects(bool isOn)
    {
        if (isOn)
        {
            //efeitos ligados
        }
        else
        {
            //efeitos desligados
        }
    }
    public void toggleMusic(bool isOn)
    {
        if (isOn)
        {
            //efeitos ligados
        }
        else
        {
            //efeitos desligados
        }
    }
    public void cenaAnterior()
    {
        areyousurePanel.SetActive(true);
        avisoSairText.text = "TEM CERTEZA QUE QUER IR PARA "+cenaAnteriorText.text+"?";
    }
    public void tryExitGame()
    {
        exiting = true;
        areyousurePanel.SetActive(true);
        avisoSairText.text = "TEM CERTEZA QUE QUER SAIR DO JOGO?";
    }
    public void Yes()
    {
        areyousurePanel.SetActive(true);
        if (exiting)
        {
            Application.Quit();
        }
        else
        {
            PlayGamesPlatform.Instance.RealTime.LeaveRoom();
        }
    }
    public void No()
    {
        areyousurePanel.SetActive(false);
        exiting = false;
    }
    void handleTextOnScenes()
    {
        if(currentScene == "MainMenu")
        {
            btnCenaAnterior.SetActive(false);
        }
        else
        {
            cenaAnteriorText.text = "MENU INICIAL";

        }
    }
}
