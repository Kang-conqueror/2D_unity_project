using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_control : MonoBehaviour
{
    //unity 접근 허용
    [SerializeField]

    private float movespeed = 10f;

    // Start is called before the first frame update
    void Start()
    {   
        Destroy(gameObject, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position += Vector3.up * movespeed * Time.deltaTime;


    }
}
