using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanButton : MonoBehaviour {

    void OnMouseDown()
    {
        transform.localScale = new Vector3(1.1017158f, 1.1017158f, 1.1017158f);//Изменение размера кнопок при нажатии
    }

    void OnMouseUp()
    {
        transform.localScale = new Vector3(0.9999599f, 0.9999599f, 0.9999599f);//Возвращение кнопок в первоначальное состояние
    }
}
