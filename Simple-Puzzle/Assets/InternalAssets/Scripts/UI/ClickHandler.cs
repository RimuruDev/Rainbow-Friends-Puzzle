using UnityEngine;
using UnityEngine.EventSystems;

namespace RimuruDev
{
    public sealed class ClickHandler : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSource;

        private void Start()
        {
            EventTrigger eventTrigger;

            if (TryGetComponent<EventTrigger>(out var trigger))
                eventTrigger = trigger;
            else
                eventTrigger = gameObject.AddComponent<EventTrigger>().GetComponent<EventTrigger>();

            EventTrigger.Entry eventClick = new EventTrigger.Entry();

            eventClick.eventID = EventTriggerType.PointerClick;

            if (eventClick != null)
            {
                eventTrigger.triggers.Add(eventClick);

                eventClick.callback.AddListener((eventData) =>
                {
                    if (audioSource != null)
                        audioSource.Play();
                });
            }
        }
    }
}