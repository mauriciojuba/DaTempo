using UnityEngine;
using System.Collections;

public class AbrePorta : MonoBehaviour {
    
    public Transform openPos;
    public bool open;
    public float speed;

    Vector2 posClosed, posOpenned;
    Vector2 _pos;
	
    void Start()
    {
        posClosed = new Vector2(transform.position.x, transform.position.y);
        posOpenned = new Vector2(openPos.position.x, openPos.position.y);
    }
	void Update () {
        if (open) {
            _pos = Vector2.MoveTowards(_pos,posOpenned, speed*Time.deltaTime);
        }
        else
        {
            _pos = Vector2.MoveTowards(_pos, posClosed, speed * Time.deltaTime);
        }
        transform.position = new Vector3(_pos.x, _pos.y);
    }
}
