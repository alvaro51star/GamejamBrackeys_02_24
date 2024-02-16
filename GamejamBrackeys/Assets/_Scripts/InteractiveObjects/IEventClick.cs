using UnityEngine.EventSystems;
using UnityEngine;
using Unity.VisualScripting;

public interface IEventClick : IPointerDownHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        //poner aqui acciones por click
    }

    public void OnPointerUp  (PointerEventData eventData)
    {

    }

    public void OnPointerClick (PointerEventData eventData)
    {

    }

    public void OnPointerEnter(PointerEventData eventData)
    {

    }

    public void OnPointerExit(PointerEventData eventData)
    {

    }
}
