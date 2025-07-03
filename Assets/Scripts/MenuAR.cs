using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuAR : MonoBehaviour
{
    public void Back ()
    {
        SceneManager.LoadScene("MenuUtama");
    }
}
