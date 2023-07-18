using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody _ballRB;
    private TrailRenderer _ballTrail;
    private Coroutine _jumpCoroutine;
    private float _jumpForce = 0.3f;
    private Vector3 _ballStartPosition;
    private bool _fewerCollisionAccess = false;


    private void Start()
    {
        _ballRB = GetComponent<Rigidbody>();
        _ballTrail = GetComponent<TrailRenderer>();
        _ballStartPosition = transform.position;
        GameEvents.Instance.OnLevelStarted += RespawnBall;
        GameEvents.Instance.OnLevelRestarted += RespawnBall;
        GameEvents.Instance.OnNextLevel += RespawnBall;
        GameEvents.Instance.OnFewerMode += CheckTrail;
        GameEvents.Instance.OnFewerMode += SetFewerCollision;
    }


    private void OnDestroy()
    {
        GameEvents.Instance.OnLevelRestarted -= RespawnBall;
        GameEvents.Instance.OnNextLevel -= RespawnBall;
        GameEvents.Instance.OnLevelStarted -= RespawnBall;
        GameEvents.Instance.OnFewerMode -= CheckTrail;
        GameEvents.Instance.OnFewerMode -= SetFewerCollision;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_fewerCollisionAccess)
        {
            Destroy(collision.transform.parent.gameObject);
            _fewerCollisionAccess = false;
        }
        PassageSector.completedPassageCount = 0;
        if (_jumpCoroutine == null)
        {
            StartCoroutine(Jump());
        }
    }

    /* #if UNITY_EDITOR
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                Debug.Log(_ballStartPosition);
            }

            if(Input.GetKeyDown(KeyCode.G))
            {
                transform.position = _ballStartPosition;
            }
        }
    #endif */

    private IEnumerator Jump()
    {
        var ballStartPos = transform.position;
        _ballRB.useGravity = false;
        for (float t = 0; t < 1; t += Time.deltaTime / _jumpForce)
        {
            transform.position = Vector3.Lerp(ballStartPos, ballStartPos + new Vector3(0f, 0.5f, 0f), t);
            yield return null;
        }
        _ballRB.useGravity = true;
        _jumpCoroutine = null;
    }

    private void RespawnBall()
    {
        this.SetInactive();
        transform.position = _ballStartPosition;
        _ballRB.useGravity = true;
        this.SetActive();
    }

    private void CheckTrail(bool active)
    {
        if (active)
        {
            FewerModeTrailColor();
        }
        else
        {
            SetDefaulTrailColor();
        }
    }

    private void SetFewerCollision(bool active)
    {
        _fewerCollisionAccess = true;
    }

    private void FewerModeTrailColor()
    {
        Debug.Log("We are in fewer mode");
        _ballTrail.startColor = Color.red;
    }

    private void SetDefaulTrailColor()
    {
        _ballTrail.startColor = Color.yellow;
    }

}
