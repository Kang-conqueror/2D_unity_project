using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_control : MonoBehaviour
{
    [SerializeField]
    public float movespeed = 10f;


    //enemy destroy 시 coin이 생성되게, GameObject 생성
    [SerializeField]
    private GameObject coin;

    private float y = -10f;

    //각 enemy의 체력설정

    [SerializeField]
    private float hp = 1f;


   

    // Update is called once per frame
    void Update()
    {
        
        transform.position += Vector3.down * movespeed * Time.deltaTime;


        if(transform.position.y < y) {
            Destroy(gameObject);
        }

    }

    //unity가 제공하는, 충돌을 감지하는 함수가 있다
    //is trigger가 활성화되어 있을 때는 trigger 사용
    private void OnTriggerEnter2D(Collider2D other) {
        
        //Enemy와 충돌한 물체가 ohter로 취급되고, 그 other의 tag를 비교해 물체의 종류 구분
        if (other.gameObject.tag == "Bullet") {

            //bullet과 enemy 충돌 시 dmg만큼 hp 감소
            Bullet_control bullet = other.gameObject.GetComponent<Bullet_control>();
            hp -= bullet.dmg;

            //hp 0 이하 시 enemy destroy
            if (hp <= 0) {
                Destroy(gameObject);
                Instantiate(coin, transform.position, Quaternion.identity);

            }

            //other.gameObject 즉 bullet도 충돌 시 destroy
            Destroy(other.gameObject);

        }

    }


}
