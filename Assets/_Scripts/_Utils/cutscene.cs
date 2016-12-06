using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SceneManagement;

public class cutscene : MonoBehaviour {

    NetworkManager _net = new NetworkManager();

    public void nextLevel()
    {
        nextLevelAll();
        PuloDuplo1();
    }
    public void nextLevelAll()
    {
        SceneManager.LoadScene("LevelSelect");
    }
    public void cutscene2()
    {
        cutscene2All();
        PuloDuplo2();
    }
    public void cutscene2All()
    {
        SceneManager.LoadScene("Fase2A");
    }
    public void creditos()
    {
        creditosAll();
    }
    public void creditosAll()
    {
        SceneManager.LoadScene("Creditos");
    }

    void PuloDuplo3()
    {
        byte[] message = System.Text.Encoding.UTF8.GetBytes("pularCutTres");
        PlayGamesPlatform.Instance.RealTime.SendMessageToAll(true, message);
    }
    void PuloDuplo2()
    {
        byte[] message = System.Text.Encoding.UTF8.GetBytes("pularCutDois");
        PlayGamesPlatform.Instance.RealTime.SendMessageToAll(true, message);
    }
    void PuloDuplo1()
    {
        byte[] message = System.Text.Encoding.UTF8.GetBytes("pularCutUm");
        PlayGamesPlatform.Instance.RealTime.SendMessageToAll(true, message);
    }
}
