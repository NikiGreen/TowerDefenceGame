using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFade : MonoBehaviour {

	private Text txt;//Перменная для текста
	private Outline Oline;//

	void Start () {
		txt = GetComponent <Text> ();//Берём текст из надписи на главном меню
		Oline = GetComponent <Outline> ();//
	}
	

	void Update () {
		txt.color = 
			new Color (txt.color.r,txt.color.g,txt.color.b,Mathf.PingPong(Time.time,1.0f));
		
		Oline.effectColor = 
			new Color (Oline.effectColor.r,Oline.effectColor.g,Oline.effectColor.b,txt.color.a);

	}
}
