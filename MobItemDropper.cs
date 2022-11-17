//敵を倒したときにアイテムを出現させるスクリプト

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(MobStatus))]
public class MobItemDropper : MonoBehaviour
{
    [SerializeField] [Range(0, 1)] private float dropRate = 0.1f; //アイテム出現確率
    [SerializeField] private Item itemPrefab;
    [SerializeField] private int number = 1; //アイテム出現個数

    private MobStatus _status;
    private bool _isDropInvoked; //アイテムドロップを実行済みかどうか

    // Start is called before the first frame update
    private void Start()
    {
        _status = GetComponent<MobStatus>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_status.Life <= 0)
        {
            DropIfNeeded(); //敵のライフが尽きたときに実行
        }
    }

    //必要であればアイテムを出現させる
    private void DropIfNeeded()
    {
        if (_isDropInvoked) return; //アイテムをドロップ済みならなにもしない

        _isDropInvoked = true; //このあとアイテムをドロップさせる
        if (Random.Range(0, 1f) >= dropRate) return; //アイテムを出現させるかどうかの確率処理

        //アイテムをnumber個出現させる
        for (var i = 0; i < number; i++)
        {
            var item = Instantiate(itemPrefab, transform.position, Quaternion.identity);
            item.Initialize();
        }
    }
}
