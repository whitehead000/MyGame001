//�Q�[���I�[�o�[��ʂ̃A�j���[�^�[�X�N���v�g

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class GameOverTextAnimator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var transformCache = transform;
        var defaultPosition = transformCache.localPosition; //�I�_�Ƃ��ė��p���邽�߁A�������W��ێ�����

        transformCache.localPosition = new Vector3(0, 300f); //���������Ɉړ�������

        transformCache.DOLocalMove(defaultPosition, 1f)
            .SetEase(Ease.Linear)
            .OnComplete(() =>
            {
                Debug.Log("Game Over!!");

                transformCache.DOShakePosition(1.5f, 100); //�V�F�C�N�A�j���[�V����
            });

        //DOTween�ɂ́ACoroutine���g�킸�ɔC�ӂ̕b����҂Ă�֗����\�b�h�����ڂ���Ă���
        DOVirtual.DelayedCall(10, () =>
        {
            SceneManager.LoadScene("TitleScene"); //10�b�܂��Ă���^�C�g���V�[���ɑJ�ڂ���
        }
        );

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
