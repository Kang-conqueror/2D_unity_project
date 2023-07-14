using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_control : MonoBehaviour
{
    //unity 접근 허용
    [SerializeField]
    private float movespeed = 10f;

    

    
    //다른 class 에서도 접근 가능하게 public 변수 선언
    [SerializeField]
    public float dmg = 1f;


    // Start is called before the first frame update
    void Start()
    {   
        Destroy(gameObject, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position += Vector3.up * movespeed * Time.deltaTime;


    }
}
