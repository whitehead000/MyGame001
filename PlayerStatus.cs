using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStatus : MobStatus
{
    protected override void OnDie()
    {
        base.OnDie();

        StartCoroutine(GoToGameOverCoroutine());
    }

    private IEnumerator GoToGameOverCoroutine()
    {
        //3�b�҂��Ă���Q�[���I�[�o�[�V�[���֑J�ڂ���
        yield return new WaitForSeconds(3); 
        SceneManager.LoadScene("GameOverScene");
    }
}
