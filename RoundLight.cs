using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundLight : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //���z��30�b�ň��
        transform.Rotate(new Vector3(0, -12) * Time.deltaTime);
    }
}
