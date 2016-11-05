using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playerVisitante : MonoBehaviour {

    public bool player2;


    void Update()
    {
        if (player2)
        {
            GameObject.Find("PlayerOne").SetActive(false);
            GameObject.Find("Debug").GetComponent<Text>().text = "Voce é o player DOIS";
        }
    }
}
