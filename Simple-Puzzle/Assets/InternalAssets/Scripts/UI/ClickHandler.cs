using UnityEngine;
using UnityEngine.EventSystems;

namespace RimuruDev
{
    public sealed class ClickHandler : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSource;

        private void Start()
        {
            EventTrigger eventTrigger = GetComponent<EventTrigger>();
            EventTrigger.Entry eventClick = new EventTrigger.Entry();

            eventClick.eventID = EventTriggerType.PointerClick;
            eventTrigger.triggers.Add(eventClick);

            eventClick.callback.AddListener((eventData) => { audioSource.Play(); });
        }
    }
}