//ゲームオーバー画面のアニメータースクリプト

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
        var defaultPosition = transformCache.localPosition; //終点として利用するため、初期座標を保持する

        transformCache.localPosition = new Vector3(0, 300f); //いったん上に移動させる

        transformCache.DOLocalMove(defaultPosition, 1f)
            .SetEase(Ease.Linear)
            .OnComplete(() =>
            {
                Debug.Log("Game Over!!");

                transformCache.DOShakePosition(1.5f, 100); //シェイクアニメーション
            });

        //DOTweenには、Coroutineを使わずに任意の秒数を待てる便利メソッドが搭載されている
        DOVirtual.DelayedCall(10, () =>
        {
            SceneManager.LoadScene("TitleScene"); //10秒まってからタイトルシーンに遷移する
        }
        );

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
