using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;    
    [SerializeField] private AudioSource wingSound;
    [SerializeField] private Sprite[] _birdSprites;
    [SerializeField] private float _birdStrength = 5f;
    [SerializeField] private float _birdGravity = -9.81f;
    [SerializeField] private float _birdTilt = 5f;

    private int spriteIndex;
    private Vector3 direction;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
    }

    private void OnEnable()
    {
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        direction = Vector3.zero;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
            direction = Vector3.up * _birdStrength;
            wingSound.Play();
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            wingSound.Play();

            if (touch.phase == TouchPhase.Began)
            {
                direction = Vector3.up * _birdStrength;
            }
        }
        direction.y += _birdGravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;

        Vector3 rotation = transform.eulerAngles;
        rotation.z = direction.y * _birdTilt;
        transform.eulerAngles = rotation;
    }

    private void AnimateSprite()
    {
        spriteIndex++;

        if (spriteIndex >= _birdSprites.Length) {
            spriteIndex = 0;
        }

        if (spriteIndex < _birdSprites.Length && spriteIndex >= 0) {
            spriteRenderer.sprite = _birdSprites[spriteIndex];
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Obstacle")) {
            FindObjectOfType<GameManager>().GameOver();
        } else if (other.gameObject.CompareTag("Scoring")) {
            FindObjectOfType<GameManager>().IncreaseScore();
        }
    }

}
