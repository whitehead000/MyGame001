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

    //CollisionDetector��onTriggerStay�ɃZ�b�g���A�Փ˔�����󂯎�郁�\�b�h
    public void OnDetectObject(Collider collider)
    {
        //���m�����I�u�W�F�N�g�ɁuPlayer�v�̃^�O�����Ă���΁A���̃I�u�W�F�N�g��ǂ�������
        if (collider.CompareTag("Player"))
        {
            //�G����݂��v���C���[�̈ʒu�x�N�g��
            var positionDiff = collider.transform.position - transform.position;
            var distance = positionDiff.magnitude;
            var direction = positionDiff.normalized;

            //_raycastHits�ɁA�q�b�g����Collider����W���Ȃǂ��i�[�����
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
