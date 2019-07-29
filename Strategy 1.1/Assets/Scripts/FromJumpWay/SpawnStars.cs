using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStars : MonoBehaviour {

		public GameObject star;//переменая для нашего готового префаба



		void Start () {
			StartCoroutine (spawn());//функция для вызова генерации звёзд 
		}

		IEnumerator spawn (){//функция генерации звёзд
			while (true){//бесконечный циклдля генерации
				Vector3 pos
				= Camera.main.ScreenToWorldPoint (new Vector3 (Random.Range (0, Screen.width), Random.Range (0, Screen.height), Camera.main.farClipPlane / 2));//создаём переменную котороймы задаём возможные координаты появление новой звезды ,позиции берутся внутри диапазона камеры,значения по x и y задаются от 0 до величины экрана,позиция z задаётся глубиной видимости поделенной на 2
				//Instantiate (star, pos, Quaternion.identity);//создаём сам обьект котому мы даём наш префаб,позицию ,а также отказ от вращения
			Instantiate (star, pos, Quaternion.Euler(0,0,Random.Range(0F,360F)));//создание объекта в рандомной позиции
			yield return new WaitForSeconds (5.01f);//задаём таймер создания звёздочек
			}
		}

	}