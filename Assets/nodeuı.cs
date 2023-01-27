using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nodeuı : MonoBehaviour
{
    private node target;

    public void settarget(node _target)
    {
        target = _target;
        transform.position = target.getbuildposition();
    }
}
