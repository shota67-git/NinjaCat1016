using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    GameObject hp;
    public TextMeshProUGUI show;
    float counttime = 0;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        hp = GameObject.Find("HP");
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            SceneManager.LoadScene("menu");
        }
        counttime += Time.deltaTime;
        show.text = (15-counttime).ToString("f0");
        if (counttime > 15)
        {
            Time.timeScale = 0;//暫停遊戲
            if (hp.GetComponent<Image>().fillAmount >= 0.6)
            {
                //過關成功載入下一關
            }
            else
            {
                //過關失敗載入失敗畫面
            }
        }
    }
    // Update is called once per frame
    public void DecreaseHp()
    {
        hp.GetComponent<Image>().fillAmount -= 0.1f;
    }
    public void IncreaseHp()
    {
        Image img = hp.GetComponent<Image>();
        img.fillAmount = Mathf.Min(1f, img.fillAmount + 0.1f);
    }
}
