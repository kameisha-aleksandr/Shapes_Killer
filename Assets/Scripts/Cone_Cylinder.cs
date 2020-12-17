using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cone_Cylinder : Shape
{
    public GameObject cone, cylinder;
    public void Awake()
    {
        cone = transform.Find("Cone").gameObject;
        cylinder = transform.Find("Cylinder").gameObject;
        cylinder.SetActive(false);
    }

    public override void ShowHit()
    {
        if(cone.activeSelf)
        {
            cone.SetActive(false);
            cylinder.SetActive(true);
        }
        else
        {
            cone.SetActive(true);
            cylinder.SetActive(false);
        }
    }
}
