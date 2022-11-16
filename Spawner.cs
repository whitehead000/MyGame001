//�G�̏o���X�N���v�g

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
        StartCoroutine(SpawnLoop()); //�G�̏o��Coroutine
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //�G�o����Coroutine
    private IEnumerator SpawnLoop()
    {
        while (true)
        {
            var distanceVector = new Vector3(10, 0); //����10�̃x�N�g��

            //�v���C���[�̈ʒu���x�[�X�ɂ����G�̏o���ʒu�BY���ɑ΂��ď�L�x�N�g���������_����0�x�`360�x��]�����Ă���
            var spawnPositionFromPlayer = Quaternion.Euler(0, Random.Range(0, 360f), 0) * distanceVector;

            //�G�̏o���ʒu
            var spawnPosition = playerStatus.transform.position + spawnPositionFromPlayer;

            //�w����W�����ԋ߂�NavMesh�̍��W��T��
            NavMeshHit navMeshHit;
            if(NavMesh.SamplePosition(spawnPosition, out navMeshHit, 10, NavMesh.AllAreas))
            {
                //enemyPrefab�𕡐��ANavMeshAgent�͕K��NavMesh��ɔz�u
                Instantiate(enemyPrefab, navMeshHit.position, Quaternion.identity);
            }

            //10�b�҂�
            yield return new WaitForSeconds(10);

     
            if(playerStatus.Life <= 0)
            {
                break; //�v���C���[���|�ꂽ�烋�[�v�𔲂���
            }
        }
    }
}
