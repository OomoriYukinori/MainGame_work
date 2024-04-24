using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statepatans : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
public interface IPlayerState
{
    IPlayerState Jump(PlayerMove player);
    IPlayerState Update(PlayerMove player);
}

public class IdleState : IPlayerState
{
    public IPlayerState Jump(PlayerMove player)
    {
        player.animator.SetBool("Rest", true);
        return new RestState();
    }
    public IPlayerState Update(PlayerMove player)
    {
        if (Mathf.Abs(player.vertical) > 0.1f)
        {
            return new MovingState();
        }
        return this;
    }
}
public class MovingState : IPlayerState
{
    public IPlayerState Jump(PlayerMove player)
    {
        if (!player.animator.IsInTransition(0))
        {
            player.Jump();
            return new JumpState();
        }
        return this;
    }
    public IPlayerState Update(PlayerMove player)
    {
        return this;
    }
}
public class JumpState : IPlayerState
{
    public IPlayerState Jump(PlayerMove player)
    {
        return this;
    }
    public IPlayerState Update(PlayerMove player)
    {
        if (!player.animator.IsInTransition(0))
        {
            player.animator.SetBool("Jump", false);
        }
        if (player.currentBaseState.IsName("Base Layer.Jump"))
        {
            return this;
        }
        return new MovingState();
    }
}
public class RestState : IPlayerState
{
    public IPlayerState Jump(PlayerMove player)
    {
        return this;
    }
    public IPlayerState Update(PlayerMove player)
    {
        if (!player.animator.IsInTransition(0))
        {
            player.animator.SetBool("Rest", false);
        }
        if (player.currentBaseState.IsName("Base Layer.Rest"))
        {
            return this;
        }
        return new IdleState();
    }
}


