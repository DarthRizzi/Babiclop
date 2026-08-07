using UnityEngine;
using System.Linq;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [Header("Inventário do Player")]
    [SerializeField] public bool[] Ingredient;
    [SerializeField] public bool[] Request;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
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
            case "TableTEST":
                Debug.Log("Opção TableTEST");
                CheckRecipe();
            break;

            default:
                Debug.Log("Opção inválida");
            break;
        }
        
    }

    public void CheckRecipe()
    {   
        bool CheckRecipeBool;
        CheckRecipeBool = Ingredient.OrderBy(x => x).SequenceEqual(Request.OrderBy(x => x));

        if(CheckRecipeBool)
        {
            print("receita certa");

            for (int i = 0; i < Ingredient.Length; i++)
            {
                Ingredient[i] = false;
            }
        }
        else
        {
            print("receita errada");

            for (int i = 0; i < Ingredient.Length; i++)
            {
                Ingredient[i] = false;
            }
        }
        
    }
}