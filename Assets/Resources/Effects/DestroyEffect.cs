using UnityEngine;
using System.Collections;

public class DestroyEffect : MonoBehaviour {

	void Awake ()
    {
        Invoke("DestroyObject", 2.0f);
    }
    private void DestroyObject()
    {
        Destroy(gameObject);
    }
}
