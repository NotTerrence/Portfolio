using UnityEngine;

public class Platform : MonoBehaviour
{
    [Header("Platform Color")]
    public Color hoverColor;
    public Color clickColor;
    public Color platformColor;

    private Renderer rend;
    private Color startColor;

    private Vector3 positionOffset;
    private GameObject turret;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    void OnMouseEnter()
    {
        rend.material.color = hoverColor;
    }

    void OnMouseDown()
    {
        positionOffset = new Vector3(0f, 0.058f, 0f);
        rend.material.color = clickColor;
        if (turret != null)
        {
            Debug.Log("Can't build there!");
            rend.material.color = Color.black;
            return;
        }
        GameObject turrettoBuild = BuildManager.Instance.getTurrettoBuild();
        Quaternion rotationOffset = Quaternion.AngleAxis(90f, Vector3.left);
        turret = (GameObject) Instantiate(turrettoBuild, transform.position + positionOffset, rotationOffset);
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }

    void Update()
    {
        if (turret != null)
            rend.material.color = platformColor;
    }
}
