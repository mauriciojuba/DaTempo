using UnityEngine;
using GooglePlayGames;
using UnityEngine.UI;

public class EmojisController : MonoBehaviour {

    NetworkManager _net = new NetworkManager();

    public Button emojiButton;
    public GameObject emojiPanel;
    public Image emojiReceived;
    bool panelOpenned;
    public Sprite[] emoji;


    void Start () {
        panelOpenned = false;
        emojiPanel.SetActive(false);
        emojiReceived.enabled = false;
	}

    public void showHidePanel()
    {
        
        panelOpenned = !panelOpenned;
        if (panelOpenned)
        {
            emojiPanel.SetActive(true);
        }
        else
        {
            emojiPanel.SetActive(false);
        }
    }

    #region Escolha de Emojis
    public void happyEmoji()
    {
        showHidePanel();
        byte[] message = System.Text.Encoding.UTF8.GetBytes("happyEmoji");
        PlayGamesPlatform.Instance.RealTime.SendMessageToAll(true, message);
    }
    public void s2Emoji()
    {
        showHidePanel();
        byte[] message = System.Text.Encoding.UTF8.GetBytes("s2Emoji");
        PlayGamesPlatform.Instance.RealTime.SendMessageToAll(true, message);
    }
    public void amazedEmoji()
    {
        showHidePanel();
        byte[] message = System.Text.Encoding.UTF8.GetBytes("amazedEmoji");
        PlayGamesPlatform.Instance.RealTime.SendMessageToAll(true, message);
    }
    #endregion


    #region Recebe Emojis
    public void RecebeHappy()
    {
        preventOpennedPanel();
        ShowEmoji(emoji[0]);
    }
    public void Recebes2()
    {
        preventOpennedPanel();
        ShowEmoji(emoji[1]);
    }
    public void RecebeAmazed()
    {
        preventOpennedPanel();
        ShowEmoji(emoji[2]);
    }
    void preventOpennedPanel()
    {
        if (panelOpenned)
        {
            panelOpenned = false;
            emojiPanel.SetActive(false);
        }
    }
    void ShowEmoji(Sprite _emoji)
    {
        emojiReceived.sprite = _emoji;
        emojiReceived.enabled = true;
        emojiButton.GetComponent<Image>().enabled = false;
        Invoke("ResetEmojis", 2f);
    }
    void ResetEmojis()
    {
        emojiReceived.enabled = false;
        emojiButton.GetComponent<Image>().enabled = true;
    }
    #endregion
}
