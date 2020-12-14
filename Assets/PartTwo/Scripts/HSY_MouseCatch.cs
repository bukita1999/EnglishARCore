using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HSY_MouseCatch : MonoBehaviour
{
    private Vector3 depth;
    private Vector3 offset;     //为了弥补点击开始的一瞬间产生的偏移量
    private void OnMouseDown()
    {
        depth = Camera.main.WorldToScreenPoint(transform.position);

        Vector3 mPosition = Input.mousePosition;
        mPosition = new Vector3(mPosition.x, mPosition.y, depth.z);
        offset = transform.position - Camera.main.ScreenToWorldPoint(mPosition);
    }

    private void OnMouseDrag()
    {
        Vector3 mPosition = Input.mousePosition;
        mPosition = new Vector3(mPosition.x, mPosition.y, depth.z);
        //transform.position = Camera.main.ScreenToWorldPoint(mPosition);
        transform.position = Camera.main.ScreenToWorldPoint(mPosition) + offset;
    }

}
