using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Jump();
        }
    }

    void Jump()
    {
        StartCoroutine(Jumping());
    }

    IEnumerator Jumping()
    {
        float count = 0;
        while (count <= 1.0f)
        {
            count += Time.deltaTime;
            Vector2 newPosition = new Vector2(transform.position.x, transform.position.y + 1f);
            transform.position = Vector2.Lerp(transform.position, newPosition, 1 * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, transform.position.y, -5);
            yield return null;
        }

        count = 0;
        while (count <= 1.0f)
        {
            count += Time.deltaTime;
            Vector2 newPosition = new Vector2(transform.position.x, transform.position.y - 1f);
            transform.position = Vector2.Lerp(transform.position, newPosition, 1 * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, transform.position.y, -5);
            yield return null;
        }
        yield return null;
    }
}
