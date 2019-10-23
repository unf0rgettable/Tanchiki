using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTanks : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private int amount = 0;
    [SerializeField]
    private bool populateOnStart = true;
    [SerializeField]
    private bool growOverAmount = true;

    private bool spawn = true;

    private List<GameObject> pool = new List<GameObject>();

    void Start()
    {
        if (populateOnStart && prefab != null && amount > 0)
        {
            for (int i = 0; i < amount; i++)
            {
                var instance = Instantiate(prefab);
                instance.SetActive(false);
                pool.Add(instance);
            }
        }
    }

    public GameObject Instantiate(Vector3 position, Quaternion rotation)
    {
        foreach (var item in pool)
        {
            if (!item.activeInHierarchy)
            {
                item.transform.position = new Vector3(Random.Range(-20.0f, 20.0f), 0, Random.Range(-20.0f, 20.0f));
                item.transform.rotation = rotation;
                item.SetActive(true);
                return item;
            }
        }

        if (growOverAmount)
        {
            var instance = (GameObject)Instantiate(prefab, position, rotation);
            pool.Add(instance);
            return instance;
        }

        return null;
    }

    private IEnumerator SpawnTank()
    {
        spawn = false;
        Instantiate(new Vector3(Random.Range(-20.0f, 20.0f), 0, Random.Range(-20.0f, 20.0f)), Quaternion.identity);
        yield return new WaitForSeconds(1f);
        spawn = true;
    }

    private void Update()
    {
        if (spawn)
            StartCoroutine(SpawnTank());
    }
}
