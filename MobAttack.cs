//�U������p�X�N���v�g

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MobStatus))] //�U������N���X
public class MobAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown = 0.5f; //�U����̃N�[���_�E���i�b�j
    [SerializeField] private Collider attackCollider;

    private MobStatus _status;

    // Start is called before the first frame update
    void Start()
    {
        _status = GetComponent<MobStatus>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //�U���\�ȏ�Ԃł���΍U�����s��
    public void AttackIfPossible()
    {
        if (!_status.IsAttackable) return;

        //�X�e�[�^�X�ƏՓ˂����I�u�W�F�N�g�ōU���ۂ𔻒f����
        _status.GoToAttackStateIfPossible();
    }

    //�U���Ώۂ��U���͈͂ɓ������Ƃ��ɌĂ΂��
    public void OnAttackRangeEnter(Collider collider)
    {
        AttackIfPossible();
    }

    //�U���̊J�n���ɌĂ΂��
    public void OnAttackStart()
    {
        attackCollider.enabled = true;
    }

    //attackCollider���U���Ώۂ�Hit�����Ƃ��ɌĂ΂��
    public void OnHitAttack(Collider collider)
    {
        var targetMob = collider.GetComponent<MobStatus>();

        if (null == targetMob) return;

        //�v���C���[�Ƀ_���[�W��^����
        targetMob.Damage(1);
    }

    //�U���̏I�����ɌĂ΂��
    public void OnAttackFinished()
    {
        attackCollider.enabled = false;
        StartCoroutine(CooldownCoroutine());
    }

    private IEnumerator CooldownCoroutine()
    {
        yield return new WaitForSeconds(attackCooldown);
        _status.GoToNormalStateIfPossible();
    }
}
