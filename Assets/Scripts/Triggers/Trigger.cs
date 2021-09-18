using UnityEngine;

public abstract class Trigger : MonoBehaviour
{
    protected abstract void TriggerAction();

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("PlayerCollider")) return;
        TriggerAction();
    }
}