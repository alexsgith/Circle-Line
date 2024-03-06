using UnityEngine;

public class CircleManager : MonoBehaviour
{
    [SerializeField] private Circle circlePrefab;
    public int noOfCircles;

    public void Spawn()
    {
        float circleRadius = circlePrefab.GetComponent<CircleCollider2D>().radius;
        Vector3 screenWidth = Camera.main.ScreenToWorldPoint(new Vector3(0, Camera.main.pixelHeight, 0));

        int i = 0;
        while (i < noOfCircles)
        {
            Vector3 circlePosition = new (Random.Range(-screenWidth.x+1, screenWidth.x-1), Random.Range(-screenWidth.y+1, screenWidth.y-1));
            if (!Physics2D.OverlapCircle(circlePosition,circleRadius))
            {
                var obj = Instantiate(circlePrefab, circlePosition, Quaternion.identity, transform);
                var localPosition = obj.transform.localPosition; 
                localPosition = new Vector3(localPosition.x, localPosition.y, 0);
                obj.transform.localPosition = localPosition;
                GameManager.circles.Add(obj.gameObject);
                i++;
            }
        }
    }
}