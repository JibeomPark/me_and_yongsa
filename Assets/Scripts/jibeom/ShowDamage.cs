using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowDamage : MonoBehaviour
{
    public GameObject hudDamageText;
    public GameObject Canvas;
    GameObject temp;
    public GameObject tf_object;
    public float a, b;
    public int fontSize;
    public Font font;
    void Start()
    {
        temp = hudDamageText;
    }
    // Start is called before the first frame update
    public void TakeDamage(int damage)
    {
        var hudText = ObjectPool.GetObject(); // 생성할 텍스트 오브젝트
        hudText.transform.SetParent(Canvas.transform);
        hudText.transform.position = new Vector3(a, b, 0); // 표시될 위치
        hudText.GetComponent<DamageText>().damage = damage; // 데미지 전달
        hudText.GetComponent<Text>().font = font;
        hudText.GetComponent<Text>().fontSize = fontSize;
    }
}
