using UnityEngine;

public class KBMInput : MonoBehaviour
{

    public GameObject player;


    private bool canInteract = false;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        if (canInteract)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                var ray = Camera.main.ScreenPointToRay(new Vector3( (Screen.width / 8) * 3, Screen.height / 2));
                RaycastHit hit;
                LayerMask mask = LayerMask.GetMask("Interactibles");

                if (Physics.Raycast(ray, out hit, 1000, mask))
                {
                    Debug.Log(hit.collider.gameObject.name+", "+hit.collider.gameObject.layer);
                    hit.collider.gameObject.GetComponent<ACTextPopup>().BroadcastMessage("OnPlayerInteract");
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape)) ACEvents.ReportOnPauseButtonPress();
    }

    void ToggleInteraction() => canInteract = !canInteract;

    private void OnEnable()
    {
        GlobalEvents.ToggleInteract += ToggleInteraction;
    }
    private void OnDisable()
    {
        GlobalEvents.ToggleInteract -= ToggleInteraction;
    }
}
