using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_control : MonoBehaviour
{
    [SerializeField]
    private float movespeed = 10f;

    private float y = -6;

    // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // Update is called once per frame
    void Update()
    {
        
        transform.position += Vector3.down * movespeed * Time.deltaTime;


        if(transform.position.y < y) {
            Destroy(gameObject);
        }

    }
}
