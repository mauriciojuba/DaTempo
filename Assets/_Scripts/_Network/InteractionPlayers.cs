using UnityEngine;
using GooglePlayGames;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InteractionPlayers : MonoBehaviour {

    NetworkManager _net = new NetworkManager();

    public GameObject controlPlayerSelection;
    public GameObject waitingSelection;
    public GameObject areyousure;
    public Button showPlay;
    public SpriteRenderer AntonioAvatar, DouglasAvatar;
    public Sprite _sAntonio, _sDouglas;
    Sprite _antonio, _douglas;
    public static bool isAntonio, isDouglas;



    
    
    
    void Start()
    {
        controlPlayerSelection.SetActive(false);
        waitingSelection.SetActive(false);
        areyousure.SetActive(false);
        _antonio = AntonioAvatar.sprite;
        _douglas = DouglasAvatar.sprite;
        showPlay.interactable = false;
        isAntonio = false;
        isDouglas = false;
        splitScreens();

        
    }

    public void escolheUm()
    {
        DouglasAvatar.sprite = _douglas;
        isDouglas = false;
        isAntonio = true;
        AntonioAvatar.sprite = _sAntonio;
        showPlay.interactable = true;
        byte[] message = System.Text.Encoding.UTF8.GetBytes("escolheuPlayer1");
        PlayGamesPlatform.Instance.RealTime.SendMessageToAll(true, message);
    }
    public void sobrouDois()
    {
        AntonioAvatar.sprite = _antonio;
        DouglasAvatar.sprite = _sDouglas;
        isDouglas = true;
        isAntonio = false;
    }
    public void escolheDois()
    {
        DouglasAvatar.sprite = _sDouglas;
        AntonioAvatar.sprite = _antonio;
        isDouglas = true;
        isAntonio = false;
        showPlay.interactable = true;
        byte[] message = System.Text.Encoding.UTF8.GetBytes("escolheuPlayer2");
        PlayGamesPlatform.Instance.RealTime.SendMessageToAll(true, message);
    }
    public void sobrouUm()
    {
        AntonioAvatar.sprite = _sAntonio;
        DouglasAvatar.sprite = _douglas;
        isAntonio = true;
        isDouglas = false;
    }
    public void showPlayMenu()
    {
        areyousure.SetActive(true);
    }
    public void noPlay()
    {
        areyousure.SetActive(false);
        showPlay.interactable = false;
        AntonioAvatar.sprite = _antonio;
        DouglasAvatar.sprite = _douglas;
        isAntonio = false;
        isDouglas = false;
        byte[] message = System.Text.Encoding.UTF8.GetBytes("resetSelectPlayer");
        PlayGamesPlatform.Instance.RealTime.SendMessageToAll(true, message);
    }
    public void noPlayAll()
    {
        areyousure.SetActive(false);
        showPlay.interactable = false;
        AntonioAvatar.sprite = _antonio;
        DouglasAvatar.sprite = _douglas;
        isAntonio = false;
        isDouglas = false;
    }
    public void yesPlay()
    {
        SceneManager.LoadScene("Fase1A");
        byte[] message = System.Text.Encoding.UTF8.GetBytes("okSelectPlayer");
        PlayGamesPlatform.Instance.RealTime.SendMessageToAll(true, message);

        
    }
    public void yesPlayAll()
    {
        SceneManager.LoadScene("Fase1A");


    }

    void splitScreens()
    {
        if (Random.Range(0, 1) >= 0.5f)
        {
            if (PlayGamesPlatform.Instance.RealTime.GetSelf().ParticipantId == Jogadores.primeiroPlayerID)
            {
                controlPlayerSelection.SetActive(true);
                waitingSelection.SetActive(false);
            }
            if (PlayGamesPlatform.Instance.RealTime.GetSelf().ParticipantId == Jogadores.segundoPlayerID)
            {
                controlPlayerSelection.SetActive(false);
                waitingSelection.SetActive(true);
            }
        }
        else
        {
            if (PlayGamesPlatform.Instance.RealTime.GetSelf().ParticipantId == Jogadores.segundoPlayerID)
            {
                controlPlayerSelection.SetActive(true);
                waitingSelection.SetActive(false);
            }
            if (PlayGamesPlatform.Instance.RealTime.GetSelf().ParticipantId == Jogadores.primeiroPlayerID)
            {
                controlPlayerSelection.SetActive(false);
                waitingSelection.SetActive(true);
            }
        }
    }



    
}
