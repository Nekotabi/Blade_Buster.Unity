using System.Collections;
using UnityEngine;

public class PlayerAct : MonoBehaviour
{
    Animator PLAimator;
    void Start()
    {
        PLAimator = this.GetComponent<Animator>();
    }

    private void OnEnable()
    {
        MainControler.PlayerAttack += OnAttack;
    }

    private void OnDisable()
    {
        MainControler.PlayerAttack -= OnAttack;
    }

    private void OnAttack()
    {
        StartCoroutine(AttackPaform());
    }

    private IEnumerator AttackPaform()
    {
        PLAimator.SetBool("IsAttack", true);
        yield return new WaitForEndOfFrame();
        PLAimator.SetBool("IsAttack", false);
    }
}
