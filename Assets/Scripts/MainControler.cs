using System;
using UnityEngine;

public class MainControler : MonoBehaviour
{
    public enum InputState
    {
        NONE,
        TAP,
        SWIPE,
        FLICK
    }
    public static InputState state;
    public static MainControler controler;
    public static event Action DebugReference;
    public static event Action PlayerAttack;
    public static event Action EnemyAttack;

    void Awake()
    {
        //‚¨‚Ü‚¶‚È‚¢
        if (controler != null)
            Destroy(this.gameObject);
        else
            controler = this;
        state = InputState.NONE;
    }

    public static void ReferenceRequest()
    {
        DebugReference?.Invoke();
        if (state == InputState.FLICK || state == InputState.SWIPE)
        {
            PlayerAttack?.Invoke();
            state = InputState.NONE;
        }
    }
}
