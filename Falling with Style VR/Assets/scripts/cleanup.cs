using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cleanup : MonoBehaviour
{
    public void clean() {
        Destroy(transform.parent.gameObject);
    }
}
