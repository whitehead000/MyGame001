using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3; //�ړ����x
    [SerializeField] private float jumpPower = 3; //�W�����v��
    [SerializeField] private Animator animator;
    private CharacterController _characterController; //�L���b�V��
    private Transform _transform; //�L���b�V��
    private Vector3 _moveVelocity; //�ړ����x���

    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>(); //�}�C�t���[���A�N�Z�X����̂ŕ��ׂ������邽�߂ɃL���b�V�����Ă���
        _transform = transform; //�������L���b�V��
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(_characterController.isGrounded ? "�n��ɂ��܂�" : "�󒆂ł�");

        //���͎��ɂ��ړ�����
        _moveVelocity.x = Input.GetAxis("Horizontal") * moveSpeed;
        _moveVelocity.z = Input.GetAxis("Vertical") * moveSpeed;

        //�ړ������Ɍ���
        _transform.LookAt(_transform.position + new Vector3(_moveVelocity.x, 0, _moveVelocity.z));

        if (_characterController.isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                //�W�����v����
                Debug.Log("�W�����v�I");
                _moveVelocity.y = jumpPower;
            }
        }
        else
        {
            //�d�͂ɂ�����
            _moveVelocity.y += Physics.gravity.y * Time.deltaTime;
        }

        //�I�u�W�F�N�g�𓮂���
        _characterController.Move(_moveVelocity * Time.deltaTime);

        //�ړ��X�s�[�h��animator�ɔ��f
        animator.SetFloat("MoveSpeed", new Vector3(_moveVelocity.x, 0, _moveVelocity.z).magnitude);
    }
}