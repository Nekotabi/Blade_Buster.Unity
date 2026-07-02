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

    void Awake()
    {
        //‚¨‚Ü‚¶‚È‚¢
        if (controler != null)
            Destroy(this.gameObject);
        else
            controler = this;
    }

    public static void ReferenceRequest()
    {
        DebugReference?.Invoke();
    }
}
