using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DamageText : MonoBehaviour
{
    private float moveSpeed;
    private float alphaSpeed;
    Text text;
    Color alpha;
    public int damage;


    void Start()
    {
        moveSpeed = 2.0f;
        alphaSpeed = 2.0f;

        text = GetComponent<Text>();
        alpha = text.color;
        text.text = damage.ToString();
        transform.GetComponent<RectTransform>().sizeDelta = new Vector2(150, 150);
        Invoke("DestroyObject", 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.GetComponent<RectTransform>().anchoredPosition  = new Vector3(0, moveSpeed * Time.deltaTime, 0); // 텍스트 위치
        transform.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
        alpha.a = Mathf.Lerp(alpha.a, 0, Time.deltaTime * alphaSpeed); // 텍스트 알파값
        text.color = alpha;
    }
    private void DestroyObject()
    {
        Destroy(gameObject);
//        ObjectPool.ReturnObject(this);
    }
}