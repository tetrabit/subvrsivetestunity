using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviourSingleton<ObjectPool>
{
    public static Vector3 POOL_LOCATION = new Vector3(500f, 500f, 500f);

    private Dictionary<string, Queue<GameObject>> poolDictionary = new Dictionary<string, Queue<GameObject>>();

    public GameObject SpawnFromPool(GameObject prefab, Vector3 position, Quaternion rotation)
    {
        var key = prefab.name + "(Clone)";

        if (!poolDictionary.ContainsKey(key))
        {
            poolDictionary[key] = new Queue<GameObject>();
        }

        if (poolDictionary[key].Count > 0)
        {
            GameObject objectToSpawn = poolDictionary[key].Dequeue();
            objectToSpawn.SetActive(true);
            objectToSpawn.transform.position = position;
            objectToSpawn.transform.rotation = rotation;
            return objectToSpawn;
        }
        else
        {
            GameObject newObject = Instantiate(prefab, position, rotation);
            newObject.name = key;
            return newObject;
        }
    }


    public void ReturnToPool(GameObject obj)
    {
        string key = obj.name;

        obj.SetActive(false);

        if (!poolDictionary.ContainsKey(key))
        {
            poolDictionary[key] = new Queue<GameObject>();
        }

        poolDictionary[key].Enqueue(obj);
    }
}