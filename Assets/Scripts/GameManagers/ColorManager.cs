using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using static ColorData;

public class ColorManager : MonoBehaviour
{
    private static List<BoxColor> _boxColors;

    private void Awake()
    {
        var colorData = Resources.Load<ColorData>("ScriptableObjects/ColorData");
        _boxColors = colorData.boxColors;
    }

    public static BoxColor GetBoxColor(ColorType colorType)
    {
        foreach (var boxColor in _boxColors.Where(boxColor => boxColor.colorType == colorType))
        {
            return boxColor;
        }

        return default;
    }

    public static BoxColor GetRandomColor()
    {
        return _boxColors[Random.Range(0, _boxColors.Count)];
    }

    public static void SetColor(BoxColor targetBoxColor, MeshRenderer colorableMesh)
    {
        colorableMesh.material.color = targetBoxColor.colorMat.color;
    }

    public static void SetColor(BoxColor targetBoxColor, MeshRenderer colorableMesh, float duration)
    {
        colorableMesh.material.color = targetBoxColor.colorMat.color;
        colorableMesh.material.DOColor(targetBoxColor.colorMat.color, duration);
    }

    public static void SetLayer(int iColorLayer, GameObject colorableGO)
    {
        colorableGO.layer = iColorLayer;
    }
}