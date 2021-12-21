using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackActionCmpt : MonoBehaviour
{
    public enum STATE
    {
        IDLE,
        ACTIVE
    }

    public STATE State;

    public float ATK;

    private void OnTriggerEnter(Collider collider)
    {
        if (State == STATE.ACTIVE)
        {
            InterActionCmpt interActionCmpt = collider.GetComponent<InterActionCmpt>();//使用im get碰撞
            if (interActionCmpt != null)
            {
                interActionCmpt.DoDamage(GetComponentInParent<InterActionCmpt>());
#if UNITY_EDITOR
                print(this.name + "is hitting =>" + collider.name);
                //print(im);
#endif
            }
        }
    }
}
