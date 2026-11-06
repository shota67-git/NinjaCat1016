using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartGenerator : MonoBehaviour
{
    public GameObject heartPrefab;
    float span = 2.0f;   // 每隔 2 秒掉落一個愛心
    float delta = 0;

    void Update()
    {
        delta += Time.deltaTime;
        if (delta > span)
        {
            delta = 0;
            GameObject go = Instantiate(heartPrefab);
            float px = Random.Range(-8, 8);
            go.transform.position = new Vector3(px, 5.8f, 0);
        }
    }
}
