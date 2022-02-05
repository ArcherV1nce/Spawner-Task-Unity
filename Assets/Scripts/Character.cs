using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField] private int _gold;

    public string Name => _name;
    public int Gold => _gold;
}
