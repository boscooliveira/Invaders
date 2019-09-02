using Assets.Source.Models.Game.Actors;
using UnityEngine;

public class Rock : MonoBehaviour, IRock
{
    public bool IsDestroyed => false;

    public event DestroyedDelegate ObjectDestroyed;

    public void Destroy()
    {
        ObjectDestroyed?.Invoke(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
