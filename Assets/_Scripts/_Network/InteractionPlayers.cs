using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class InteractionPlayers : MonoBehaviour {

    NetworkManager _net = new NetworkManager();
    public void pressedOne()
    {
        byte[] message = System.Text.Encoding.UTF8.GetBytes("player1selected");
        PlayGamesPlatform.Instance.RealTime.SendMessageToAll(true, message);
    }

}
