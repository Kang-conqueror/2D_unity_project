using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Enemy_spawner_control : MonoBehaviour
{
    //Enemy들을 관리할 list
    [SerializeField]
    public GameObject[] Enemy;

    //enemy의 원래 속도를 담을 list
    public float[] enemy_original_speed = {3f, 4f, 5f, 7f, 10f, 12f, 16f, 20f};


    //enemy가 사출되는 x좌표 값 list
    private float[] x_Pos = {-4f, -2f, 0f, 2f, 4f}; 

    //enemy가 spawn되는 interval
    [SerializeField]
    private float Spawn_interval = 1.5f;

    //enemy가 사출되는 list의 범위가 늘어나는 interval 단위
    [SerializeField]

    private int Spawn_levelUp_interval = 10;

    //시간에 따라 점점 enemy의 속도가 빨라지는 degree
    [SerializeField]

    private float movespeed_up_degree = 0.5f;

    // Start is called before the first frame update
    void Start()
    {     
        Start_enemy_spawn();    
    }

    //Coroutine 실행
    void Start_enemy_spawn() {
        StartCoroutine("Enemy_spawn_routine");
    }

    //Coroutine 중지
    public void Stop_Enemy_spawn_routine() {
        StopCoroutine("Enemy_spawn_routine");
    }



    IEnumerator Enemy_spawn_routine() {

        yield return new WaitForSeconds(3f);

        //각각 enemy의 사출 횟수, enemy list의 최대 idx 값
        int spawn_count = 0;

        int enemy_idx = 3;

        //무한 반복문으로 enemy를 지속적으로 사출하게 함
        //enemy spawn이 일정 횟수가 될 때마다 enemy list의 최대 idx늘려줘서 난이도 증가
        while (true) {

            //spawn 횟수 세기
            spawn_count += 1;

            foreach (float x in x_Pos) {

                int idx = Random.Range(0, enemy_idx);
                
                enemy_spawn(x, idx, spawn_count);

            }

            //spawn 횟수가 10의 배수가 될 때마다, 난이도 증가
            //and 조건으로 enemy list의 길이를 넘지 않게함
            if (spawn_count % Spawn_levelUp_interval == 0 && enemy_idx < Enemy.Length) {

                //enemy가 들어있는 list의 idx범위 늘려주기
                enemy_idx += 1;

                for (int i =0; i < Enemy.Length; i++) {

                    //일정 횟수마다 모든 enemy의 속도가 증가하게끔 했지만,
                    //game이 끝난 후에도 증가한 속도가 그대로 유지됨.
                    //후에 game 종료 시 속도를 다시 초기화시켜줘야됨
                    Enemy_control enemy = Enemy[i].GetComponent<Enemy_control>();
                    enemy.movespeed += movespeed_up_degree;
                }

            }      

            yield return new WaitForSeconds(Spawn_interval);
        } 

    }

    //enemy를 spawn하는 함수
    //-2.6, -1.4, -0.5, 0.6, 1.8, 
    void enemy_spawn(float xPos, int idx, int spawn_cnt) {
        
        //enemy를 spawn할 위치 선언
        Vector3 spawnPos = new Vector3(xPos, transform.position.y, transform.position.z);        

        //Instantiate로 enemy 생성, 변수에 저장해도 Instantiate는 실행됨      
        Instantiate(Enemy[idx], spawnPos, Quaternion.identity);        

    }





}




