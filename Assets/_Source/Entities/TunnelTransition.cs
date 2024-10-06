using GameData;
using Services;
using UnityEngine;

public class TunnelTransition : MonoBehaviour
{
    [SerializeField]
    private LayerMask _playerLayer;

    [SerializeField]
    private Transform _destination;

    private PlayerTransformService _playerTransformService;
    private InputService _input;

    private bool _canTeleport;
    private Transform _playerTransform;

    private void Start()
    {
        _playerTransformService =
            ServiceController_Game.ServiceLocator.GetService<PlayerTransformService>();
        _input = ServiceController_Game.ServiceLocator.GetService<InputService>();

        _playerTransform = _playerTransformService.GetPlayerTransform();
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
            _playerTransform.position = _destination.position;
        }
    }
}
