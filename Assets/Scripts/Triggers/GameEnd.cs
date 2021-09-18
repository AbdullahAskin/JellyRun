using System.Collections;
using UnityEngine;

public class GameEnd : Trigger
{
    public GameObject nextLevelUI;
    private IInputControl _playerInputControl;

    private void Start()
    {
        _playerInputControl = GameObject.FindGameObjectWithTag("Player").GetComponent<IInputControl>();
    }

    protected override void TriggerAction()
    {
        nextLevelUI.SetActive(true);
        _playerInputControl.SetInputState(PlayerInput.InputState.CannotOrder);
        StartCoroutine(Wait_For_Touch());
    }

    private IEnumerator Wait_For_Touch()
    {
        yield return new WaitUntil(() => Input.touchCount == 0);
        yield return new WaitUntil(() => Input.touchCount > 0);
        LevelManager.Restart();
    }
}