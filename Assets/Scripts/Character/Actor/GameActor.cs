using System.Collections.Generic;

public abstract class GameActor
{
    protected ActorAI m_AI = null;

    public void SetAI(ActorAI characterAI)
    {
        m_AI = characterAI;
    }

    public void UpdateAI(List<GameActor> gameActors)
    {
        m_AI.Update(gameActors);
    }

    public void RemoveAITarget(GameActor gameActor)
    {
        m_AI.Remove(gameActor);
    }

    public float GetAttackRange()
    {
        return 1f;
    }

    public virtual void Attack(GameActor gameActor)
    {

    }
}
