//所持アイテムの保存・復元クラス

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

[Serializable]
public class OwnedItemsData
{
    private const string PlayerPrefsKey = "OWNED_ITEMS_DATA"; //PlayerPrefs保存キー

    //インスタンスを返す
    public static OwnedItemsData Instance
    {
        get
        {
            if(null == _instance)
            {
                _instance = PlayerPrefs.HasKey(PlayerPrefsKey)
                    ? JsonUtility.FromJson<OwnedItemsData>(PlayerPrefs.GetString(PlayerPrefsKey))
                    : new OwnedItemsData();
            }

            return _instance;
        }
    }

    private static OwnedItemsData _instance;

    //所持アイテム一覧を取得する
    public OwnedItemsData[] OwnedItems
    {
        get { return OwnedItems.ToArray(); }
    }

    [SerializeField] private List<OwnedItem> ownedItems = new List<OwnedItem>(); //どのアイテムを何個所持しているかのリスト

    //コンストラクタ
    //シングルトンでは外部からnewできないようコンストラクタをprivateにする
    private OwnedItemsData()
    {

    }

    //JSON化してPlayerPrefsに保存する
    public void Save()
    {
        var jsonString = JsonUtility.ToJson(this);
        PlayerPrefs.SetString(PlayerPrefsKey, jsonString);
        PlayerPrefs.Save();
    }

    //アイテムを追加する
    public void Add(Item.ItemType type, int number = 1)
    {
        var item = GetItem(type);

        if(null == item)
        {
            item = new OwnedItem(type);
            ownedItems.Add(item);
        }

        item.Add(number);
    }

    //アイテムを消費する
    public void Use(Item.ItemType type, int number = 1)
    {
        var item = GetItem(type);

        if(null == item || item.Number < number)
        {
            throw new Exception("アイテムが足りません");
        }

        item.Use(number);
    }

    //対象の種類のアイテムデータを取得する
    public OwnedItem GetItem(Item.ItemType type)
    {
        return ownedItems.FirstOrDefault(x => x.Type == type);
    }




    //アイテムの所持数管理用モデル
    [Serializable]
    public class OwnedItem
    {
        //アイテムの種類を返す
        public Item.ItemType Type
        {
            get { return type; }
        }

        //アイテムの個数を返す
        public int Number
        {
            get { return number; }
        }

        [SerializeField] private Item.ItemType type; //アイテムの種類
        [SerializeField] private int number; //アイテムの所持個数

        //コンストラクタ
        public OwnedItem(Item.ItemType type)
        {
            this.type = type;
        }

        //アイテムの追加メソッド
        public void Add(int number = 1)
        {
            this.number += number;
        }

        //アイテムの使用メソッド
        public void Use(int number = 1)
        {
            this.number -= number;
        }
    }
}
