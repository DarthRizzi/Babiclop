using UnityEngine;

public class UtensilManager : MonoBehaviour
{
    public void UseUtensil()
    {
        Debug.Log($"Utilizado: {gameObject.name}");
        string nome = gameObject.name;
        GameManager.Instance.UtensilList(nome);
    }
}