//アイテムスクリプト

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Collider))]
public class Item : MonoBehaviour
{
    public enum ItemType
    {
        Wood, //木
        Stone, //石
        ThrowAxe //投げオノ（木と石でつくる！）
    }

    [SerializeField] private ItemType type;

    //初期化処理
    public void Initialize()
    {
        //アニメーションが終わるまでcolliderを無効化する
        var colliderCache = GetComponent<Collider>();
        colliderCache.enabled = false;

        //出現アニメーション
        var transformCache = transform;
        var dropPosition = transform.localPosition + new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)); //出現位置
        transformCache.DOLocalMove(dropPosition, 0.5f);
        var defaultScale = transformCache.localScale;
        transformCache.DOScale(defaultScale, 0.5f)
            .SetEase(Ease.OutBounce)
            .OnComplete(() =>
            {
                colliderCache.enabled = true; //アニメーションが終わったらcolliderを有効化する
            });
    }

    //プレイヤーがアイテムに接触したら所持品として追加し、オブジェクトをシーンから破棄
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        //TODOプレイヤーの所持品として追加する

        //オブジェクトを破棄する
        Destroy(gameObject);
    }
}
