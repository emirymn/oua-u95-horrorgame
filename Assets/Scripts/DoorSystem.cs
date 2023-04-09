using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoorSystem : MonoBehaviour
{
    [SerializeField] GameObject doorOne, doorTwo;
    [SerializeField] enum DoorType { swipe, DoubleClassic, Classic, balcoon, cantOpen }
    [SerializeField] private DoorType doorType;
    public enum IsLocked { noLock, clasicLock, PasswordLock }
    public IsLocked isLocked;
    private float close, open;
    bool canOpen, isClosed, isOpened, isUnlocked;

    private void Awake()
    {
        isClosed = true;
        isOpened = false;
        canOpen = false;
        close = doorOne.transform.position.x - 0.7f;
        open = doorOne.transform.position.x;
    }

    private void Update()
    {
        switch (doorType)
        {
            case DoorType.swipe:
                {
                    if (Input.GetKeyUp(KeyCode.E) && canOpen)
                    {
                        if (isClosed)
                        {
                            isClosed = false;
                            isOpened = true;
                            doorOne.transform.DOKill(false);
                            doorOne.transform.DOMoveX(close, 0.5f);

                        }
                        else if (isOpened)
                        {

                            isOpened = false;
                            isClosed = true;
                            doorOne.transform.DOKill(false);
                            doorOne.transform.DOMoveX(open, 0.5f);

                        }
                    }
                    break;
                }
            case DoorType.DoubleClassic:
                {
                    if (Input.GetKeyUp(KeyCode.E) && canOpen)
                    {
                        if (isLocked != IsLocked.clasicLock && doorType != DoorType.cantOpen)
                        {
                            if (isClosed)
                            {
                                isClosed = false;
                                isOpened = true;
                                doorOne.transform.DOKill(false);
                                doorTwo.transform.DOKill(false);
                                doorOne.transform.DORotate(new Vector3(0, 90f, 0), 0.5f);
                                doorTwo.transform.DORotate(new Vector3(0, 90f, 0), 0.5f);

                            }
                            else if (isOpened)
                            {
                                isOpened = false;
                                isClosed = true;
                                doorOne.transform.DOKill(false);
                                doorTwo.transform.DOKill(false);
                                doorOne.transform.DORotate(Vector3.zero, 0.5f);
                                doorTwo.transform.DORotate(Vector3.zero, 0.5f);

                            }
                        }
                    }
                    break;
                }

            case DoorType.Classic:
                {
                    if (Input.GetKeyUp(KeyCode.E) && canOpen)
                    {
                        if (isLocked == IsLocked.clasicLock)
                        {
                            if (GameManager.instance.lockDoors[GetComponent<DoorLock>().numberOf])
                            {
                                ClassicDoorOpenClose();
                            }
                        }
                        else
                        {
                            ClassicDoorOpenClose();
                        }
                    }
                    break;
                }
            case DoorType.balcoon:
                {
                    if (Input.GetKeyUp(KeyCode.E) && canOpen)
                    {
                        if (isLocked != IsLocked.clasicLock)
                        {
                            if (isClosed)
                            {
                                isClosed = false;
                                isOpened = true;
                                doorOne.transform.DOKill(false);
                                doorOne.transform.DORotate(new Vector3(0, 90f, 0), 0.5f);
                            }
                            else if (isOpened)
                            {
                                isOpened = false;
                                isClosed = true;
                                doorOne.transform.DOKill(false);
                                doorOne.transform.DORotate(new Vector3(0, 180f, 0), 0.5f);
                            }
                        }
                    }
                    break;
                }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("GameController"))
        {
            if (isLocked == IsLocked.clasicLock)
            {
                if (GetComponent<DoorLock>() != null)
                {
                    if (!GameManager.instance.lockDoors[GetComponent<DoorLock>().numberOf])
                    {
                        UIController.instance.AlertUI(UIController.instance.alertImg);
                    }
                }
            }
            if (doorType == DoorType.cantOpen)
            {
                UIController.instance.AlertUI(UIController.instance.alertImg);
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("GameController"))
        {
            canOpen = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("GameController"))
        {
            UIController.instance.AlertClose(UIController.instance.alertImg);
            canOpen = false;
        }
    }
    private void ClassicDoorOpenClose()
    {
        if (isClosed)
        {
            isClosed = false;
            isOpened = true;
            doorOne.transform.DOKill(false);
            doorOne.transform.DORotate(new Vector3(0, 90f, 0), 0.5f);
        }
        else if (isOpened)
        {
            isOpened = false;
            isClosed = true;
            doorOne.transform.DOKill(false);
            doorOne.transform.DORotate(Vector3.zero, 0.5f);
        }
    }
}


