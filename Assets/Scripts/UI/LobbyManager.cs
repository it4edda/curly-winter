using UnityEngine;

public class LobbyManager : MonoBehaviour
{
    [SerializeField] RectTransform viewPoint;
    public void MoveToPoint(RectTransform trans)
    {
        var a = trans.anchoredPosition * -Vector3.one;
        viewPoint.anchoredPosition = a;
    }
}
