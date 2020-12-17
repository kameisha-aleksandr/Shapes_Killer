using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunPosition : MonoBehaviour
{
    public GameObject gunPrefub;
    public int gunCount = 5;
    public float platformLength = 24;
    public Slider gunSlider;

    void Start()
    {
        Vector3 pos;
        Quaternion q;
        Gun gun;
        float dist = platformLength / (gunCount-1);
        for (int i=0;i<gunCount;i=i+2)
        {
            pos = new Vector3(5f, 1f, -13 + i * dist);
             q = Quaternion.Euler(0, -90, 0);
            gun = Instantiate(gunPrefub, pos, q).GetComponentInChildren<Gun>();
            gun.dir = Vector3.left;
            gunSlider.onValueChanged.AddListener(gun.SliderChanged);
        }
        for (int i = 1; i < gunCount; i = i + 2)
        {
            pos = new Vector3(-5f, 1f, -13 + i * dist);
            q = Quaternion.Euler(0, 90, 0);
            gun = Instantiate(gunPrefub, pos, q).GetComponentInChildren<Gun>();   
            gun.dir = Vector3.right;
            gunSlider.onValueChanged.AddListener(gun.SliderChanged);
        }
    }

}
