using Entities;
using GameData;
using Services;
using UnityEngine;

public class TunnelTransition : MonoBehaviour
{
    [SerializeField]
    private LayerMask _playerLayer;

    [SerializeField]
    private Transform _destination;

    [SerializeField]
    private Player _player;

    private InputService _input;

    private bool _canTeleport;

    private void Start()
    {
        _input = ServiceController_Game.ServiceLocator.GetService<InputService>();
        _input.OnActivate += Activate;
    }

    private void OnDestroy()
    {
        _input.OnActivate -= Activate;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((_playerLayer & 1 << other.gameObject.layer) != 0)
        {
            _canTeleport = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if ((_playerLayer & 1 << other.gameObject.layer) != 0)
        {
            _canTeleport = false;
        }
    }

    private void Activate()
    {
        if (_canTeleport)
        {
            _player.transform.position = _destination.position;
        }
    }
}
