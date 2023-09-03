using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerStats))]
[RequireComponent(typeof(AbilitiesList))]
public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;

    [SerializeField] private Transform _spawnPoint;

    [SerializeField] private PlayerStats _playerStats;

    [SerializeField] private AbilitiesList _abilities;

    [SerializeField] private float _jumpForce;

    public PlayerStats Stats { get => _playerStats; }

    [SerializeField] private UnityEvent _dead;
    [SerializeField] private UnityEvent<GameObject> _abilityCollected;
    [SerializeField] private UnityEvent _abilityNotCollected;
    [SerializeField] private UnityEvent _passObstacle;

    public UnityEvent<GameObject> AbilityCollected { get => _abilityCollected; }
    public UnityEvent AbilityNotCollected { get => _abilityNotCollected; }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.velocity = Vector2.zero;
    }

    private void FixedUpdate()
    {
#if UNITY_ANDROID
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.position.x > Screen.width / 2)
            {
                _rigidbody.velocity = Vector2.zero;
                _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            }
        }
#endif

#if UNITY_EDITOR
        if (Input.GetKey(KeyCode.Space))
        {
            _rigidbody.velocity = Vector2.zero;
            _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
#endif
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent<Ability>(out Ability ability))
        {
            if (_abilities.TryAddAbility(collision.gameObject))
            {
                _abilityCollected?.Invoke(collision.gameObject);
            }
            else
            {
                _abilityNotCollected?.Invoke();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.parent.TryGetComponent<ObstacleSegment>(out ObstacleSegment obstacleSegment))
        {
            _passObstacle?.Invoke();
        }
    }

    public void Dead()
    {
        _dead?.Invoke();

        gameObject.SetActive(false);

        _playerStats.ShareFinalResultsOnDefeat();
        _playerStats.ResetStats();
    }

    public void ResetSlots()
    {
        _abilities.ResetAllSlots();
    }
}
