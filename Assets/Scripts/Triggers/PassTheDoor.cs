using DG.Tweening;
using UnityEngine;

public class PassTheDoor : Trigger
{
    public MeshRenderer doorAnimMesh;
    private ISpeedBoost _playerSpeedBoost;

    private void Start()
    {
        _playerSpeedBoost = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<ISpeedBoost>();
    }

    protected override void TriggerAction()
    {
        _playerSpeedBoost.BoostBoxSpeed();
        ExecuteDoorAnim();
    }

    protected void ExecuteDoorAnim()
    {
        doorAnimMesh.gameObject.SetActive(true);
        var doorColor = doorAnimMesh.material.color;
        doorColor.a = 0f;
        var targetColor = doorColor;
        doorAnimMesh.material.DOColor(targetColor, .5f);
        doorAnimMesh.transform.DOMoveY(1.5f, .5f).SetRelative(true);
        doorAnimMesh.transform.DOScale(1.5f, .5f).SetRelative(true).OnComplete(() =>
        {
            doorAnimMesh.gameObject.SetActive(false);
        });
    }
}