using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMove : MonoBehaviour
{
    private NavMeshAgent _agent;
    private RaycastHit[] _raycastHits = new RaycastHit[10];

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //CollisionDetectorのonTriggerStayにセットし、衝突判定を受け取るメソッド
    public void OnDetectObject(Collider collider)
    {
        //検知したオブジェクトに「Player」のタグがついていれば、そのオブジェクトを追いかける
        if (collider.CompareTag("Player"))
        {
            //敵からみたプレイヤーの位置ベクトル
            var positionDiff = collider.transform.position - transform.position;
            var distance = positionDiff.magnitude;
            var direction = positionDiff.normalized;

            //_raycastHitsに、ヒットしたColliderや座標情報などが格納される
            var hitCount = Physics.RaycastNonAlloc(transform.position, direction, _raycastHits, distance);

            Debug.Log("hitCount: " + hitCount);

            if(hitCount == 0)
            {
                _agent.isStopped = false;
                _agent.destination = collider.transform.position;
            }
            else
            {
                _agent.isStopped = true;
            }

        }
    }
}
