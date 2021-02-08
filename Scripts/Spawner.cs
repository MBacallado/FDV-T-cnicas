using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Loop());
    }

    IEnumerator Loop()
    {
        while (true)
        {
            GameObject stone = Pool.instance.GetFromPool();
            stone.GetComponent<Rigidbody2D>().velocity += new Vector2(-3, 0f);
            Destroy(stone, 5);
            yield return new WaitForSeconds(5);
        }
    }
}
