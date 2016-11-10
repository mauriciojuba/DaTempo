using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class levelSelect : MonoBehaviour {

    public GameObject areYouSurePanel;
    public Text _selectedLevelText;

    void Start()
    {
        areYouSurePanel.SetActive(false);
    }

	public void click(string obj)
    {
        switch (obj)
        {
            case "lvl1":
                levelOneSelected();
                break;
            case "lvl2":
                levelTwoSelected();
                break;
        }
    }
    void levelOneSelected()
    {
        _selectedLevelText.text = "Fase 1";
        areYouSurePanel.SetActive(true);
    }
    void levelTwoSelected()
    {
        _selectedLevelText.text = "Fase 2";
        areYouSurePanel.SetActive(true);
    }
    public void yes_lvl()
    {
        if(_selectedLevelText.text == "Fase 1")
        {
            SceneManager.LoadScene("puzzle1");
        }
        if (_selectedLevelText.text == "Fase 2")
        {
            SceneManager.LoadScene("puzzle2");
        }
    }
    public void no_lvl()
    {
        _selectedLevelText.text = "";
        areYouSurePanel.SetActive(false);
    }
}
