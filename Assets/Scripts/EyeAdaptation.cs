using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class EyeAdaptation : MonoBehaviour
{
    AutoExposure test;
    PostProcessVolume myvol;
    private void Awake()
    {
        myvol = GetComponent<PostProcessVolume>();
        myvol.profile.TryGetSettings(out test);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (myvol.isGlobal == false)
            {
                myvol.isGlobal = true;
            }
            else myvol.isGlobal = false;
        }
    }
}
