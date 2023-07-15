using System;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(PlayerController))]
    public class PlyerInput : MonoBehaviour
    {
        [SerializeField] private float cooldownTimer;
        
        private PlayerController _playerController;
        private Shooter shooter;

        private float currentCooldownTimer;
        
        

        private void Awake()
        {
            _playerController = GetComponent<PlayerController>();
            shooter = GetComponent<Shooter>();
        }

        private void Update()
        {
            float horizontal = Input.GetAxis("Horizontal");
            bool isJumpBtnPressed = Input.GetButtonDown("Jump");

            currentCooldownTimer += Time.deltaTime;

            if (Input.GetButtonDown("Fire1") && currentCooldownTimer >= cooldownTimer)
            {
                shooter.Shoot(_playerController.IsFacingRight);
                currentCooldownTimer = 0;
            }

             _playerController.Move(horizontal, isJumpBtnPressed);
        }

        
    }
}