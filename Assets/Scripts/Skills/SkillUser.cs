using System;
using UnityEngine;

public class SkillUser : MonoBehaviour
{
    [Header("Skills")]
    [Space(5)]
    [SerializeField] private DamageSkillSO _qSkill;
    [SerializeField] private DamageSkillSO _wSkill;

    private void Start()
    {
        GameInput.Instance.OnStartedQ += GameInput_OnStartedQ;
        GameInput.Instance.OnStartedW += GameInput_OnStartedW;
    }

    private void GameInput_OnStartedQ(object sender, System.EventArgs e)
    {
        _qSkill.Execute();
    }

    private void GameInput_OnStartedW(object sender, System.EventArgs e)
    {
        _wSkill.Execute();
    }

    private void OnDestroy()
    {
        GameInput.Instance.OnStartedQ -= GameInput_OnStartedQ;
    }
}
