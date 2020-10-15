using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Themes/ThemeConfig")]
public class Theme : ScriptableObject
{
    [SerializeField] public string color1_name;
    [SerializeField] public string color1_color;
    [SerializeField] public string color2_name;
    [SerializeField] public string color2_color;
    [SerializeField] public string color3_name;
    [SerializeField] public string color3_color;
    [SerializeField] public string color4_name;
    [SerializeField] public string color4_color;
    [SerializeField] public string color5_name;
    [SerializeField] public string color5_color;
}
