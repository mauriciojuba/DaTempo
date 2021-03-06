﻿using UnityEngine;
using GooglePlayGames;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InteractionLevels : MonoBehaviour {

    NetworkManager _net = new NetworkManager();
    public GameObject selecaoDeFase;
    public GameObject aguardando;
    public GameObject areyousure;
    public Button PrevBtn, NextBtn;
    public Image tela;
    public Sprite[] _lvlSprite;
	public AudioManager Music;
    public AudioManager Effect;
    public static int index;

    void Start () {
		
		Music.playSound ("PUZZLE 1 EGITO MENU");
        selecaoDeFase.SetActive(false);
        aguardando.SetActive(false);
        areyousure.SetActive(false);
        resetSelectionAll();
        splitScreens();
    }
    void resetSelection()
    {
        resetSelectionAll();
        byte[] message = System.Text.Encoding.UTF8.GetBytes("resetSelectLevel");
        PlayGamesPlatform.Instance.RealTime.SendMessageToAll(true, message);
    }
    public void resetSelectionAll()
    {
        index = 0;
        tela.sprite = _lvlSprite[index];
        PrevBtn.interactable = false;
        NextBtn.interactable = true;
        areyousure.SetActive(false);
    }

    public void _next()
    {
        _nextAll();
        Effect.playSound("BotaoMenu");
        byte[] message = System.Text.Encoding.UTF8.GetBytes("nextSelectLevel");
        PlayGamesPlatform.Instance.RealTime.SendMessageToAll(true, message);
    }
    public void _nextAll()
    {
        PrevBtn.interactable = true;
        NextBtn.interactable = false;
        index++;
        tela.sprite = _lvlSprite[index];
		Music.playSound ("PUZZLE 2 PASSADO MENU");
    }
    public void _prev()
    {
        _prevAll();
        Effect.playSound("BotaoMenu");
        byte[] message = System.Text.Encoding.UTF8.GetBytes("prevSelectLevel");
        PlayGamesPlatform.Instance.RealTime.SendMessageToAll(true, message);
    }
    public void _prevAll()
    {
        PrevBtn.interactable = false;
        NextBtn.interactable = true;
        index--;
        tela.sprite = _lvlSprite[index];
		Music.playSound ("PUZZLE 1 EGITO MENU");

    }
    public void showAreYouSure()
    {
        Effect.playSound("BotaoConfirmar");
        areyousure.SetActive(true);
    }
    public void Yes()
    {
        Effect.playSound("BotaoConfirmar");
        byte[] message = System.Text.Encoding.UTF8.GetBytes("okSelectLevel");
        PlayGamesPlatform.Instance.RealTime.SendMessageToAll(true, message);
        YesAll();
    }
    public void YesAll()
    {
        SceneManager.LoadScene("PlayerSelect");
        
    }
    public void No()
    {
        Effect.playSound("BotaoMenu");
        resetSelection();
    }



    void splitScreens()
    {
        if (Random.Range(0, 1) >= 0.5f)
        {
            if (PlayGamesPlatform.Instance.RealTime.GetSelf().ParticipantId == Jogadores.primeiroPlayerID)
            {
                selecaoDeFase.SetActive(true);
                aguardando.SetActive(false);
            }
            if (PlayGamesPlatform.Instance.RealTime.GetSelf().ParticipantId == Jogadores.segundoPlayerID)
            {
                selecaoDeFase.SetActive(false);
                aguardando.SetActive(true);
            }
        }
        else
        {
            if (PlayGamesPlatform.Instance.RealTime.GetSelf().ParticipantId == Jogadores.segundoPlayerID)
            {
                selecaoDeFase.SetActive(true);
                aguardando.SetActive(false);
            }
            if (PlayGamesPlatform.Instance.RealTime.GetSelf().ParticipantId == Jogadores.primeiroPlayerID)
            {
                selecaoDeFase.SetActive(false);
                aguardando.SetActive(true);
            }
        }
    }
}
