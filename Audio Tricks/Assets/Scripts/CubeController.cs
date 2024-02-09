using System.Collections;
using UnityEngine;

public class CubeController : MonoBehaviour
{
  [SerializeField]
  private GameObject projectilePrefab;
  [SerializeField]
  private AudioClip shootSound;
  [SerializeField]
  private float shootInterval = 1.0f;
  [SerializeField]
  private float projectileSpeed = 500.0f;
  [SerializeField]
  private bool useRandomPitch = false;
  [SerializeField]
  private float minPitch = 0.5f;
  [SerializeField]
  private float maxPitch = 1.5f;
  private AudioSource _audioSource;

  void Start()
  {
    _audioSource = GetComponent<AudioSource>();
    if (_audioSource == null)
    {
      _audioSource = gameObject.AddComponent<AudioSource>();
    }
    StartCoroutine(ShootProjectile());
  }

  public void ToggleRandomPitch()
  {
    useRandomPitch = !useRandomPitch;
  }

  IEnumerator ShootProjectile()
  {
    while (true)
    {
      GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
      projectile.GetComponent<Rigidbody>().AddForce(transform.forward * projectileSpeed);

      if (shootSound != null)
      {
        if (useRandomPitch)
        {
          _audioSource.pitch = useRandomPitch ? Random.Range(minPitch, maxPitch) : 1.0f;
        }
        _audioSource.PlayOneShot(shootSound);
      }

      yield return new WaitForSeconds(shootInterval);
    }
  }
}