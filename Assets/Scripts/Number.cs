using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Number : MonoBehaviour {
    private bool isDragEnd = false;
    
    private int enterCount;

    [HideInInspector]
    public bool isLeft;

    [HideInInspector]
    public int number;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(!isDragEnd)
        {
            transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
        }
	}

    public void DragEnd()
    {
        isDragEnd = true;
        if (enterCount <= 0)
            Destroy(gameObject);
        else
        {
            if (isLeft)
                MathController.Instance.AddToLeft(this);
            else
                MathController.Instance.AddToRight(this);
            StartCoroutine("StayNumber");
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Number")
        {
            if(collision.gameObject.name == "left")
            {
                isLeft = true;
            }
            if (collision.gameObject.name == "right")
            {
                isLeft = false;
            }
            enterCount++;
        }
    }

    IEnumerator StayNumber()
    {
        yield return new WaitForSeconds(1f);
        GetComponent<Rigidbody>().isKinematic = true;
        transform.parent = MathController.Instance.transform;
    }

    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Number")
        {
            enterCount--;
        }
    }

}
