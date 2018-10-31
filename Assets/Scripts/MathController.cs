using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MathController : MonoBehaviour {
    private List<Number> leftNumber;
    private List<Number> rightNumber;

    private int nowResult;
    private Tweener tn;

    public static MathController Instance;

    public void Awake()
    {
        Instance = this;
    }
    // Use this for initialization
    void Start () {
        leftNumber = new List<Number>();
        rightNumber = new List<Number>();
    }
	
	// Update is called once per frame
	void Update () {
		if(MathLeftlessRight() == 0 && nowResult != 0)
        {
            nowResult = 0;
            if (tn != null) tn.Kill();
            Vector3 rot = new Vector3(0, 0, 0);
            tn=transform.DORotate(rot, 1.5f);
        }
        else if(MathLeftlessRight() == -1 && nowResult != -1)
        {
            nowResult = -1;
            if (tn != null) tn.Kill();
            Vector3 rot = new Vector3(0, 0, 14);
            tn=transform.DORotate(rot, 1.5f);
        }
        else if (MathLeftlessRight() == 1 && nowResult != 1)
        {
            nowResult = 1;
            if (tn != null) tn.Kill();
            Vector3 rot = new Vector3(0, 0, -14);
            tn=transform.DORotate(rot, 1.5f);
        }
    }

    private int MathLeftlessRight()
    {
        int left = 0, right = 0;
        for (int i = 0; i < leftNumber.Count; i++)
        {
            left += leftNumber[i].number;
        }
        for (int i = 0; i < rightNumber.Count; i++)
        {
            right += rightNumber[i].number;
        }
        if (left > right)
            return -1;
        else if (left < right)
            return 1;
        else return 0;
    }

    public void AddToLeft(Number i)
    {
        leftNumber.Add(i);
    }

    public void AddToRight(Number i)
    {
        rightNumber.Add(i);
    }

    public void ResetNumber()
    {
        for (int i = leftNumber.Count - 1; i >= 0; i--)
        {
            Destroy(leftNumber[i].gameObject);
        }
        for (int i = rightNumber.Count -1; i >= 0; i--)
        {
            Destroy(rightNumber[i].gameObject);
        }
        leftNumber.Clear();
        rightNumber.Clear();
    }
}
