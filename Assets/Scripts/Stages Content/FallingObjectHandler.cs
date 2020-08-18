using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class FallingObjectHandler : MonoBehaviour
{
    [SerializeField] private Renderer figureRenderer;
    [SerializeField] private MeshFilter meshFilter;
    [SerializeField] private ParticleSystem particlesSystem;
    public event Action<GameObject> NotifyOnDestroyed;
    private const float Speed = 1.1f;
    private const float RotationSpeed = 0.5f;
    private Quaternion _rotation;
    private Color _randomColor;
    private bool _startExplosion;
    
    private void Start()
    {
        _rotation = Random.rotation;
        _randomColor = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f, 1f, 1f);
        
        //set the random color for figure and to its particle system material
        if (figureRenderer)
            figureRenderer.material.color = _randomColor;

        if (particlesSystem)
        {
            var particlesRenderer = particlesSystem.GetComponent<ParticleSystemRenderer>();
            if (particlesRenderer)
            {
                //set the same mesh to particles as the figure has
                particlesRenderer.mesh = meshFilter.mesh;
                particlesRenderer.material.color = _randomColor;
            }
        }
    }

    private void Update()
    {
        if (_startExplosion)
            return;

        transform.Rotate(RotationSpeed * Time.deltaTime * _rotation.eulerAngles, Space.Self);

        float step = Speed * Time.deltaTime;

        transform.position += Vector3.down * step;

        var downPosition = new Vector2(transform.position.x, CameraHelper.bottomOffsetY);
        float distance = Vector2.Distance(downPosition, transform.position);
        
        //when the figure reaches bottom part of the screen it destroys
        if (distance <= 0.1f)
        {
            Explode();
        }
    }

    private void OnMouseDown()
    {
        if (_startExplosion)
            return;

        Explode();
    }

    private void Explode()
    {
        _startExplosion = true;
        figureRenderer.enabled = false;

        ShowExplosion();
    }

    private void ShowExplosion()
    {
        //after the end of the play, the particle system destroys the gameobject
        particlesSystem.Play();
    }

    private void OnDestroy()
    {
        NotifyOnDestroyed?.Invoke(gameObject);
    }
}