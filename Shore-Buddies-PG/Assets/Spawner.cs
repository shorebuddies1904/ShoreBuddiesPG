using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Spawner : MonoBehaviour
{
    public int numberToSpawn;
    public List<GameObject> spawnPool;
    public GameObject quad;
    Rigidbody2D rb;

    void Start()
    {
        Random.seed = 4343;
        spawnObjects();
    }

    public void spawnObjects()
    {
        destroyObjects();
        int randomItem = 0;
        GameObject toSpawn;
        MeshCollider c = quad.GetComponent<MeshCollider>();

        float screenX, screenY;
        Vector2 pos;

        for (int i = 0 ; i < numberToSpawn; i++)
        {
            randomItem = Random.Range(0, spawnPool.Count);
            toSpawn = spawnPool[randomItem];

            screenX = Random.Range(c.bounds.min.x, c.bounds.max.x);
            screenY = Random.Range(c.bounds.min.y, c.bounds.max.y);
            pos = new Vector2(screenX, screenY);

            Instantiate(toSpawn, pos, Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)));

        }
    }

        private void destroyObjects()
        {
            foreach(GameObject o in GameObject.FindGameObjectsWithTag("Spawnable"))
            {
                Destroy(o);
            }
        }
}
