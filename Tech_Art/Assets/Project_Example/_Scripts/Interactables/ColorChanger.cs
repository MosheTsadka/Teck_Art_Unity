using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour, IInteractable
{
    private List<Color> colors = new List<Color>();
    private Color RandomColor() => colors[Random.Range(0, colors.Count)];

    private SpriteRenderer sr;
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        colors.Add(Color.green);
        colors.Add(Color.red);
        colors.Add(Color.gray);
        colors.Add(Color.blue);
        colors.Add(Color.yellow);
    }
    public void Interact()
    {
        sr.color = RandomColor();
    }
}
