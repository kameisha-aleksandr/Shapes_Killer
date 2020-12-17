using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject spawnShape;
    public float frequency = 1;
    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (Application.isPlaying)
        {
            SpawnShape();
            yield return new WaitForSeconds(frequency);
        }
    }

    public void SpawnShape()
    {
        if (spawnShape != null)
        {
            GameObject go = Instantiate(spawnShape);
        }
    }
    public void SliderChanged(float value)
    {
        frequency = value;
    }
}
