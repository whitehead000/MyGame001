//攻撃制御用スクリプト

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MobStatus))] //攻撃制御クラス
public class MobAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown = 0.5f; //攻撃後のクールダウン（秒）
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

    //攻撃可能な状態であれば攻撃を行う
    public void AttackIfPossible()
    {
        if (!_status.IsAttackable) return;

        //ステータスと衝突したオブジェクトで攻撃可否を判断する
        _status.GoToAttackStateIfPossible();
    }

    //攻撃対象が攻撃範囲に入ったときに呼ばれる
    public void OnAttackRangeEnter(Collider collider)
    {
        AttackIfPossible();
    }

    //攻撃の開始時に呼ばれる
    public void OnAttackStart()
    {
        attackCollider.enabled = true;
    }

    //attackColliderが攻撃対象にHitしたときに呼ばれる
    public void OnHitAttack(Collider collider)
    {
        var targetMob = collider.GetComponent<MobStatus>();

        if (null == targetMob) return;

        //プレイヤーにダメージを与える
        targetMob.Damage(1);
    }

    //攻撃の終了時に呼ばれる
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
