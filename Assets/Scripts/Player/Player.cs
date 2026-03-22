using System;
using UnityEngine;

public class Player : MonoBehaviour
{
        public static Player Instance { get; private set; }

        [SerializeField] private float _initialMovingSpeed = 8f;

        private Vector2 _inputVector;
        private Rigidbody2D _rigidbody2D;
        private float _movingSpeed;
        private float _minMovingSpeed = 0.1f;
        private float _minTurn = 0.1f;
        private bool _isRunning;
        private bool _isTurnLeft;

        private void Awake()
        {
                Instance = this;

                _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
                _movingSpeed = _initialMovingSpeed;
        }

        private void Update()
        {
                _inputVector = GameInput.Instance.GetMovementVector();
        }

        private void FixedUpdate()
        {
                HandleMovement();
        }

        private void HandleMovement()
        {
                _rigidbody2D.MovePosition(_rigidbody2D.position + _inputVector * (_movingSpeed * Time.fixedDeltaTime));

                if (Mathf.Abs(_inputVector.x) > _minMovingSpeed)
                {
                        _isRunning = true;
                }
                else
                {
                        _isRunning = false;
                }

                if (_inputVector.x < -_minTurn)
                {
                        _isTurnLeft = true;
                }
                else if (_inputVector.x > _minTurn)
                {
                        _isTurnLeft = false;
                }
        }
}
