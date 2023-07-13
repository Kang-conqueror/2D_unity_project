using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_spawner_control : MonoBehaviour
{
    //Enemy들을 관리할 list
    [SerializeField]
    private GameObject[] Enemy;

    //enemy가 사출되는 x좌표 값 list
    private float[] x_Pos = {-4f, -2f, 0f, 2f, 4f}; 


    //enemy가 spawn되는 interval
    [SerializeField]
    private float Spawn_interval = 1.5f;


    //enemy가 사출되는 list의 범위가 늘어나는 interval 단위
    [SerializeField]
    private float Spawn_levelUp_interval = 10;



    // Start is called before the first frame update
    void Start()
    {
        
        Start_enemy_spawn();
        

    }

    void Start_enemy_spawn() {
        StartCoroutine("Enemy_spawn_routine");
    }


    IEnumerator Enemy_spawn_routine() {

        yield return new WaitForSeconds(3f);

        //각각 enemy의 사출 횟수, enemy list의 최대 idx 값
        int spawn_count = 0;

        int enemy_idx = 3;



        while (true) {

             foreach (float x in x_Pos) {

                int idx = Random.Range(0, enemy_idx);
                
                enemy_spawn(x, idx);

            }

            spawn_count += 1;

            if (spawn_count % Spawn_levelUp_interval == 0 && enemy_idx < 9) {

                enemy_idx += 1;

            }

            
            


            yield return new WaitForSeconds(Spawn_interval);
        } 

    }

    //enemy를 spawn하는 함수
    //-2.6, -1.4, -0.5, 0.6, 1.8, 
    void enemy_spawn(float xPos, int idx) {
        
        Vector3 spawnPos = new Vector3(xPos, transform.position.y, transform.position.z);        

        Instantiate(Enemy[idx], spawnPos, Quaternion.identity);

    }

}
