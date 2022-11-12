//�����I�u�W�F�N�g�̏�ԊǗ��X�N���v�g

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobStatus : MonoBehaviour
{
    protected enum StateEnum
    {
        Normal, //�ʏ�
        Attack, //�U����
        Die //���S
    }

    public bool IsMovable => StateEnum.Normal == _state; //�ړ��\���ǂ���
    public bool IsAttackable => StateEnum.Normal == _state; //�U���\���ǂ���
    public float LifeMax => LifeMax; //���C�t�ő�l��Ԃ�
    public float Life => _life; //���C�t�̒l��Ԃ�

    [SerializeField] private float lifeMax = 10; //���C�t�ő�l

    protected Animator _animator;
    protected StateEnum _state = StateEnum.Normal; //Mob���
    private float _life; //���݂̃��C�t�l

    protected virtual void Start()
    {
        _life = lifeMax; //������Ԃ̓��C�t���^��
        _animator = GetComponentInChildren<Animator>();
    }

    //�L�����N�^�[���|�ꂽ���̏���
    protected virtual void OnDie()
    {

    }

    //�w��l�̃_���[�W���󂯂�
    public void Damage(int damage)
    {
        if (_state == StateEnum.Die) return;

        _life -= damage;

        if (_life > 0) return;

        _state = StateEnum.Die;
        _animator.SetTrigger("Die");
        OnDie();
    }

    //�\�ł���΍U�����̏�ԂɑJ�ڂ���
    public void GoToAttackStateIfPossible()
    {
        if (!IsAttackable) return;

        _state = StateEnum.Attack;
        _animator.SetTrigger("Attack");
    }

    //�\�ł����Normal�̏�ԂɑJ�ڂ���
    public void GoToNormalStateIfPossible()
    {
        if (_state == StateEnum.Die) return;

        _state = StateEnum.Normal;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
