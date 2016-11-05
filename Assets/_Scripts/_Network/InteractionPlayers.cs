using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.UI;

public class InteractionPlayers : MonoBehaviour,MPUpdateListener {
    //byte vai de 0 a 255
    byte _message = 0;

    public GameObject Visitante;
    GameObject visitante;
    void Start()
    {
        SetupMultiplayerGame();
    }

    public void UpdateReceived(int action)
    {
        switch (action)
        {
            case 0:
                break;
            case 1:
                if (visitante != null)
                {
                    Visitante.GetComponent<playerVisitante>().player2 = true;
                }
                break;
        }
        
    }
    public void doMultiplayerUpdate()
    {
        NetworkManager.Instance.SendMyUpdate(_message);
    }
    public void SetupMultiplayerGame()
    {
        
        if (Jogadores.segundoPlayerID == PlayGamesPlatform.Instance.RealTime.GetSelf().ParticipantId)
        {
            visitante = Instantiate(Visitante);
        }
    }


    public void pressedPlayerOne()
    {
        if (Jogadores.segundoPlayerID == PlayGamesPlatform.Instance.RealTime.GetSelf().ParticipantId)
        {
            GameObject.Find("Debug").GetComponent<Text>().text = "Voce é o player UM";
            _message = 1;
            doMultiplayerUpdate();
        }
    }
    

    
}
