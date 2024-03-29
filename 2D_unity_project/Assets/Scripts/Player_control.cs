using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_control : MonoBehaviour
{
    [SerializeField]
    private float movespeed;

    //이 cs파일과 Unity 내의 GameObject를 연결시켜주기
    [SerializeField]
    private GameObject[] Bullet;
    
    private int Bullet_idx = 0;

    [SerializeField]
    private Transform Shooter;


    [SerializeField]
    private float shoot_interval = 0.5f;
    
    private float last_shoot = 0f;


    [SerializeField]
    private float tox_length = 4.5f;


    // Start is called before the first frame update
    //void Start()
    // {
        
    // }

    // Update is called once per frame
    void Update()
    {   
        //첫번째와 두번째 코드는 모두 키보드의 입력을 처리하는 코드
        //각각 좌우, 상하 이동 구분
        // float horizonInput = Input.GetAxisRaw("Horizontal");

        // float verticalInput = Input.GetAxisRaw("Vertical");

        // //새 Vector3 생성(x, y, z), 각각 x, y, z의 변화값 
        // Vector3 move = new Vector3(horizonInput, 0f, 0f);

        // transform.position += move * movespeed * Time.deltaTime;
  

        //키보드 입력값을 받는 또 다른 방법
        
        // Vector3 move2 = new Vector3(movespeed * Time.deltaTime, 0, 0);
        // if (Input.GetKey(KeyCode.LeftArrow)) {
        //     transform.position -= move2;
        // } 
        // else if (Input.GetKey(KeyCode.RightArrow)) {
        //     transform.position += move2;
        // }


        //마우스로 캐릭터를 움직이게끔 하는 코드
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float toX = Mathf.Clamp(mouse.x, tox_length * -1, tox_length);

        transform.position = new Vector3(toX, transform.position.y, transform.position.z);
        
        Shoot_Bullet();
    }

    //void 함수는 반환값이 없음
    void Shoot_Bullet() {

        if (Time.time - last_shoot > shoot_interval){

            Instantiate(Bullet[Bullet_idx], Shooter.position, Quaternion.identity);
            last_shoot = Time.time;
        }
    }

    //enemy와 충돌 시 캐릭터 destroy
    private void OnTriggerEnter2D(Collider2D other) {
        
        if (other.gameObject.tag == "Enemy") {

            Destroy(gameObject);

            //enemy와 충돌 시 game over 함수 작동
            GameManager.instance.Game_over();

        }

        //coin과 충돌 시

        else if (other.gameObject.tag == "Coin") {

            //coin 을 destroy
            Destroy(other.gameObject);

            //class명 + instance + ~~ 을 통해 다른 class, script 접근
            GameManager.instance.Increase_coin();

        }

    }

    //Bullet 이 들어있는 list의 idx를 관리하는 함수
    public void Bullet_upgrage() {
        Bullet_idx += 1;

        if (Bullet_idx >= Bullet.Length) {
            Bullet_idx -= 1;
        }
    }

}
