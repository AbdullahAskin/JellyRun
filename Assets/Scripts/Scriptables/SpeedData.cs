using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SpeedData", order = 1)]
public class SpeedData : ScriptableObject
{
    #region SpeedStructs

    [System.Serializable]
    public struct BoxSpeed
    {
        public SpeedComboType speedComboType;
        public float minSpeed, maxSpeed, velocityIncreaseSpeed;
    }

    public enum SpeedComboType
    {
        Def,
        One,
        Two,
        Three,
        Four
    }

    #endregion

    public List<BoxSpeed> boxSpeeds;
}