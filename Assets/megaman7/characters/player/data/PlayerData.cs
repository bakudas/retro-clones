using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Player/PlayerData", order = 1)]
public class PlayerData : ScriptableObject
{
    public float speed = 10;
    public float jumpSpeed = 10;
    public PlayerState currentState = PlayerState.idle;
    public PlayerState previousState = PlayerState.idle;
    public AnimationClip currentAnimation;
    public AnimationClip previousAnimation;
}

public enum PlayerState
{
    idle,
    run,
    shoot,
    hit,
    slide
}
