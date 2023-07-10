using System;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(PlayerController))]
    public class PlyerInput : MonoBehaviour
    {
        private PlayerController _playerController;
        private Shooter shooter;
        

        private void Awake()
        {
            _playerController = GetComponent<PlayerController>();
            shooter = GetComponent<Shooter>();
        }

        private void Update()
        {
            float horizontal = Input.GetAxis("Horizontal");
            bool isJumpBtnPressed = Input.GetButtonDown("Jump");
            
            if(Input.GetButtonDown("Fire1"))
                shooter.Shoot(horizontal);

            _playerController.Move(horizontal, isJumpBtnPressed);
        }
    }
}