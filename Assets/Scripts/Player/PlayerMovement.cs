using System;
using DG.Tweening;
using UnityEngine;
using static SpeedData;

public class PlayerMovement : MonoBehaviour, IInputAction, ISpeedBoost
{
    private BoxSpeed _playerBoxSpeed;

    private float _currentSpeed;

    private void Start()
    {
        SetBoostSpeed(SpeedManager.GetBoxSpeed(SpeedComboType.Def));
    }

    public void Action()
    {
        if (Input.touchCount == 0)
        {
            _currentSpeed = _playerBoxSpeed.minSpeed;
            return;
        }

        SyncSpeed();
        SyncPosition();
    }

    private void SyncSpeed()
    {
        _currentSpeed += _playerBoxSpeed.velocityIncreaseSpeed * Time.fixedDeltaTime;
        _currentSpeed = Mathf.Clamp(_currentSpeed, _playerBoxSpeed.minSpeed, _playerBoxSpeed.maxSpeed);
    }

    private void SyncPosition()
    {
        transform.position += (_currentSpeed * Time.fixedDeltaTime * transform.forward);
    }

    public void BoostBoxSpeed()
    {
        var iTarget = (int) _playerBoxSpeed.speedComboType + 1;
        var nLength = Enum.GetNames(typeof(SpeedComboType)).Length;
        if (iTarget == nLength) return;

        var targetSpeedComboType = (SpeedComboType) iTarget;
        SetBoostSpeed(SpeedManager.GetBoxSpeed(targetSpeedComboType));
    }

    public void SetBoostSpeed(BoxSpeed targetBoxSpeed)
    {
        _playerBoxSpeed = targetBoxSpeed;
    }
}