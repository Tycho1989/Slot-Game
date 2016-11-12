using UnityEngine;
using System.Xml.Serialization;
using System.IO;
using UnityEngine.UI;

public class AppUtility
{
    /// <summary>
    /// 获取UI在canvas分辨率下的坐标
    /// </summary>
    public static Vector2 GetUICanvasPos(Canvas canvas, Camera mainCamera, GameObject UI)
    {
        Vector2 localPosition = Vector2.zero;
        if (canvas.renderMode == RenderMode.ScreenSpaceOverlay || canvas.renderMode == RenderMode.ScreenSpaceCamera)
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                        canvas.transform as RectTransform, mainCamera.WorldToScreenPoint(UI.transform.position),
                        canvas.worldCamera, out localPosition);
            return localPosition;
        }
        else if (canvas.renderMode == RenderMode.WorldSpace)
        {
            Debug.Log(string.Format("The canvas's renderMode is not [ScreenSpaceOverlay] or [ScreenSpaceCamera]"));
        }
        return localPosition;
    }

    /// <summary>
    /// 获取UI在屏幕坐标
    /// </summary>
    public static Vector2 GetUIScreenPos(Canvas canvas, Camera mainCamera, GameObject UI)
    {
        Vector2 canvasPos = GetUICanvasPos(canvas, mainCamera, UI);
        Rect rect = canvas.GetComponent<RectTransform>().rect;
        Vector2 resolution = new Vector2(rect.width,rect.height);
        Vector2 screenPos = new Vector2(canvasPos.x / resolution.x * Screen.width + Screen.width / 2, canvasPos.y / resolution.y * Screen.height + Screen.height / 2);
        return screenPos;
    }
}
