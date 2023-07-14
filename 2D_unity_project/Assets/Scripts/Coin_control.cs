using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_control : MonoBehaviour
{


    private float y = -10;


    // Start is called before the first frame update
    void Start()
    {
        Jump();
    }

    //처음 coin 생성 시 위로 랜덤하게 오르게 하는 함수
    void Jump() {

        //rigidbody component 가져오기
        Rigidbody2D rigid_body = GetComponent<Rigidbody2D>();

        float jump_force = Random.Range(5f, 10f);

        //up을 이용하면 상하, y좌표만 벡터에 적용함
        Vector2 jump = Vector2.up * jump_force * Time.deltaTime;

        //jump.x 로 vector 의 좌우, x좌표도 벡터에 적용시킴
        jump.x = Random.Range(-2f, 2f);

        rigid_body.AddForce(jump, ForceMode2D.Impulse);

    }






    // Update is called once per frame
    void Update()
    {
        
         if(transform.position.y < y) {
            Destroy(gameObject);
        }


    }
}
