using System;
using System.Collections;
using UnityEngine;

public class OnGroundControl : MonoBehaviour
{
    private const float TakeOffDuration = .3f, ParticleDuration = 1f;
    public ParticleSystem dustParticle;
    public GameObject tryAgainScreen;
    private Collider _gfxColl;

    private void Start()
    {
        _gfxColl = GetComponentInChildren<Collider>();
    }

    public IEnumerator Ground_Control()
    {
        yield return new WaitForSeconds(TakeOffDuration);
        var yOffset = _gfxColl.bounds.extents.y;
        while (true)
        {
            var startPos = transform.position - Vector3.up * yOffset;
            if (Physics.Raycast(startPos, Vector3.down, out var hitInfo, 2f) && hitInfo.collider.gameObject.layer == 3)
                break;
            yield return new WaitForFixedUpdate();
        }

        PlayDust();
        yield return new WaitForSeconds(ParticleDuration);
        tryAgainScreen.SetActive(true);
    }

    private void PlayDust()
    {
        var dustTrans = dustParticle.transform;
        dustTrans.parent = null;
        dustTrans.eulerAngles = Vector3.zero;
        dustTrans.position = new Vector3(dustTrans.position.x, 0, dustTrans.position.z + 3);
        dustParticle.Play();
    }
}