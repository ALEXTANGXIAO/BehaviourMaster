using System.Collections;
using UnityEngine;

public class ActorMgr : Singleton<ActorMgr>
{
    public Transform ActorParent;
    public ActorMgr()
    {
        InitRoot();
    }

    private void InitRoot()
    {
        GameObject obj = new GameObject();
        obj.name = "ActorRoot";
        Object.DontDestroyOnLoad(obj);
        ActorParent = obj.transform;
    }
}

public class ActorFactory : Singleton<ActorFactory>
{
    private Transform Parent
    {
        get
        {
            return ActorMgr.Instance.ActorParent;
        }
    }
    public void Create(string name)
    {
        var obj = Resources.Load<GameObject>(name);
        if (obj != null)
        {
            var instance = GameObject.Instantiate(obj);
            instance.transform.SetParent(Parent);
        }
    }
}