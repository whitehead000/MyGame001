//�A�C�e���X�N���v�g

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Collider))]
public class Item : MonoBehaviour
{
    public enum ItemType
    {
        Wood, //��
        Stone, //��
        ThrowAxe //�����I�m�i�؂Ɛ΂ł���I�j
    }

    [SerializeField] private ItemType type;

    //����������
    public void Initialize()
    {
        //�A�j���[�V�������I���܂�collider�𖳌�������
        var colliderCache = GetComponent<Collider>();
        colliderCache.enabled = false;

        //�o���A�j���[�V����
        var transformCache = transform;
        var dropPosition = transform.localPosition + new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)); //�o���ʒu
        transformCache.DOLocalMove(dropPosition, 0.5f);
        var defaultScale = transformCache.localScale;
        transformCache.DOScale(defaultScale, 0.5f)
            .SetEase(Ease.OutBounce)
            .OnComplete(() =>
            {
                colliderCache.enabled = true; //�A�j���[�V�������I�������collider��L��������
            });
    }

    //�v���C���[���A�C�e���ɐڐG�����珊���i�Ƃ��Ēǉ����A�I�u�W�F�N�g���V�[������j��
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        //TODO�v���C���[�̏����i�Ƃ��Ēǉ�����

        //�I�u�W�F�N�g��j������
        Destroy(gameObject);
    }
}
