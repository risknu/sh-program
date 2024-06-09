using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HyperLinks : MonoBehaviour
{
    public void OpenURL(string urlString)
    {
        Application.OpenURL(urlString);
    }
}
