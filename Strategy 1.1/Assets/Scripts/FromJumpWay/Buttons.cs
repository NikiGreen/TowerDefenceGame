using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour {

	void OnMouseDown(){
		transform.localScale = new Vector3 (0.01732327f, 0.01732327f, 0.01732327f);//Изменение размера кнопок при нажатии
	}

	void OnMouseUp(){
		transform.localScale = new Vector3 (0.01572327f, 0.01572327f, 0.01572327f);//Возвращение кнопок в первоначальное состояние
	}
}
