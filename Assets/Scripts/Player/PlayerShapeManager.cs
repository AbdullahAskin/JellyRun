using UnityEngine;

public class PlayerShapeManager : MonoBehaviour, IInputAction
{
    public Transform GFXScalePivot;
    private float _shapeArea;

    private const float DeadZone = 1f, ScaleChangeSpeed = .04f, MINScale = .9f, MAXScale = 4.8f;

    private void Start()
    {
        var shapeScale = GFXScalePivot.localScale;
        _shapeArea = shapeScale.x * shapeScale.y;
    }

    public void Action()
    {
        var deltaY = Input.touchCount == 0 ? 0 : Input.GetTouch(0).deltaPosition.y;
        if (Mathf.Abs(deltaY) < DeadZone) return;

        deltaY = Mathf.Clamp(deltaY, -20, 20);
        ChangeShapeScale(deltaY);
    }

    private void ChangeShapeScale(float deltaY)
    {
        var shapeScale = GFXScalePivot.localScale;
        var yAdditionalScale = deltaY * ScaleChangeSpeed;
        var yScale = GetYScale(yAdditionalScale);
        var xScale = GetXScale(yScale);

        GFXScalePivot.localScale = new Vector3(xScale, yScale, shapeScale.z);
    }

    private float GetYScale(float yAdditionalScale)
    {
        var shapeScale = GFXScalePivot.localScale;
        var yScale = Mathf.Clamp(shapeScale.y + yAdditionalScale, MINScale, MAXScale);
        return yScale;
    }

    private float GetXScale(float yScale)
    {
        var xScale = _shapeArea / yScale;
        return xScale;
    }
    
}