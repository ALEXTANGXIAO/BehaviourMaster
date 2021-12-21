using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameApp : UnitySingleton<GameApp>
{
    void Start()
    {
        ActorFactory.Instance.Create("Perfab/player");
    }
}
