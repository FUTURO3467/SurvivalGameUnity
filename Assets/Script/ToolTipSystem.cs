using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolTipSystem : MonoBehaviour
{
    public static ToolTipSystem instance;

    [SerializeField]
    private ToolTip toolTip;

    private void Awake()
    {
        instance = this;
    }

    public void Show(string content, string header = "")
    {
        toolTip.SetText(content, header);
        toolTip.gameObject.SetActive(true);
    }
    public void Hide()
    {
        toolTip.gameObject.SetActive(false);
    }

}