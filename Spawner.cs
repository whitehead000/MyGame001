//敵の出現スクリプト

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Spawner : MonoBehaviour
{
    [SerializeField] private PlayerStatus playerStatus;
    [SerializeField] private GameObject enemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnLoop()); //敵の出現Coroutine
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //敵出現のCoroutine
    private IEnumerator SpawnLoop()
    {
        while (true)
        {
            var distanceVector = new Vector3(10, 0); //距離10のベクトル

            //プレイヤーの位置をベースにした敵の出現位置。Y軸に対して上記ベクトルをランダムに0度～360度回転させている
            var spawnPositionFromPlayer = Quaternion.Euler(0, Random.Range(0, 360f), 0) * distanceVector;

            //敵の出現位置
            var spawnPosition = playerStatus.transform.position + spawnPositionFromPlayer;

            //指定座標から一番近いNavMeshの座標を探す
            NavMeshHit navMeshHit;
            if(NavMesh.SamplePosition(spawnPosition, out navMeshHit, 10, NavMesh.AllAreas))
            {
                //enemyPrefabを複製、NavMeshAgentは必ずNavMesh上に配置
                Instantiate(enemyPrefab, navMeshHit.position, Quaternion.identity);
            }

            //10秒待つ
            yield return new WaitForSeconds(10);

     
            if(playerStatus.Life <= 0)
            {
                break; //プレイヤーが倒れたらループを抜ける
            }
        }
    }
}
