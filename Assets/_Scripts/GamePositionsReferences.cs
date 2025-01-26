using UnityEngine;
using Capriccioso;

public class GamePositionsReferences : MonoBehaviour
{
    public Transform startPos;    
    public Player player;
    public static GamePositionsReferences Instance;

    public void Awake()
    {
        Instance = this;
    }
}
