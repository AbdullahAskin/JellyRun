using DG.Tweening;
using UnityEngine;
using static Obstacle;

public class Door : Obstacle, IColor
{
    public MeshRenderer[] doorMeshs;

    private ICollide _playerCollide;
    private const float StunDuration = .75f;

    private void Start()
    {
        var playerGO = GameObject.FindGameObjectWithTag("Player");
        _playerCollide = playerGO.GetComponent<ICollide>();
        InitializeColor();
        InitializeForceVariables(new Vector3(0, .1f, -.8f), 1000f, .75f);
    }

    #region Initialize

    public override void InitializeColor()
    {
        var doorBoxColor = ColorManager.GetRandomColor();
        foreach (var doorMesh in doorMeshs)
        {
            ColorManager.SetColor(doorBoxColor, doorMesh);
            ColorManager.SetLayer(doorBoxColor.iColorLayer, doorMesh.gameObject);
        }
    }

    #endregion

    public override void ObstacleAction(Transform collidedTrans)
    {
        var forceDir = Vector3.Normalize(collidedTrans.up * ForceDir.y + collidedTrans.forward * ForceDir.z);
        _playerCollide.OnCollide(forceDir, Force, StunDuration);
        State = ObstacleState.CannotCollide;
        DOTween.Sequence()
            .AppendCallback(() => { SetObstacleState(ObstacleState.CanCollide); })
            .SetDelay(Cooldown);
    }
}