using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // Start is called before the first frame update
    EquipElements equip;
    Transform AxeTransform;
    Vector3 OriginalPosition;
    void Start()
    {
        OriginalPosition = AxeTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }
    void Attack()
    {
        if(Input.GetMouseButton(0)&&equip.hasAxe)
        {
             AxeTransform.transform.position = AxeTransform.transform.position + new V
        }
    }

}
