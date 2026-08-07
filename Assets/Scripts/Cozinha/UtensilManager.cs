using UnityEngine;
using System.Collections;

public class UtensilManager : MonoBehaviour
{
    public int DelayToCook, IngredientID;
    [SerializeField] private bool InProgress;
    public void UseUtensil()
    {
        if(!InProgress)
        {
            InProgress = !InProgress;
            StartCoroutine(Delay(DelayToCook));
        }
        else
        {
            print("receita ainda em andamento");
        }
    }

    IEnumerator Delay(float time)
    {    
        print("inicio da receita");
        
        yield return new WaitForSeconds(time);

        Debug.Log($"Utilizado: {gameObject.name}");
        string nome = gameObject.name;

        GameManager.Instance.Ingredient[IngredientID] = true;
        InProgress = !InProgress;

        print("fim da receita");
        yield return null;
    }
   
}