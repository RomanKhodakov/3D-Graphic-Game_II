using UnityEngine;


public class HPGUI : MonoBehaviour
{
    public GUISkin test;

#if UNITY_EDITOR
    void OnGUI()
    {
        GUI.Box(new Rect(0, 0, 50, 25), "HP");
        GUI.skin = test;
        GUI.Box(new Rect(50, 0, 50, 25), "");
    }
#endif
}
