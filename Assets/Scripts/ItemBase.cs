using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBase : MonoBehaviour
{
    // Start is called before the first frame update
    protected bool itemCollider;
    protected Transform itemTranform;
    public GameObject leftPoint;
    public GameObject rightPoint;
    protected float itemSize;
    protected GameObject interactButton;
    protected GameObject observeButton;
    protected bool interacted;
    protected bool observed;
    protected string interactedText;
    protected string observedText;
    protected string caughtItemText;
    public static bool[] activedItem;
    protected float resetTime;

    void Awake()
    {
        activedItem = new bool[30];
    }
    protected virtual void Update()
    {
       GetItem();
    }
    void GetItem()
    {
        itemCollider = Physics2D.CircleCast(leftPoint.transform.position, itemSize, rightPoint.transform.position, 0, 1<<LayerMask.NameToLayer("Player"));
    }
}
