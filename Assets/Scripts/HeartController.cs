using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartController : MonoBehaviour
{
    GameObject cat;

    void Start()
    {
        cat = GameObject.Find("player");
    }

    void Update()
    {
        transform.Translate(0, -0.08f, 0);
        if (transform.position.y < -5.5f)
        {
            Destroy(gameObject);
            return;
        }
        Vector2 p1 = transform.position;
        Vector2 p2 = cat.transform.position;
        float d = (p1 - p2).magnitude;
        float r1 = 0.4f;
        float r2 = 1f;
        if (d < r1 + r2)
        {
            GameObject director = GameObject.Find("GameDirector");
            director.GetComponent<GameDirector>().IncreaseHp();
            Destroy(gameObject);
        }
    }
}
