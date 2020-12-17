using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : Shape
{
    public override void ShowHit()
    {
        gameObject.GetComponent<Renderer>().material.color =
            new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f), 1f);
    }
}
