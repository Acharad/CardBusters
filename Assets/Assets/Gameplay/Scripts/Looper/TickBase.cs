using System.Collections;
using System.Collections.Generic;
using Assets.Gameplay.Scripts.Looper;
using UnityEngine;

public abstract class TickBase : MonoBehaviour, ITick
{
    [Sirenix.OdinInspector.ShowInInspector]
    public virtual bool WillWait => true;

    [Sirenix.OdinInspector.ShowInInspector]
    public virtual bool WillStop => false;
    
    public void InitTick()
    {
    }
    
    public abstract IEnumerator Tick();
}
