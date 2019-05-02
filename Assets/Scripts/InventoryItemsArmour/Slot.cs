using UnityEngine;
using UnityEngine.UI;

abstract public class Slot : MonoBehaviour
{
    protected ArmourPiece item;

    [SerializeField]
    protected Image icon;

    public ArmourPiece GetArmourPiece()
    {
        return item;
    }
}