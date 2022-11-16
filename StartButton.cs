using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class StartButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var button = GetComponent<Button>();

        //�{�^�������������Ƃ��̃��X�i�[��ݒ肷��
        button.onClick.AddListener(() =>
        {
            //�V�[���J�ڂ̍ۂɂ�SceneManager���g�p����
            SceneManager.LoadScene("MainScene");
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
