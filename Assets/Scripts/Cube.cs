using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : Shape
{
    public override void ShowHit()
    {
        gameObject.GetComponent<Animation>().Play("CubeAnimation");
    }
}
