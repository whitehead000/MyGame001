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
        //3秒待ってからゲームオーバーシーンへ遷移する
        yield return new WaitForSeconds(3); 
        SceneManager.LoadScene("GameOverScene");
    }
}
