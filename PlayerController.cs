using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(MobAttack))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3; //移動速度
    [SerializeField] private float jumpPower = 3; //ジャンプ力
    [SerializeField] private Animator animator;
    private CharacterController _characterController; //キャッシュ
    private Transform _transform; //キャッシュ
    private Vector3 _moveVelocity; //移動速度情報
    private PlayerStatus _status; //ステータス
    private MobAttack _attack;

    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>(); //マイフレームアクセスするので負荷を下げるためにキャッシュしておく
        _transform = transform; //同じくキャッシュ
        _status = GetComponent<PlayerStatus>();
        _attack = GetComponent<MobAttack>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(_characterController.isGrounded ? "地上にいます" : "空中です");

        if (Input.GetButtonDown("Fire1"))
        {
            _attack.AttackIfPossible(); //Fire1ボタンで攻撃する
        }

        if (_status.IsMovable) //移動可能な状態なら、ユーザー入力を移動に反映する
        {
            //入力軸による移動処理
            _moveVelocity.x = Input.GetAxis("Horizontal") * moveSpeed;
            _moveVelocity.z = Input.GetAxis("Vertical") * moveSpeed;

            //移動方向に向く
            _transform.LookAt(_transform.position + new Vector3(_moveVelocity.x, 0, _moveVelocity.z));
        }
        else
        {
            _moveVelocity.x = 0;
            _moveVelocity.z = 0;
        }

        

        if (_characterController.isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                //ジャンプ処理
                Debug.Log("ジャンプ！");
                _moveVelocity.y = jumpPower;
            }
        }
        else
        {
            //重力による加速
            _moveVelocity.y += Physics.gravity.y * Time.deltaTime;
        }

        //オブジェクトを動かす
        _characterController.Move(_moveVelocity * Time.deltaTime);

        //移動スピードをanimatorに反映
        animator.SetFloat("MoveSpeed", new Vector3(_moveVelocity.x, 0, _moveVelocity.z).magnitude);
    }
}
