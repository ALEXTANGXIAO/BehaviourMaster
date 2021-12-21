using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

internal interface IEventInfo
{

}

public class EventInfo<T>:IEventInfo
{
    public UnityAction<T> actions;

    public EventInfo(UnityAction<T> action)
    {
        actions += action;
    }
}

public class EventInfo<T,U> : IEventInfo
{
    public UnityAction<T, U> actions;

    public EventInfo(UnityAction<T, U> action)
    {
        actions += action;
    }
}

public class EventInfo<T, U, W> : IEventInfo
{
    public UnityAction<T, U, W> actions;

    public EventInfo(UnityAction<T, U, W> action)
    {
        actions += action;
    }
}

public class EventInfo: IEventInfo
{
    public UnityAction actions;

    public EventInfo(UnityAction action)
    {
        actions += action;
    }
}

public class EventCenter : Singleton<EventCenter>
{
    private Dictionary<string, IEventInfo> eventDic = new Dictionary<string, IEventInfo>();
    private Dictionary<int, IEventInfo> m_eventDic = new Dictionary<int, IEventInfo>();

    public void AddEventListener<T>(string name,UnityAction<T> action)
    {
        if (eventDic.ContainsKey(name))
        {
            (eventDic[name] as EventInfo<T>).actions += action;
        }
        else
        {
            eventDic.Add(name, new EventInfo<T>(action));
        }
    }

    public void AddEventListener(string name, UnityAction action)
    {
        if (eventDic.ContainsKey(name))
        {
            (eventDic[name] as EventInfo).actions += action;
        }
        else
        {
            eventDic.Add(name, new EventInfo(action));
        }
    }

    public void RemoveEventListener<T>(string name,UnityAction<T> action)
    {
        if (action == null)
        {
            return;
        }

        if (eventDic.ContainsKey(name))
        {
            (eventDic[name] as EventInfo<T>).actions -= action;
        }
    }

    public void RemoveEventListener(string name, UnityAction action)
    {
        if (action == null)
        {
            return;
        }

        if (eventDic.ContainsKey(name))
        {
            (eventDic[name] as EventInfo).actions -= action;
        }
    }

    public void EventTrigger<T>(string name,T info)
    {
        if (eventDic.ContainsKey(name))
        {
            if ((eventDic[name] as EventInfo<T>).actions != null){
                (eventDic[name] as EventInfo<T>).actions.Invoke(info);
            }
        }
    }

    public void EventTrigger(string name)
    {
        if (eventDic.ContainsKey(name))
        {
            if ((eventDic[name] as EventInfo).actions != null)
            {
                (eventDic[name] as EventInfo).actions.Invoke();
            }
        }
    }

    public void AddEventListener<T>(int eventid, UnityAction<T> action)
    {
        if (m_eventDic.ContainsKey(eventid))
        {
            (m_eventDic[eventid] as EventInfo<T>).actions += action;
        }
        else
        {
            m_eventDic.Add(eventid, new EventInfo<T>(action));
        }
    }

    public void AddEventListener<T,U>(int eventid, UnityAction<T,U> action)
    {
        if (m_eventDic.ContainsKey(eventid))
        {
            (m_eventDic[eventid] as EventInfo<T,U>).actions += action;
        }
        else
        {
            m_eventDic.Add(eventid, new EventInfo<T,U>(action));
        }
    }

    public void AddEventListener<T, U, W>(int eventid, UnityAction<T, U, W> action)
    {
        if (m_eventDic.ContainsKey(eventid))
        {
            (m_eventDic[eventid] as EventInfo<T, U, W>).actions += action;
        }
        else
        {
            m_eventDic.Add(eventid, new EventInfo<T, U , W>(action));
        }
    }

    public void AddEventListener(int eventid, UnityAction action)
    {
        if (m_eventDic.ContainsKey(eventid))
        {
            (m_eventDic[eventid] as EventInfo).actions += action;
        }
        else
        {
            m_eventDic.Add(eventid, new EventInfo(action));
        }
    }

    public void RemoveEventListener<T>(int eventid, UnityAction<T> action)
    {
        if (action == null)
        {
            return;
        }

        if (m_eventDic.ContainsKey(eventid))
        {
            (m_eventDic[eventid] as EventInfo<T>).actions -= action;
        }
    }

    public void RemoveEventListener<T,U>(int eventid, UnityAction<T,U> action)
    {
        if (action == null)
        {
            return;
        }

        if (m_eventDic.ContainsKey(eventid))
        {
            (m_eventDic[eventid] as EventInfo<T,U>).actions -= action;
        }
    }

    public void RemoveEventListener(int eventid, UnityAction action)
    {
        if (action == null)
        {
            return;
        }

        if (m_eventDic.ContainsKey(eventid))
        {
            (m_eventDic[eventid] as EventInfo).actions -= action;
        }
    }

    public void EventTrigger<T>(int eventid, T info)
    {
        if (m_eventDic.ContainsKey(eventid))
        {
            if ((m_eventDic[eventid] as EventInfo<T>).actions != null)
            {
                (m_eventDic[eventid] as EventInfo<T>).actions.Invoke(info);
            }
        }
    }

    public void EventTrigger<T,U>(int eventid, T info,U info2)
    {
        if (m_eventDic.ContainsKey(eventid))
        {
            if ((m_eventDic[eventid] as EventInfo<T,U>).actions != null)
            {
                (m_eventDic[eventid] as EventInfo<T,U>).actions.Invoke(info,info2);
            }
        }
    }

    public void EventTrigger<T, U , W>(int eventid, T info, U info2, W info3)
    {
        if (m_eventDic.ContainsKey(eventid))
        {
            if ((m_eventDic[eventid] as EventInfo<T, U , W>).actions != null)
            {
                (m_eventDic[eventid] as EventInfo<T, U , W>).actions.Invoke(info, info2, info3);
            }
        }
    }

    public void EventTrigger(int eventid)
    {
        if (m_eventDic.ContainsKey(eventid))
        {
            if ((m_eventDic[eventid] as EventInfo).actions != null)
            {
                (m_eventDic[eventid] as EventInfo).actions.Invoke();
            }
        }
    }

    /// <summary>
    /// 清除事件中心
    /// </summary>
    public void Clear()
    {
        eventDic.Clear();
        m_eventDic.Clear();
    }
}
