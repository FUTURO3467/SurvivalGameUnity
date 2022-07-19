
using UnityEngine;
using UnityEngine.UI;

public class ToolTip : MonoBehaviour
{
    [SerializeField]
    private Text headerFiled;

    [SerializeField]
    private Text contentFiled;

    [SerializeField]
    private LayoutElement layoutElement;

    [SerializeField]
    private int maxCharacter;

    [SerializeField]
    private RectTransform rectTransform;

    public void SetText(string content, string header = "")
    {
        if(header == "")
        {
            headerFiled.gameObject.SetActive(false);
            return;
        }

        headerFiled.gameObject.SetActive(true);
        headerFiled.text = header;

        contentFiled.text = content;

        int headerLength = headerFiled.text.Length;
        int contentLength = contentFiled.text.Length;

        layoutElement.enabled = (headerLength > maxCharacter || contentLength > maxCharacter);
    }

    private void Update()
    {
        Vector2 mousePosition = Input.mousePosition;

        float pivotX = mousePosition.x/Screen.width;
        float pivotY = mousePosition.y / Screen.height;

        rectTransform.pivot = new Vector2(pivotX, pivotY);  

        transform.position = mousePosition;
    }

}
