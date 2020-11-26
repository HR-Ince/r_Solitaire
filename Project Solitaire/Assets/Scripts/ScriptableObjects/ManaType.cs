using UnityEngine;

[CreateAssetMenu(fileName = "New Mana Type", menuName = "Variable/Mana Type")]
public class ManaType : ScriptableObject
{
    [SerializeField] Sprite sprite = null;
    [Min(0)] public int amount = 0;

    private void OnEnable()
    { amount = 0; }
}
