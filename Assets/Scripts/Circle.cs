using UnityEngine;

public class Circle : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        GameManager.circles.Remove(gameObject);
        Destroy(gameObject);
    }
}

public interface IInteractable
{
    public void Interact();
}
