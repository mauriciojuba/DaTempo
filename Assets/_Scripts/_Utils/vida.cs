using UnityEngine;
using System.Collections;

public class vida : MonoBehaviour {

    public GameObject vida1, vida2, vida3;
    public int lifeCount;

    void Start()
    {
        lifeCount = 3;
        vida1.SetActive(true);
        vida2.SetActive(true);
        vida3.SetActive(true);
    }

    public void tirarVida()
    {
        lifeCount--;
        if (lifeCount == 2) vida3.SetActive(false);
        if (lifeCount == 1) vida2.SetActive(false);
        if (lifeCount == 0) vida1.SetActive(false);
        if (lifeCount == -1) lifeCount = 3;
    }
}
