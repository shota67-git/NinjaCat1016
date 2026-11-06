using UnityEngine;

// 讓雲以出生位置為中心，自動左右來回移動。
// 用法：把這支腳本掛到 cloud（或 cloud.prefab）上即可。
public class CloudMover : MonoBehaviour
{
    public float moveDistance = 2.0f;   // 從中心往左、往右各移動多遠
    public float speed = 1.5f;          // 移動速度（單位/秒）
    public float startOffset = 0f;      // 起始相位偏移，多朵雲想錯開時可調整

    Rigidbody2D rigid2d;
    float startX;

    void Start()
    {
        rigid2d = GetComponent<Rigidbody2D>();
        startX = transform.position.x;
    }

    // 取得目前應該在的 x 座標（等速來回）
    float GetTargetX()
    {
        float t = Mathf.PingPong((Time.time + startOffset) * speed, moveDistance * 2f);
        return startX - moveDistance + t;
    }

    // 有 Rigidbody2D 時用物理方式移動，貓站在雲上才會被帶著走
    void FixedUpdate()
    {
        if (rigid2d != null)
        {
            rigid2d.MovePosition(new Vector2(GetTargetX(), rigid2d.position.y));
        }
    }

    // 沒有 Rigidbody2D 時退而求其次，直接改 transform
    void Update()
    {
        if (rigid2d == null)
        {
            Vector3 p = transform.position;
            transform.position = new Vector3(GetTargetX(), p.y, p.z);
        }
    }
}
