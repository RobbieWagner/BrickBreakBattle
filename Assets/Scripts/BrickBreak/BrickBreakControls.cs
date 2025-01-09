using System;
using UnityEngine;

namespace RobbieWagnerGames.BrickBallGame
{
    public class BrickBreakControls : MonoBehaviour
    {
        [SerializeField] private BounceBar bounceBarInstance;

        private void Awake()
        {
            InputManager.Instance.gameControls.PLAYER.Move.performed += OnMove;
            InputManager.Instance.gameControls.PLAYER.Move.canceled += OnStop;
        }

        private void OnStop(UnityEngine.InputSystem.InputAction.CallbackContext context)
        {
            bounceBarInstance.moveVector = Vector2.zero;
        }

        private void OnMove(UnityEngine.InputSystem.InputAction.CallbackContext context)
        {
            bounceBarInstance.moveVector = context.ReadValue<Vector2>();
        }
    }
}