using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;

    [SerializeField] private GameObject objectToPool;
    [SerializeField] private int amount = 10;

    private List<GameObject> pooledObjects = new List<GameObject>();

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        for (int i = 0; i < amount; i++)
        {
            var createdObject = Instantiate(objectToPool);
            createdObject.SetActive(false);
            pooledObjects.Add(createdObject);
        }
    }

    public GameObject GetObjectFromPool()
    {
        foreach (var obj in pooledObjects)
        {
            if (!obj.activeInHierarchy)
                return obj;
        }

       return null;
    }
}
