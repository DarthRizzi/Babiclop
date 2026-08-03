using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Opcional
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UtensilList(string nome)
    {
        Debug.Log($"Função test utensil ativada");
        switch (nome)
        {
            case "Utensil1":
                Debug.Log("Opção Utensil 1");
            break;

            case "Utensil2":
                Debug.Log("Opção Utensil 2");
            break;

            default:
                Debug.Log("Opção inválida");
            break;
        }
        
    }
}