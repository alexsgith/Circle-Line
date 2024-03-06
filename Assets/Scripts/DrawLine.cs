using UnityEngine;

public class DrawLine : MonoBehaviour
{
    [SerializeField] private float minLinePointSpace = .3f;
    private LineRenderer line;
    private Vector3 previousPosition;

    private void Start()
    {
        line = gameObject.GetComponent<LineRenderer>();
        line.positionCount = 0;
    }

    public void Raycast()
    {
        for (int i = 0; i < line.positionCount; i++)
        {
            var pos = line.GetPosition(i);
            RaycastHit2D hit = Physics2D.Raycast(pos ,Vector3.forward );
            if (hit)
            {
                var interactable = hit.collider.GetComponent<IInteractable>();
                interactable?.Interact();
            }
        }
        
        line.positionCount = 0;

    }

    public void Draw(Vector3 position)
    {
        if (Vector3.Distance(position , previousPosition) >= minLinePointSpace )
        {
            line.positionCount++;
            line.SetPosition(line.positionCount - 1, position);
            previousPosition = position;
        }
    }
}