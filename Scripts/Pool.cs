using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    public GameObject stonePrefab;
    public Transform stoneTransform;

    private Queue<GameObject> availableObjects = new Queue<GameObject>();

    public static Pool instance { get; private set; }

    void Awake()
    {
        instance = this;
    }

    public GameObject GetFromPool()
    {
        if (availableObjects.Count == 0)
            GrowToPool();

        var instance = availableObjects.Dequeue();
        instance.SetActive(true);
        return instance;
    }

    private void GrowToPool()
    {
        for (int i = 0; i < 10; i++)
        {
            var instanceToAdd = Instantiate(stonePrefab);
            instanceToAdd.transform.SetParent(stoneTransform);
            AddToPool(instanceToAdd);
        }
    }

    public void AddToPool(GameObject instance)
    {
        instance.SetActive(false);
        availableObjects.Enqueue(instance);
    }
}
