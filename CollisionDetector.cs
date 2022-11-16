using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

[RequireComponent(typeof(Collider))]
public class CollisionDetector : MonoBehaviour
{
    [SerializeField] private TriggerEvent onTriggerEnter = new TriggerEvent();
    [SerializeField] private TriggerEvent onTriggerStay = new TriggerEvent();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        onTriggerEnter.Invoke(other);
    }

    //is Trigger��ON�ő���Collider�Əd�Ȃ��Ă���Ƃ��́A���̃��\�b�h����ɃR�[�������
    private void OnTriggerStay(Collider other)
    {
        //onTriggerStay�Ŏw�肳�ꂽ���������s����
        onTriggerStay.Invoke(other);
    }

    //UnityEvent���p�������N���X��[Serializable]������t�^���邱�ƂŁAInspector�E�B���h�E��ɕ\���ł���悤�ɂȂ�
    [Serializable] 
    public class TriggerEvent : UnityEvent<Collider>
    {
      
    }
}
