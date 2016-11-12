using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	public Image TimerImg;
	private float TimerTemp = 1f;

	public float TempoTimer = 30f;
	//private float TempoTimerO;
	public bool IsTimer = false;

	// Use this for initialization
	void Start () {
	
		//TempoTimerO = TempoTimer;

	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
		if (Input.GetKeyDown (KeyCode.A))
			AtivaTimer ();

		if (IsTimer)
			TimerAtivado ();

		if (TimerTemp < 0)
			DesativaTimer ();

	}

	public void AtivaTimer (){

		TimerTemp = 1f;
		IsTimer = true;
		gameObject.GetComponent<Image> ().enabled = true;

	}

	public void TimerAtivado (){

		TimerTemp -= Time.deltaTime / TempoTimer;
		TimerImg.fillAmount = TimerTemp;


	}

	public void DesativaTimer(){
		
		IsTimer = false;
		gameObject.GetComponent<Image> ().enabled = false;




	}
}
