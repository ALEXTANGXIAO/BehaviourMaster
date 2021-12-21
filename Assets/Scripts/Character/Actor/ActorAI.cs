using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActorAI
{
    protected GameActor m_actor= null;
    protected float m_attackRange = 0;
    protected IAIState m_AIState = null;//角色AI状态
    protected const float ATTACK_COLD_DOWN = 1.0f;//攻击的CoolDown
    protected float m_coolDown = ATTACK_COLD_DOWN;

    public ActorAI(GameActor actor)
    {
        m_actor = actor;
        m_attackRange = actor.GetAttackRange();
    }

    public virtual void Remove(GameActor gameActor)
    {
        throw new NotImplementedException();
    }

    //更换AI状态
    public virtual void ChangAIState(IAIState state)
    {
        m_AIState = state;
        m_AIState.SetCharacterAI(this);
    }

    public virtual void Attack(GameActor gameActor)
    {
        //冷却
        m_coolDown -= Time.deltaTime;
        if (m_coolDown > 0)
        {
            return;
        }
        m_coolDown = ATTACK_COLD_DOWN;

        //攻击操作
        m_actor.Attack(gameActor);
    }

    public void Update(List<GameActor> targets)
    {
        m_AIState.Update(targets);
    }
}

public abstract class IAIState
{
    protected ActorAI m_characterAI = null;//角色AI（状态的拥有者）

    public void SetCharacterAI(ActorAI characterAI)
    {
        m_characterAI = characterAI;
    }

    public virtual void SetAttackPosition()
    {

    }

    public virtual void Update(List<GameActor> targets)
    {

    }

    public virtual void RemoveTarget(GameActor target)
    {

    }
}