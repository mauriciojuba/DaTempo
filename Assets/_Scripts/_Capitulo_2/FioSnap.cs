using UnityEngine;
using System.Collections;
using TouchScript.Gestures;

public class FioSnap : MonoBehaviour
{

    private TransformGesture Tc;
    public GameObject SelectVisualizer;
    Vector3 PosInicial;
    public bool Select = false;
    GameManager Controller;
    public int atrelado;


    // Use this for initialization
    void Start()
    {
        Controller = GameObject.Find("GameControl").GetComponent<GameManager>();
        PosInicial = gameObject.transform.position;
        atrelado = 0;
        Tc = gameObject.GetComponent<TransformGesture>();
    }
    public void ResetPos()
    {
        gameObject.transform.position = PosInicial;
        atrelado = 0;
    }

    void Update()
    {

        if (Select)
            SelectVisualizer.SetActive(true);
        else
            SelectVisualizer.SetActive(false);

        if(atrelado == 1) Controller.a = true;
        else if (atrelado == 2) Controller.b = true;
        else if (atrelado == 3) Controller.c = true;

        Debug.Log(gameObject.name + "  " + atrelado);
    }
    public void desatrelar()
    {
        if (atrelado == 1)
        {
            Controller.a = false;
            ResetPos();
        }
        else if (atrelado == 2)
        {
            Controller.b = false;
            ResetPos();
        }
        else if (atrelado == 3)
        {
            Controller.c = false;
            ResetPos();
        }
        atrelado = 0;
    }

    void OnTriggerEnter2D(Collider2D hit)
    {

        if (hit.gameObject.name == "nope")
        {
            gameObject.transform.position = PosInicial;
            Tc.Cancel();
        }
        if (hit.gameObject.tag == "snap")
        {
            Tc.Cancel();
            if (hit.gameObject.name == "A")
            {
                if (Controller.a == false)
                {
                    gameObject.transform.position = hit.gameObject.transform.position;
                    desatrelar();
                    atrelado = 1;
                    Controller.Add(hit.gameObject.name);
                }
                else ResetPos();
            }
            if (hit.gameObject.name == "B")
            {
                if (Controller.b == false)
                {
                    gameObject.transform.position = hit.gameObject.transform.position;
                    desatrelar();
                    atrelado = 2;
                    Controller.Add(hit.gameObject.name);
                }
                else ResetPos();
            }
            if (hit.gameObject.name == "C")
            {
                if (Controller.c == false)
                {
                    gameObject.transform.position = hit.gameObject.transform.position;
                    desatrelar();
                    atrelado = 3;
                    Controller.Add(hit.gameObject.name);
                }
                else ResetPos();
            }
        }

    }

}
