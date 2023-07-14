using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//unity의 ui text 접근을 위해 using
using TMPro;
//Scenemanager 사용 위해 using
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI ui_text;



    [SerializeField]
    private GameObject Game_over_pannel;

    [SerializeField]
    private TextMeshProUGUI Game_over_text;



    [SerializeField]
    private int Bullet_upgrade_degree = 30;

    //coin의 수 저장할 변수
    private int coin = 0;

    public static GameManager instance = null;

    //start보다 더 우선적으로 게임 실행시 실행되는 함수
    void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    //ui의 coin 수를 증가시켜주는 함수
    public void Increase_coin() {
        coin += 1;


        //text는 단순 변수가 아닌 TextMesh 변수이기에, = 연산자 이용 대입으로는 안된다
        //SetText로 문자열을 변경이 가능한데, coin은 int형 이기에 Tostring으로 변경
        ui_text.SetText(coin.ToString());

        if (coin % Bullet_upgrade_degree == 0) {
            //game 내에서 Player_control 라는 object를 찾는다
            Player_control player = FindObjectOfType<Player_control>();

            //player의 bullet upgrade 시키기
            if(player != null) {
                player.Bullet_upgrage();
            }

        }

    }

    //game 종료를 담당할 함수
    public void Game_over() {

        //enemy spawner control의 정보 가져오기
        Enemy_spawner_control enemy_spawn = FindObjectOfType<Enemy_spawner_control>();



        //enemy의 Coroutine 중지시켜서 생성 멈추기
        if(enemy_spawn != null) {
            enemy_spawn.Stop_Enemy_spawn_routine();

            //시간 경과에 따른 enemy의 속도 증가치를 초기화
            for (int i = 0; i < enemy_spawn.Enemy.Length; i++) {

                Enemy_control enemy = enemy_spawn.Enemy[i].GetComponent<Enemy_control>();
                enemy.movespeed = enemy_spawn.enemy_original_speed[i];

            }

            //game over ui표시
            Game_over_pannel.SetActive(true);
            //game over 시 현재 coin text 표시
            Game_over_text.SetText(coin.ToString());
        }



    }

    //SampleScene을 다시 load하는 함수
    public void Restart() {
        SceneManager.LoadScene("SampleScene");
    }



}
