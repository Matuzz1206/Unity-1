using UnityEngine;

public class ChainVisual : MonoBehaviour
{
    public Transform otherPlayer;
    private LineRenderer line;

    void Start()
    {
        line = GetComponent<LineRenderer>();
    }

    void Update()
    {
        if (line == null || otherPlayer == null)
            return;

        line.SetPosition(0, transform.position);
        line.SetPosition(1, otherPlayer.position);
    }
}