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
    public GameObject ampulheta;
    public Button JogarBtn;
    static NetworkManager sInstance = null;

    public AudioManager Effect;


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
        JogarBtn.GetComponent<Button>().interactable = false;
        initializeLogTexts();
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.Activate();
        Login();
        ampulheta.SetActive(false);
    }
    public void Login()
    {
        Social.localUser.Authenticate((bool sucess) => {
            if (sucess)
            {
                GameObject.Find("LoginText").GetComponent<Text>().text = PlayGamesPlatform.Instance.localUser.userName;
                JogarBtn.GetComponent<Button>().interactable = true;

            }
            else
            {
                GameObject.Find("LoginText").GetComponent<Text>().text = "LOGIN ERROR";
            }
        });
    }
    public void CreateQuickGame()
    {
        //Effect.playSound("BotaoMenu");
        //Effect.playSound("AguardandoJogador");
        sInstance = new NetworkManager();
        PlayGamesPlatform.Instance.RealTime.CreateQuickGame(1, 1, 0, sInstance);
        ampulheta.SetActive(true);

    }
    public void OnRoomSetupProgress(float percent)
    {
        //Effect.playSound("AguardandoJogador");
        if (percent == 20)
        {
        }
        else
        {
        }                               
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
            if (GameObject.Find("AguardandoJogador") != null)
            {
                Destroy(GameObject.Find("AguardandoJogador"));
            }
            //Effect.playSound("EntrouJogador");
            
            jogadores = participantes();
            Jogadores.primeiroPlayerID = participantes().First().ParticipantId;
            Jogadores.segundoPlayerID = participantes().Last().ParticipantId;
            Jogadores.primeiroPlayerName = participantes().First().DisplayName;
            Jogadores.segundoPlayerName = participantes().Last().DisplayName;

            SceneManager.LoadScene("CutsceneUM");

        }
        else
        {
            ampulheta.SetActive(false);
            PlayGamesPlatform.Instance.RealTime.LeaveRoom();
        }
    }

    private void CUTSCENE()
    {
        
    }

    public void OnParticipantLeft(Participant participant)
    {
    }
    public void OnPeersConnected(string[] participantIds)
    {
        foreach (string participantID in participantIds)
        {
        }
    }
    public void OnPeersDisconnected(string[] participantIds)
    {
        foreach (string participantID in participantIds)
        {
        }
    }
    public void OnLeftRoom()
    {
        SceneManager.LoadScene("MainMenu");
    }
    void initializeLogTexts()
    {
        GameObject.Find("LoginText").GetComponent<Text>().text = "";
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
            #region PuzzleA
            case "startPuzzleB":
                GameObject.Find("Main Camera").GetComponent<InteractionPuzzleA>().StartPuzzle2All();
                break;
            case "nextStageA":
                GameObject.Find("Main Camera").GetComponent<InteractionPuzzleA>().nextStageAll();
                break;
            case "levelStage":
                GameObject.Find("Main Camera").GetComponent<InteractionPuzzleA>().levelStageAll();
                break;
            case "ligaVapor":
                GameObject.Find("Jogador B Pipe").GetComponent<canoVapor>().soltaVapor();
                break;
            case "diminuiVida":
                GameObject.Find("Main Camera").GetComponent<InteractionPuzzleA>().VidaMenos();
                break;
            #endregion
            #region PuzzleB
            case "Graxa":
                GameObject.Find("Main Camera").GetComponent<InteractionPuzzleB>().espirraGraxa();
                break;
            case "LightON":
                GameObject.Find("Main Camera").GetComponent<InteractionPuzzleB>().received_lightON();
                break;
            case "openDoor":
                GameObject.Find("Main Camera").GetComponent<InteractionPuzzleB>().received_openDoor();
                break;
            case "closeDoor":
                GameObject.Find("Main Camera").GetComponent<InteractionPuzzleB>().received_closeDoor();
                break;
            case "tiraVida2":
                GameObject.Find("Main Camera").GetComponent<InteractionPuzzleB>().diminuiVida();
                break;
            #endregion
            #region cutscenes
            case "pularCutUm":
                GameObject.Find("Cutscene").GetComponent<cutscene>().nextLevelAll();
                break;
            case "pularCutDois":
                GameObject.Find("Cutscene").GetComponent<cutscene>().cutscene2All();
                break;
            case "pularCutTres":
                GameObject.Find("Cutscene").GetComponent<cutscene>().creditosAll();
                break;

                #endregion
        }
    }
    public void SendMessageToAll(bool reliable, byte[] _msg)
    {
        PlayGamesPlatform.Instance.RealTime.SendMessageToAll(reliable, _msg);
    }

    public void Creditos() {
        
        Effect.playSound("BotaoMenu");
        SceneManager.LoadScene("Creditos");

    }
}
