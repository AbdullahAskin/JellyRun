using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static SpeedData;

public class SpeedManager : MonoBehaviour
{
    private static List<BoxSpeed> _boxSpeeds;

    private void Awake()
    {
        var speedData = Resources.Load<SpeedData>("ScriptableObjects/SpeedData");
        _boxSpeeds = speedData.boxSpeeds;
    }

    public static BoxSpeed GetBoxSpeed(SpeedComboType speedComboType)
    {
        foreach (var boxSpeed in _boxSpeeds.Where(boxSpeed => boxSpeed.speedComboType == speedComboType))
        {
            return boxSpeed;
        }

        return default;
    }
}