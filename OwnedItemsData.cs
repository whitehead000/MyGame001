//�����A�C�e���̕ۑ��E�����N���X

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

[Serializable]
public class OwnedItemsData
{
    private const string PlayerPrefsKey = "OWNED_ITEMS_DATA"; //PlayerPrefs�ۑ��L�[

    //�C���X�^���X��Ԃ�
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

    //�����A�C�e���ꗗ���擾����
    public OwnedItemsData[] OwnedItems
    {
        get { return OwnedItems.ToArray(); }
    }

    [SerializeField] private List<OwnedItem> ownedItems = new List<OwnedItem>(); //�ǂ̃A�C�e�������������Ă��邩�̃��X�g

    //�R���X�g���N�^
    //�V���O���g���ł͊O������new�ł��Ȃ��悤�R���X�g���N�^��private�ɂ���
    private OwnedItemsData()
    {

    }

    //JSON������PlayerPrefs�ɕۑ�����
    public void Save()
    {
        var jsonString = JsonUtility.ToJson(this);
        PlayerPrefs.SetString(PlayerPrefsKey, jsonString);
        PlayerPrefs.Save();
    }

    //�A�C�e����ǉ�����
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

    //�A�C�e���������
    public void Use(Item.ItemType type, int number = 1)
    {
        var item = GetItem(type);

        if(null == item || item.Number < number)
        {
            throw new Exception("�A�C�e��������܂���");
        }

        item.Use(number);
    }

    //�Ώۂ̎�ނ̃A�C�e���f�[�^���擾����
    public OwnedItem GetItem(Item.ItemType type)
    {
        return ownedItems.FirstOrDefault(x => x.Type == type);
    }




    //�A�C�e���̏������Ǘ��p���f��
    [Serializable]
    public class OwnedItem
    {
        //�A�C�e���̎�ނ�Ԃ�
        public Item.ItemType Type
        {
            get { return type; }
        }

        //�A�C�e���̌���Ԃ�
        public int Number
        {
            get { return number; }
        }

        [SerializeField] private Item.ItemType type; //�A�C�e���̎��
        [SerializeField] private int number; //�A�C�e���̏�����

        //�R���X�g���N�^
        public OwnedItem(Item.ItemType type)
        {
            this.type = type;
        }

        //�A�C�e���̒ǉ����\�b�h
        public void Add(int number = 1)
        {
            this.number += number;
        }

        //�A�C�e���̎g�p���\�b�h
        public void Use(int number = 1)
        {
            this.number -= number;
        }
    }
}
