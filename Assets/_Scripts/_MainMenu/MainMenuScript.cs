using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour {

    public GameObject mainMenu, playMenu, optionMenu,lvlSelectDarPistas, lvlSelectSolucionar;


	void Start () {
        no_mainMenu();
	}
    

    #region Ativa e desativa Paineis do Canvas
    void no_mainMenu()
    {
        mainMenu.SetActive(true);
        playMenu.SetActive(false);
        optionMenu.SetActive(false);
        lvlSelectDarPistas.SetActive(false);
        lvlSelectSolucionar.SetActive(false);
    }
    void no_playMenu()
    {
        mainMenu.SetActive(false);
        playMenu.SetActive(true);
        optionMenu.SetActive(false);
        lvlSelectDarPistas.SetActive(false);
        lvlSelectSolucionar.SetActive(false);
    }
    void no_Options()
    {
        mainMenu.SetActive(false);
        playMenu.SetActive(false);
        optionMenu.SetActive(true);
        lvlSelectDarPistas.SetActive(false);
        lvlSelectSolucionar.SetActive(false);
    }
    public void no_lvlSelectSolucao()
    {
        mainMenu.SetActive(false);
        playMenu.SetActive(false);
        optionMenu.SetActive(false);
        lvlSelectDarPistas.SetActive(true);
        lvlSelectSolucionar.SetActive(false);
    }
    void no_lvlSelectPistas()
    {
        mainMenu.SetActive(false);
        playMenu.SetActive(false);
        optionMenu.SetActive(false);
        lvlSelectDarPistas.SetActive(false);
        lvlSelectSolucionar.SetActive(true);
    }
    #endregion
    
    #region funcao dos botoes
    //função dos botões
    public void accessMainMenu()
    {
        no_mainMenu();
    }
    public void accessPlay()
    {
        no_playMenu();
    }
    public void accessOptions()
    {
        no_Options();
    }
    public void accessLvlSelectSolucao()
    {
        no_lvlSelectSolucao();
    }
    public void accessLvlSelectPistas()
    {
        no_lvlSelectPistas();
    }
    public void jogarDesafio()
    {
        SceneManager.LoadScene("1_D");
    }
    public void jogarSolucao()
    {
        SceneManager.LoadScene("1_P");
    }

    #endregion
}
