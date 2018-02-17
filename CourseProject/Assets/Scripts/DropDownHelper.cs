using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropDownHelper : MonoBehaviour {

    private Dropdown dd;

    private void Start()
    {
        dd = GetComponent<Dropdown>();
    }

    public void UpdateValue()
    {
        LockpickInfo.Difficulty = (LockpickInfo.DifficultyOptions)dd.value;
    }
}
