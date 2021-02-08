using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float lenght, startpos;
    public GameObject mainCamera;
    public float parallaxEffect;
    public bool startEffect = true;

    public PlayerParallax player;

    private void OnEnable()
    {
        PlayerParallax.onParallaxUpdated += ParallaxEvent;
    }

    private void OnDisable()
    {
        PlayerParallax.onParallaxUpdated -= ParallaxEvent;
    }

    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position.x;
        lenght = GetComponent<MeshRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (startEffect)
        {
            mainCamera.transform.position = new Vector3(mainCamera.transform.position.x + 0.01f, 0f, -10f);


            float temp = (mainCamera.transform.position.x * (1 - parallaxEffect));
            float dist = (mainCamera.transform.position.x * parallaxEffect);

            transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);

            if (temp > startpos + lenght)
            {
                startpos += lenght;
            }
            else if (temp < startpos - lenght)
            {
                startpos -= lenght;
            }
        }
    }

    public void ParallaxEvent()
    {
        startEffect = true;
    }
}
