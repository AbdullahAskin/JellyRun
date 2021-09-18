using UnityEngine;

interface ICollide
{
    void OnCollide(Vector3 forceDir, float force, float stunDuration);
}