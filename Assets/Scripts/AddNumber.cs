using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddNumber : MonoBehaviour {

    private GameObject currentNumber; //当前拖拽的数字实例

    public GameObject greenPlane; // 可放置托盘
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnDragNumber(int i)
    {
        greenPlane.SetActive(true);
        currentNumber = (GameObject)Instantiate(Resources.Load("Number"));
        currentNumber.GetComponentInChildren<TextMesh>().text = i.ToString();
        currentNumber.GetComponent<Number>().number = i;
    }
    

    public void OnDragEnd()
    {
        greenPlane.SetActive(false);
        currentNumber.GetComponent<Number>().DragEnd();
    }
}
