using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using GooglePlayGames.BasicApi.Multiplayer;



public class NetworkManager : MonoBehaviour, RealTimeMultiplayerListener
{
    public Button Jogar;
    static NetworkManager sInstance = null;

   
    public static NetworkManager Instance
    {
        get
        {
            if (sInstance == null)
            {
                sInstance = new NetworkManager();
            }
            return sInstance;
        }
    }
    void Start()
    {
        Jogar.GetComponent<Button>().interactable = false;
        initializeLogTexts();
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.Activate();
        Login();
    }
    public void Login()
    {
        Social.localUser.Authenticate((bool sucess) => {
            if (sucess)
            {
                GameObject.Find("LoginText").GetComponent<Text>().text = PlayGamesPlatform.Instance.localUser.userName;
                Jogar.GetComponent<Button>().interactable = true;

            }
            else
            {
                GameObject.Find("LoginText").GetComponent<Text>().text = "LOGIN ERROR";
            }
        });
    }
    public void CreateQuickGame()
    {
        sInstance = new NetworkManager();
        PlayGamesPlatform.Instance.RealTime.CreateQuickGame(1, 1, 0, sInstance);
    }
    public void OnRoomSetupProgress(float percent)
    {
        if(percent == 20)
        {
            GameObject.Find("CriandoSalaText").GetComponent<Text>().text = "Aguardando alguém para jogar.";
        }                                
        GameObject.Find("ConnectingText").GetComponent<Text>().text = "Setting up room (" + ((int)percent) + "%)";
    }

    private List<Participant> jogadores;

    private Participant GetSelf()
    {
        return PlayGamesPlatform.Instance.RealTime.GetSelf();
    }
    public Participant playerOne()
    {
        return PlayGamesPlatform.Instance.RealTime.GetSelf();
    }
    public List<Participant> participantes()
    {
        return PlayGamesPlatform.Instance.RealTime.GetConnectedParticipants();
    }
    public Participant playerTwo()
    {
        List<Participant> players = PlayGamesPlatform.Instance.RealTime.GetConnectedParticipants();
        players.Remove(PlayGamesPlatform.Instance.RealTime.GetSelf());
        Participant playerTwo = players[0];
        return playerTwo;
    }
    public void OnRoomConnected(bool success)
    {
        if (success)
        {

            GameObject.Find("ConnectingText").GetComponent<Text>().text = "Sala Criada";
            GameObject.Find("CriandoSalaText").GetComponent<Text>().text = "Vamos Jogar!!";
            jogadores = participantes();
            Jogadores.primeiroPlayerID = participantes().First().ParticipantId;
            Jogadores.segundoPlayerID = participantes().Last().ParticipantId;
            Jogadores.primeiroPlayerName = participantes().First().DisplayName;
            Jogadores.segundoPlayerName = participantes().Last().DisplayName;
            SceneManager.LoadScene("LevelSelect");


        }
        else
        {
            GameObject.Find("ConnectingText").GetComponent<Text>().text = "Falha ao criar a sala";
            GameObject.Find("CriandoSalaText").GetComponent<Text>().text = "Falhou, Tente de Novo.";
            PlayGamesPlatform.Instance.RealTime.LeaveRoom();
        }
    }

    public void OnParticipantLeft(Participant participant)
    {
        GameObject.Find("LogText").GetComponent<Text>().text = participant.DisplayName + " ----Left the room";
    }
    public void OnPeersConnected(string[] participantIds)
    {
        foreach (string participantID in participantIds)
        {
            GameObject.Find("LogText").GetComponent<Text>().text = participantID + " ----Connected the room";
        }
    }
    public void OnPeersDisconnected(string[] participantIds)
    {
        foreach (string participantID in participantIds)
        {
            GameObject.Find("LogText").GetComponent<Text>().text = participantID + " ----Disconected from the room";
        }
    }
    public void OnLeftRoom()
    {
        SceneManager.LoadScene("MainMenu");
    }
    void initializeLogTexts()
    {
        GameObject.Find("LoginText").GetComponent<Text>().text = "";
        GameObject.Find("LogText").GetComponent<Text>().text = "";
        GameObject.Find("ConnectingText").GetComponent<Text>().text = "";
        GameObject.Find("CriandoSalaText").GetComponent<Text>().text = "";
    }
    private List<byte> _updateMessage;

    public void OnRealTimeMessageReceived(bool isReliable, string senderId, byte[] data)
    {
        string msg = System.Text.Encoding.Default.GetString(data);
        GameObject.Find("Debug").GetComponent<Text>().text = "" + msg;
    }
    public void SendMessageToAll(bool reliable, byte[] _msg)
    {
        PlayGamesPlatform.Instance.RealTime.SendMessageToAll(reliable, _msg);
    }
}
