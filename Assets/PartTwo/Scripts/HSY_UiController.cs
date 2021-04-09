using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HSY_UiController : MonoBehaviour
{
    public Button buttonprefab;
    public Button button;
    public Transform canvas;
    public void DrawButton(GameObject item = null)
    {
        if (button == null)
        {
            button = Instantiate(buttonprefab);
            button.GetComponent<HSY_Button>().item = item;
            button.transform.SetParent(canvas);
        }
    }

    public void DestroyButton()
    {
        Destroy(button.gameObject);
        button = null;
    }

    void Start()
    {
#if UNITY_EDITOR
        DrawButton(null);
#endif
    }

}
