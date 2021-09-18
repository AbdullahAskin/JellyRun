using DG.Tweening;
using UnityEngine;
using static ColorData;

[RequireComponent(typeof(Rigidbody), typeof(OnGroundControl), typeof(CamManager))]
public class Player : MonoBehaviour, IColor, IChangableColor, ICollide, IDead
{
    private IInputControl _playerInputControl;
    private ISpeedBoost _playerSpeedBoost;
    private CamManager _camManager;
    private OnGroundControl _onGroundControl;

    private Rigidbody _playerRb;
    public MeshRenderer playerGfxMesh;

    public ColorType startColorType;
    private BoxColor _playerBoxColor;

    private void Start()
    {
        _playerInputControl = GetComponent<IInputControl>();
        _playerSpeedBoost = GetComponent<ISpeedBoost>();
        _playerRb = GetComponent<Rigidbody>();
        _onGroundControl = GetComponent<OnGroundControl>();
        _camManager = GetComponent<CamManager>();
        InitializeColor();
    }

    #region Initialize

    public void InitializeColor()
    {
        _playerBoxColor = ColorManager.GetBoxColor(startColorType);
        SetColor(_playerBoxColor);
    }

    public void SetColor(BoxColor targetBoxColor)
    {
        _playerBoxColor = targetBoxColor;
        ColorManager.SetColor(targetBoxColor, playerGfxMesh);
        ColorManager.SetLayer(targetBoxColor.iColorLayer, playerGfxMesh.gameObject);
    }

    public void SetColor(BoxColor targetBoxColor, float duration)
    {
        _playerBoxColor = targetBoxColor;
        playerGfxMesh.material.DOColor(targetBoxColor.colorMat.color, duration);
        ColorManager.SetLayer(targetBoxColor.iColorLayer, playerGfxMesh.gameObject);
    }

    #endregion

    public void OnCollide(Vector3 forceDir, float force, float stunDuration)
    {
        _playerRb.AddForce(forceDir * force);
        _playerInputControl.SetInputState(PlayerInput.InputState.CannotOrder);
        DOTween.Sequence()
            .AppendCallback(() => { _playerInputControl.SetInputState(PlayerInput.InputState.CanOrder); })
            .SetDelay(stunDuration);
        _playerSpeedBoost.SetBoostSpeed(SpeedManager.GetBoxSpeed(SpeedData.SpeedComboType.Def));
    }

    public void OnDead(Vector3 forceDir, float force)
    {
        _playerRb.AddForce(forceDir * force);
        _playerRb.constraints = RigidbodyConstraints.None;
        _playerRb.angularVelocity = -5f * Vector3.right;
        _playerRb.AddForce(Physics.gravity * 1.5f, ForceMode.Acceleration);

        _playerInputControl.SetInputState(PlayerInput.InputState.CannotOrder);

        _camManager.SetLookAt(transform);
        _camManager.SetCameraParent(null);

        StartCoroutine(_onGroundControl.Ground_Control());
    }
}