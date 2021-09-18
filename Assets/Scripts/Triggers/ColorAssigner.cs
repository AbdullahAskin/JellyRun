using DG.Tweening;
using UnityEngine;
using static ColorData;

public class ColorAssigner : Trigger
{
    public ColorType colorType;
    private IChangableColor _playerChangeableColor;
    private BoxColor _boxColor;
    private const float Duration = .4f;

    private void Start()
    {
        _playerChangeableColor = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<IChangableColor>();
        _boxColor = ColorManager.GetBoxColor(colorType);
        InitializeMovement();
    }

    private void InitializeMovement()
    {
        transform.DORotate(new Vector3(0, 360, 0), 1f).SetRelative(true).SetEase(Ease.Linear).SetLoops(-1);
    }

    protected override void TriggerAction()
    {
        _playerChangeableColor.SetColor(_boxColor, Duration);
        gameObject.SetActive(false);
    }
}