using System;
using static ColorData;
using UnityEngine;

public class Rotator : Obstacle, IColor, IRotate
{
    public MeshRenderer[] rotateArmMeshes;

    private IDead _playerDead;
    private const float RotateSpeed = 50f;

    private void Start()
    {
        var playerGO = GameObject.FindGameObjectWithTag("Player");
        _playerDead = playerGO.GetComponent<IDead>();
        InitializeColor();
        InitializeForceVariables(new Vector3(0, .5f, -.6f), 1500f, .75f);
    }

    #region Initialize

    public override void InitializeColor()
    {
        for (var index = 0; index < ((ColorType[]) Enum.GetValues(typeof(ColorType))).Length; index++)
        {
            var colorType = ((ColorType[]) Enum.GetValues(typeof(ColorType)))[index];
            var rotatorBoxColor = ColorManager.GetBoxColor(colorType);
            ColorManager.SetColor(rotatorBoxColor, rotateArmMeshes[index]);
            ColorManager.SetLayer(rotatorBoxColor.iColorLayer, rotateArmMeshes[index].gameObject);
        }
    }

    #endregion

    private void FixedUpdate()
    {
        Rotate();
    }

    public void Rotate()
    {
        transform.Rotate(RotateSpeed * Time.deltaTime * Vector3.up);
    }

    public override void ObstacleAction(Transform collidedTrans)
    {
        var forceDir = Vector3.Normalize(collidedTrans.up * ForceDir.y + collidedTrans.forward * ForceDir.z);
        _playerDead.OnDead(forceDir, Force);
        State = ObstacleState.CannotCollide;
    }
}