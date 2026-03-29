using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.Utilities;

[CreateAssetMenu(fileName = "DamageSkillSO", menuName = "Skills/Damage Skill")]
public class DamageSkillSO : SkillSO
{
    [SerializeField] private int _damage;
    [SerializeField] private GameObject _polygonCollider2D;
    [SerializeField] private float _preparing;

    /// <summary>
    /// на сколько секунд включается коллайдер атаки
    /// </summary>
    [SerializeField] private float _colliderTime = 0.1f;

    public static event EventHandler OnStopPreparing; // static чтобы принимать событие от любого экземпляра
    public static event EventHandler<SkillEventArgs> OnStartAnimation; // и тут

    public override void Execute()
    {
        GlobalCoroutineRunner.MyStartCoroutine(ExecuteRoutine(_preparing, _colliderTime));
    }

    /// <summary>
    /// создает объект с нужным коллайдером,
    /// запускает анимацию подготовки,
    /// запускает анимацию нужной атаки,
    /// включает коллайдер,
    /// затем выключает коллайдер
    /// </summary>
    /// <param name="preparing"></param>
    /// <param name="colliderTime"></param>
    /// <returns></returns>
    private IEnumerator ExecuteRoutine(float preparing, float colliderTime)
    {
        GameObject colliderObject = Instantiate(_polygonCollider2D, Player.Instance.transform.position, Quaternion.identity);
        PolygonCollider2D collider = colliderObject.GetComponent<PolygonCollider2D>();
        OnStartAnimation?.Invoke(this, new SkillEventArgs{name = name}); // в качестве аргумента передает экземпляр моего
                                                                         // класса с заданным name = имя скилла. короче просто передаю,
                                                                         // какую анимацию использовать PlayerVisual

        yield return new WaitForSeconds(preparing);

        OnStopPreparing?.Invoke(this, EventArgs.Empty);

        //OnStartAnimation?.Invoke(this, new SkillEventArgs{name = name}); 
        collider.enabled = true;

        yield return new WaitForSeconds(colliderTime);

        collider.enabled = false;
        Destroy(colliderObject);
    }
}

public class SkillEventArgs : EventArgs
{
    public SkillSO.Skills name;
}

