using UnityEngine;

public abstract class Obstacle : MonoBehaviour
{
    // protected IObstacleAction ObstacleAction;
    protected ObstacleState State = ObstacleState.CanCollide;
    protected float Force, Cooldown;
    protected Vector3 ForceDir;

    #region ObstacleState

    public enum ObstacleState
    {
        CanCollide,
        CannotCollide
    }

    #endregion

    public abstract void InitializeColor();
    public abstract void ObstacleAction(Transform collidedTrans);


    protected void InitializeForceVariables(Vector3 ForceDir, float Force,
        float Cooldown)
    {
        this.ForceDir = ForceDir;
        this.Force = Force;
        this.Cooldown = Cooldown;
    }

    protected void SetObstacleState(ObstacleState targetObstacleState)
    {
        State = targetObstacleState;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("PlayerCollider") || State != ObstacleState.CanCollide) return;
        ObstacleAction(other.transform);
    }
}