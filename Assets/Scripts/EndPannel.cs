using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPannel : MonoBehaviour
{
    public GalleryButton GallBtn;
    private void OnEnable()
    {
        GallBtn.Setting();
    }
}
