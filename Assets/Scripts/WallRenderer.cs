using UnityEngine;

public class WallRenderer : MonoBehaviour
{
    public GameObject Parent1;
    public GameObject Parent2;

    private void Start()
    {
        transform.rotation.SetFromToRotation(Parent1.transform.position, Parent2.transform.position);
        transform.localScale = new Vector3(
            Parent1.transform.localScale.x * transform.localScale.x,
            Parent1.transform.localScale.x * transform.localScale.y,
           Parent1.transform.localScale.x * transform.localScale.z);

        if(transform.localScale.x >= 1)
            GetComponent<MeshRenderer>().material.color = Color.red;
    }

    private void Update()
    {
        transform.position = GetCenter(Parent1.transform.position, Parent2.transform.position);
    }

    private Vector3 GetCenter(Vector3 a, Vector3 b)
    {
        return (a + b) * 0.5f;
    }
}
