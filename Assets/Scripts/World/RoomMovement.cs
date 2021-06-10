using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RoomMovement : MonoBehaviour
{
    public Vector2 camreaChange;
    public Vector3 playerChange;
    private OwCameraMovement cam;

    public bool needText;

    public string placeName;
    public GameObject text;
    public TMP_Text textButton;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.GetComponent<OwCameraMovement>();
    }

    /// <summary>
    /// Moves the camera to the position in the variable as well as the player to it's own one.
    /// </summary>
    /// <param name="other">Player Collider</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            cam.minPosition += camreaChange;
            cam.maxPosition += camreaChange;
            other.transform.position += playerChange;

            if (needText)
            {
                StartCoroutine(placeNameCo());
            }
        }
    }

    /// <summary>
    /// Places a name on the sreen. The name is the "placeName" variable.
    /// </summary>
    /// <returns></returns>
    private IEnumerator placeNameCo()
    {
        text.SetActive(true);
        textButton.text = placeName;

        yield return new WaitForSeconds(4f);
        text.SetActive(false);
    }
}
