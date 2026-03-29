using System.Collections;
using UnityEngine;

public class PlayerVisual : MonoBehaviour
{
    public static PlayerVisual Instance { get; private set; }

    private SpriteRenderer _spriteRenderer;
    private Animator _animator;

    /// <summary>
    /// для аниматора
    /// </summary>
    private const string IS_RUNNING = "IsRunning";
    private const string STOP_PREPARING = "StopPreparing";
    private const string FAST_ATTACK_SKILL = "FastAttackSkill";
    private const string SLOW_ATTACK_SKILL = "SlowAttackSkill";

    private void Awake()
    {
        Instance = this;

        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        DamageSkillSO.OnStopPreparing += DamageSkillSO_OnStopPreparing;
        DamageSkillSO.OnStartAnimation += DamageSkillSO_OnStartAnimation;
    }

    private void Update()
    {
        UpdateVisual();
    }

    public void StartAnimation(SkillSO.Skills skill)
    {
        switch (skill)
        {
            case SkillSO.Skills.FastAttack:
            _animator.SetTrigger(FAST_ATTACK_SKILL);
            break;
            case SkillSO.Skills.SlowAttack:
            _animator.SetTrigger(SLOW_ATTACK_SKILL);
            break;
        }
    }

    /// <summary>
    /// обновляет анимацию и поворот
    /// </summary>
    private void UpdateVisual()
    {
        _animator.SetBool(IS_RUNNING, Player.Instance.IsRunning());
        _spriteRenderer.flipX = Player.Instance.IsTurnLeft();
    }

    /// <summary>
    /// просто проигрывает анимацию подготовки (сейчас - первый кадр из Attack2)
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void DamageSkillSO_OnStopPreparing(object sender, System.EventArgs e)
    {
        //Debug.Log("Vis start");
        _animator.SetTrigger(STOP_PREPARING);
    }

    private void DamageSkillSO_OnStartAnimation(object sender, SkillEventArgs e)
    {
        switch (e.name)
        {
            case SkillSO.Skills.FastAttack:
            _animator.SetTrigger(FAST_ATTACK_SKILL);
            break;
            
            case SkillSO.Skills.SlowAttack:
            _animator.SetTrigger(SLOW_ATTACK_SKILL);
            break;

        }
    }
}
