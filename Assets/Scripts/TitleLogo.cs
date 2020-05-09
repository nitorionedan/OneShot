using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleLogo : MonoBehaviour
{
    [SerializeField] private Vector3 scaleChange;
    [SerializeField] private float destroyTime;

    void Start()
    {
        Invoke("DestroyThisGameobject", destroyTime);
    }

    void Update()
    {
        this.transform.localScale += scaleChange;
    }

    void DestroyThisGameobject() 
    {
        Destroy(this.gameObject);
    }
}
