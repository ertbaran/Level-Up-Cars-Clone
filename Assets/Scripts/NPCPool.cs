using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCPool : MonoBehaviour
{
    [SerializeField] List<GameObject> carNPCList;
    Queue<GameObject> carNPCPool;

    private void Awake()
    {
        carNPCPool = new Queue<GameObject>();

        foreach (var car in carNPCList)
        {
            carNPCPool.Enqueue(car);
        }
    }

    public GameObject GetNextCar()
    {
        GameObject car = carNPCPool.Dequeue();
        car.SetActive(true);
        carNPCPool.Enqueue(car);

        return car;
    }
}
