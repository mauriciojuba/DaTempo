using UnityEngine;
using GooglePlayGames;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class InteractionPuzzleB : MonoBehaviour {
    NetworkManager _net = new NetworkManager();
    public GameObject jogadorA_Control, jogadorB_Control;
    public Capitulo2 _cap2;
    public AbrePorta _open;

	public AudioManager Music;
    public AudioManager Effect;

    void Start () {
        splitscreen();
	}

    private void splitscreen()
    {
        if (InteractionPlayers.isAntonio)
        {
            jogadorA_Control.SetActive(true);
            jogadorB_Control.SetActive(false);

			Music.playSound ("PUZZLE 2 PASSADO");

        }
        else
        {
            jogadorA_Control.SetActive(false);
            jogadorB_Control.SetActive(true);

			Music.playSound ("PUZZLE 2 FUTURO");

        }
    }
    public void _graxa()
    {
        Effect.playSound("GrachaEspirrando");
        byte[] message = System.Text.Encoding.UTF8.GetBytes("Graxa");
        PlayGamesPlatform.Instance.RealTime.SendMessageToAll(true, message);
    }
    public void espirraGraxa()
    {
        _cap2.click("Sujeira");
    }
    public void lightON()
    {
        Effect.playSound("AcendeLuz");
        byte[] message = System.Text.Encoding.UTF8.GetBytes("LightON");
        PlayGamesPlatform.Instance.RealTime.SendMessageToAll(true, message);
    }
    public void received_lightON()
    {
        _cap2.LightsON();
    }
    public void openDoor()
    {
        Effect.playSound("PortaMetal");
        byte[] message = System.Text.Encoding.UTF8.GetBytes("openDoor");
        PlayGamesPlatform.Instance.RealTime.SendMessageToAll(true, message);
    }
    public void closeDoor()
    {
        Effect.playSound("PortaMetal");
        byte[] message = System.Text.Encoding.UTF8.GetBytes("closeDoor");
        PlayGamesPlatform.Instance.RealTime.SendMessageToAll(true, message);
    }
    public void received_openDoor() {
        _open.open = true;
    }
    public void received_closeDoor()
    {
        _open.open = false;
    }
    public void nextLevel()
    {
        nextLevelAll();
        byte[] message = System.Text.Encoding.UTF8.GetBytes("closeDoor");
        PlayGamesPlatform.Instance.RealTime.SendMessageToAll(true, message);
    }
    public void nextLevelAll()
    {
        SceneManager.LoadScene("Creditos");
    }
}
