using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ColorData", order = 1)]
public class ColorData : ScriptableObject
{
    #region ColorStructs

    [System.Serializable]
    public struct BoxColor
    {
        public Material colorMat;
        public int iColorLayer;
        public ColorType colorType;
    }

    public enum ColorType
    {
        Pink,
        Blue,
        Purple,
        Yellow
    }

    #endregion

    public List<BoxColor> boxColors;
}