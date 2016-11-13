using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Linq;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using GooglePlayGames.BasicApi.Multiplayer;



public class NetworkManager : MonoBehaviour, RealTimeMultiplayerListener
{
    public GameObject JogarOff;
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
                JogarOff.SetActive(false);

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
            SceneManager.LoadScene("Fase1A");


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
        switch(msg)
        {
            #region Player Selection
            case "escolheuPlayer1":
                GameObject.Find("Main Camera").GetComponent<InteractionPlayers>().sobrouDois();
                break;
            case "escolheuPlayer2":
                GameObject.Find("Main Camera").GetComponent<InteractionPlayers>().sobrouUm();
                break;
            case "resetSelectPlayer":
                GameObject.Find("Main Camera").GetComponent<InteractionPlayers>().noPlayAll();
                break;
            case "okSelectPlayer":
                GameObject.Find("Main Camera").GetComponent<InteractionPlayers>().yesPlayAll();
                break;
            #endregion
            #region Level Selection
            case "resetSelectLevel":
                GameObject.Find("Main Camera").GetComponent<InteractionLevels>().resetSelectionAll();
                break;
            case "nextSelectLevel":
                GameObject.Find("Main Camera").GetComponent<InteractionLevels>()._nextAll();
                break;
            case "prevSelectLevel":
                GameObject.Find("Main Camera").GetComponent<InteractionLevels>()._prevAll();
                break;
            case "okSelectLevel":
                GameObject.Find("Main Camera").GetComponent<InteractionLevels>().YesAll();
                break;
            #endregion
            #region Emojis
            case "happyEmoji":
                GameObject.Find("xTella").GetComponent<EmojisController>().RecebeHappy();
                break;
            case "s2Emoji":
                GameObject.Find("xTella").GetComponent<EmojisController>().Recebes2();
                break;
            case "amazedEmoji":
                GameObject.Find("xTella").GetComponent<EmojisController>().RecebeAmazed();
                break;
            #endregion
        }
    }
    public void SendMessageToAll(bool reliable, byte[] _msg)
    {
        PlayGamesPlatform.Instance.RealTime.SendMessageToAll(reliable, _msg);
    }
}
