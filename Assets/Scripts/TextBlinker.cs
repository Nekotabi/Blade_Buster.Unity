using TMPro;
using UnityEngine;

public class TextBlinker : MonoBehaviour
{
    /// <summary>
    /// None:点滅しない, Moment:カクカク、Sharpness:スムーズ
    /// </summary>
    private enum BlinkMode
    {
        None,
        Moment,
        sharpness
    }

    private TextMeshProUGUI m_Text;
    [SerializeField] private BlinkMode blinkMode;
    [SerializeField] private float flashingInterval;
    private const float waitTime = 0.1f;
    private float timer;
    private bool isInterbal;

    void Start()
    {
        m_Text = this.GetComponent<TextMeshProUGUI>();
        isInterbal = false;
        timer = 0f;
    }

    void Update()
    {
        if (blinkMode != BlinkMode.None)
            timer += Time.deltaTime;

        if (isInterbal)
        {
            if (timer > waitTime)
            {
                isInterbal = false;
                timer = 0f;
            }

            return;
        }

        switch (blinkMode)
        {
            case BlinkMode.Moment:
                if (timer - flashingInterval > 0f)
                {
                    m_Text.enabled = !m_Text.isActiveAndEnabled;
                    isInterbal = true;
                    timer = 0f;
                }
                break;
            case BlinkMode.sharpness:
                break;
        }
    }
}
