using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShotsCounter : MonoBehaviour
{
    public TextMesh text;

    public void SetShots(double shots) {
        text.text = shots.ToString("D");
    }
}
