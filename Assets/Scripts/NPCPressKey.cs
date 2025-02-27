using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCPressKey : MonoBehaviour
{
    public GameObject player;                // Referencia al jugador
    public GameObject targetObject;          // El objeto que quieres comprobar
    public float triggerDistance = 5f;       // Distancia m�nima para activar el evento
    public KeyCode activationKey = KeyCode.E; // Tecla que activar� el evento
    public Dialogue dialogue;                // El di�logo que quieres iniciar

    private DialogueManager dialogueManager; // El script que quieres llamar

    void Start()
    {
        if (targetObject != null)
        {
            dialogueManager = DialogueManager.Instance; // Usamos la instancia est�tica
        }
    }

    void Update()
    {
        if (player != null && targetObject != null && dialogueManager != null)
        {
            // Calcula la distancia entre el jugador y el objeto
            float distanceToTarget = Vector3.Distance(player.transform.position, targetObject.transform.position);

            // Comprueba si el jugador est� dentro de la distancia especificada y si ha presionado la tecla
            if (distanceToTarget <= triggerDistance && Input.GetKeyDown(activationKey))
            {
                // Llama al m�todo StartDialogue de DialogueManager
                if (!dialogueManager.isDialogueActive) // Solo iniciar di�logo si no est� ya activo
                {
                    dialogueManager.StartDialogue(dialogue);
                }
            }
        }
    }
}
