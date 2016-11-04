using UnityEngine;
using System.Collections;
using GooglePlayGames;

public class playerSelection : MonoBehaviour {
    public NetworkManager _net;

    void Start()
    {
        _net = NetworkManager.Instance;
    }

    public void pressedOne()
    {
        byte[] message = System.Text.Encoding.UTF8.GetBytes("player1selected");
        PlayGamesPlatform.Instance.RealTime.SendMessage(true, PlayGamesPlatform.Instance.localUser.id, message);
    }
    public void pressedTwo()
    {
        byte[] message = System.Text.Encoding.UTF8.GetBytes("player2selected");
        PlayGamesPlatform.Instance.RealTime.SendMessage(true, PlayGamesPlatform.Instance.localUser.id, message);
    }

}
