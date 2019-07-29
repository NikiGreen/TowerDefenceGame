using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectClicks : MonoBehaviour {

	public GameObject buttons,n_cube;
	public Text playTxt, gameName;

	private bool clicked;

	void OnMouseDown(){
		if (!clicked) {
			clicked = true;
			playTxt.gameObject.SetActive (false);
			gameName.text = "0"; 
			buttons.GetComponent <ScrollObjects> ().speed = -5f;
			buttons.GetComponent <ScrollObjects> ().checkPos = -150f;
			n_cube.GetComponent <Animation> ().Play ("StartGameCube");
		}
	}

	void Start () {
		
	}
		void Update () {
		
	}
}
