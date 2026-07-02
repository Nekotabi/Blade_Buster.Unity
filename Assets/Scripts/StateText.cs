using System.Collections;
using TMPro;
using UnityEngine;

public class StateText : MonoBehaviour
{
    private TextMeshProUGUI myText;
    private TextMeshProUGUI infoText;
    [SerializeField]private GameObject infoObj;

    private void Start()
    {
        myText = this.GetComponent<TextMeshProUGUI>();
        infoText = infoObj.GetComponent<TextMeshProUGUI>();
        myText.enabled = false;
        infoText.enabled = false;
    }

    private void OnEnable()
    {
        MainControler.WinLoseJudge += ReferenceText;
    }

    private void OnDisable()
    {
        MainControler.WinLoseJudge -= ReferenceText;
    }

    private void ReferenceText(bool isWin)
    {
        myText.text = isWin ? "Victory!!" : "defeat...";
        myText.color = Color.blue;
        DelayEnable();
    }

    private IEnumerator DelayEnable()
    {
        yield return new WaitForSeconds(1.0f);
        myText.enabled = true;
        infoText.enabled = true;
    }
}
