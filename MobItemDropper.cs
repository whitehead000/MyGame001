//�G��|�����Ƃ��ɃA�C�e�����o��������X�N���v�g

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(MobStatus))]
public class MobItemDropper : MonoBehaviour
{
    [SerializeField] [Range(0, 1)] private float dropRate = 0.1f; //�A�C�e���o���m��
    [SerializeField] private Item itemPrefab;
    [SerializeField] private int number = 1; //�A�C�e���o����

    private MobStatus _status;
    private bool _isDropInvoked; //�A�C�e���h���b�v�����s�ς݂��ǂ���

    // Start is called before the first frame update
    private void Start()
    {
        _status = GetComponent<MobStatus>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_status.Life <= 0)
        {
            DropIfNeeded(); //�G�̃��C�t���s�����Ƃ��Ɏ��s
        }
    }

    //�K�v�ł���΃A�C�e�����o��������
    private void DropIfNeeded()
    {
        if (_isDropInvoked) return; //�A�C�e�����h���b�v�ς݂Ȃ�Ȃɂ����Ȃ�

        _isDropInvoked = true; //���̂��ƃA�C�e�����h���b�v������
        if (Random.Range(0, 1f) >= dropRate) return; //�A�C�e�����o�������邩�ǂ����̊m������

        //�A�C�e����number�o��������
        for (var i = 0; i < number; i++)
        {
            var item = Instantiate(itemPrefab, transform.position, Quaternion.identity);
            item.Initialize();
        }
    }
}
