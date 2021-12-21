using System.Collections;
using UnityEngine;

public class InterActionCmpt : MonoBehaviour
{
    public bool DoDamage(InterActionCmpt attacker)
    {
        if (attacker == this)
        {
            return false;
        }

        //var damege = attacker.gameObject.GetComponent<ActorWeapon>().GetAtk();
        //print("Do Damage is called.:" + attacker.name + "is attacking" + name + " Damege is:" + damege);

        Animator animator = gameObject.GetComponent<Animator>();

        animator.SetTrigger(AnimatorParamDefine.IsHurt);

        return true;
    }
}