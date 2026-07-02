using TMPro;
using UnityEngine;

public class DebugInput : MonoBehaviour
{
    private TextMeshProUGUI debugText;

    private void Start()
    {
        debugText = this.GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        MainControler.DebugReference += ReferenceText;
    }

    private void OnDisable()
    {
        MainControler.DebugReference -= ReferenceText;
    }

    private void ReferenceText()
    {
        debugText.text = MainControler.state.ToString();
        debugText.color = Color.blue;
    }
}
