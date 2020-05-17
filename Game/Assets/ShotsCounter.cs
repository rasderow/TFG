using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShotsCounter : MonoBehaviour
{
    public Text text;

    public void SetShots(double shots) {
        if (shots == double.PositiveInfinity) {
            text.text = "\u221E";
            text.transform.localScale = new Vector3(2, 2, 0);
            //text.text = "Inf";
        }
        else {
            text.text = shots.ToString();
            text.transform.localScale = new Vector3(1, 1, 0);
        }
    }
}
