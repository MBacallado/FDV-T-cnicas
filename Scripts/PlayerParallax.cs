using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParallax : MonoBehaviour
{
    private Rigidbody2D body;
    private float speed = 5f;

    public delegate void ParallaxUpdated();
    public static event ParallaxUpdated onParallaxUpdated;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        float h = Input.GetAxis("Horizontal");

        this.body.velocity += new Vector2(h, 0f) * speed * Time.fixedDeltaTime;
        this.ActivateParallax();
    }

    private void ActivateParallax()
    {
        if(onParallaxUpdated != null)
        {
            onParallaxUpdated();
        }
    }
}
