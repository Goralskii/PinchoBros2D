using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GamePadUIControler : MonoBehaviour
{
    [Header("UI Buttons")]
    public Button pauseButton; // Asigna el bot�n de pausa HUD
    public Button exitButton;  // Asigna el bot�n de salir HUD
    public Button menuButton;  // Asigna el bot�n de menu HUD
    public Button EmpezarNivel; // Asigna el bot�n de Empezar NIvel

    [Header("Input Action Asset")]
    [SerializeField] private InputActionAsset inputActions; // Asigna el archivo de acciones

    private InputAction pauseAction;
    private InputAction exitAction;
    private InputAction menuAction;
    private InputAction EmpezarAction;

        private void OnEnable()
        {
            // Obtener las acciones desde el archivo de acciones
            pauseAction = inputActions.FindAction("Pausa");
            exitAction = inputActions.FindAction("Salir");
            menuAction = inputActions.FindAction("VolverAlMenu");
            EmpezarAction = inputActions.FindAction("MenuAyuda");

            // Vincular los callbacks
            pauseAction.performed += OnPausePressed;
            exitAction.performed += OnExitPressed;
            menuAction.performed += OnMenuPressed;
            EmpezarAction.performed += OnEmpNivel;

            // Activar las acciones
            pauseAction.Enable();
            exitAction.Enable();
            menuAction.Enable();
            EmpezarAction.Enable();
        }

        private void OnDisable()
        {
            // Desvincular los callbacks y desactivar las acciones
            pauseAction.performed -= OnPausePressed;
            exitAction.performed -= OnExitPressed;
            menuAction.performed -= OnMenuPressed;
            EmpezarAction.performed -= OnEmpNivel;

            pauseAction.Disable();
            exitAction.Disable();
            menuAction.Disable();
            EmpezarAction.Disable();

        }

        private void OnPausePressed(InputAction.CallbackContext context)
        {
            // Simular clic en el bot�n de pausa
            SimulateButtonClick(pauseButton);
        }

        private void OnExitPressed(InputAction.CallbackContext context)
        {
            // Simular clic en el bot�n de salir
            SimulateButtonClick(exitButton);
        }

        private void OnMenuPressed(InputAction.CallbackContext context)
        {
            SimulateButtonClick(menuButton);
        }

        private void OnEmpNivel(InputAction.CallbackContext context)
        {
            SimulateButtonClick(EmpezarNivel);
        }

    private void SimulateButtonClick(Button button)
    {
        if (button != null)
        {
            button.onClick.Invoke(); // Ejecutar la acci�n asignada al bot�n
        }
        else
        {
            Debug.LogWarning("No se asign� un bot�n para esta acci�n.");
        }
    }
}
