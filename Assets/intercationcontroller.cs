using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class intercationcontroller : MonoBehaviour
{
    [SerializeField] private InputActionReference interactionAction;

    [SerializeField] private GameObject intaractText;
    [SerializeField] public TextMeshProUGUI dialogue;

    private bool isPlayerInRange = false;

    private void OnEnable()
    {
        if (interactionAction != null)
        {
            interactionAction.action.Enable();
            interactionAction.action.performed += PerformInteraction;
        }

    }

    private void OnDisable()
    {
        if (interactionAction != null)
        {
            interactionAction.action.performed -= PerformInteraction;

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = true;
            intaractText.SetActive(true);
            Debug.Log("Presiona E para Interactuar");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = false;
            intaractText.SetActive(false);
            Debug.Log("Ya no estas en rango");
        }
    }
    private void PerformInteraction(InputAction.CallbackContext context)
    {
        if (isPlayerInRange)
        {
            Debug.Log("Interaccion con objeto");
            intaractText.SetActive(false);
            gameObject.SetActive(false);
            if(gameObject.tag == "Lampara 1")
                dialogue.text = "Econtraste una lampara rota";
            if (gameObject.tag == "Lampara 2")
                dialogue.text = "recoge otra lampara";
            if (gameObject.tag == "Lampara 3")
                dialogue.text = "recoge otra lampara";
        }
    }
}
