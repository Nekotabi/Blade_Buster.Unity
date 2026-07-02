using System;
using System.Collections.Generic;
using NUnit.Framework;
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
    public static event Action<bool> WinLoseJudge;
    [SerializeField] private List<LayerMask> layerMasks;
    public static LayerMask[] masks;

    void Awake()
    {
        //‚¨‚Ü‚¶‚È‚¢
        if (controler != null)
            Destroy(this.gameObject);
        else
            controler = this;
        state = InputState.NONE;

        masks = layerMasks.ToArray();
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

    public static void OnDead(LayerMask _layer)
    {
        if (_layer == masks[0])
            WinLoseJudge?.Invoke(false);
        if (_layer == masks[1])
            WinLoseJudge?.Invoke(true);
    }
}
