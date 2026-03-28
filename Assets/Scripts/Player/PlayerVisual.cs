using UnityEngine;

public class PlayerVisual : MonoBehaviour
{
    [SerializeField] private Player _player;

    private SpriteRenderer _spriteRenderer;
    private Animator _animator;

    /// <summary>
    /// для аниматора
    /// </summary>
    private const string IS_RUNNING = "IsRunning";

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        UpdateVisual();
    }

    /// <summary>
    /// обновляет анимацию и поворот
    /// </summary>
    private void UpdateVisual()
    {
        _animator.SetBool(IS_RUNNING, Player.Instance.IsRunning());
        _spriteRenderer.flipX = Player.Instance.IsTurnLeft();
    }
}
