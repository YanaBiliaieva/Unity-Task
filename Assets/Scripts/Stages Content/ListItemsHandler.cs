using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ListItemsHandler : MonoBehaviour
{
    [SerializeField] private Button addButton;
    [SerializeField] private Button deleteButton;
    [SerializeField] private Transform itemsList;

    private const string ContentPath = "Prefabs/Item";
    private Stack _itemStack = new Stack();

    void Start()
    {
        addButton.onClick.AddListener(AddItemToList);
        deleteButton.onClick.AddListener(RemoveItemFromList);
    }

    private void RemoveItemFromList()
    {
        if (_itemStack.Count == 0)
            return;

        var item = _itemStack.Peek();
        Destroy(item as GameObject);
        _itemStack.Pop();
    }

    private void AddItemToList()
    {
        var item = Instantiate(Resources.Load(ContentPath), itemsList) as GameObject;

        _itemStack.Push(item);
    }
}