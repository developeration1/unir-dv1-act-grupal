using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] float startingInSec = 10;
    [SerializeField] float throwRateMinSec = 3;
    [SerializeField] float throwRateMaxSec = 4;
    [SerializeField] float forceMin = 1;
    [SerializeField] float forceMax = 2;
    [SerializeField] Direction direction;
    [SerializeField] GameObject[] fruits;

    float nextOn = 0;

    void Start()
    {
        nextOn = Time.realtimeSinceStartup + startingInSec;
    }

    void Update()
    {
        if(nextOn < Time.realtimeSinceStartup)
        {
            GameObject fruit = Instantiate(fruits[Random.Range(0, fruits.Length - 1)], transform.position, Quaternion.identity);
            FruitPhysics fruitPhysics = fruit.GetComponent<FruitPhysics>();
            if (fruitPhysics)
                fruitPhysics.SetImpulse(Random.Range(forceMin, forceMax), direction);
            nextOn = Time.realtimeSinceStartup + Random.Range(throwRateMinSec, throwRateMaxSec);
        }
    }

}
