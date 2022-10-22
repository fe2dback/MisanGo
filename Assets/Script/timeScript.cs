using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using Random = UnityEngine.Random;
public class timeScript : MonoBehaviour {

	public Text counterText;
	public bool timeCounter = true;
	public float seconds, minutes;
	public float begin;

	// Use this for initialization
	void Start()
	{
		counterText = GetComponent<Text>() as Text;
		begin = Random.Range(3f, 6f);
	}
	// Update is called once per frame
	void Update () {

		time();
        if (timeCounter) {
			seconds = (int)(begin);
			counterText.text = "남은시간" + " : " + begin.ToString ("00");
			
		}
	}

	public void time()
    {
		begin -= Time.deltaTime;

		if (begin < 0)
		{
			Debug.Log("end");
			timeCounter = false;
			counterText.color = Color.red;
			counterText.text = "Time Over!";
		}
	}

	public void endGame() {
		timeCounter = false;
		counterText.color = Color.green;
		Debug.Log("clear");
	}
}
