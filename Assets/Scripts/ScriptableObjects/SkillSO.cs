using UnityEngine;

public abstract class SkillSO : ScriptableObject
{
    public enum Skills
    {
        FastAttack,
        SlowAttack
    }

    public new Skills name;

    public abstract void Execute();
}
