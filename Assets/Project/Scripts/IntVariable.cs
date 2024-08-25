using UnityEngine;
using UnityEngine.Events;

// Это довольно неоднозначный подход. Здесь нет выделенного процесса инициализации и единой точки входа, однако, хотя никто не запрещает её реализовать.
// Однако, благодаря тому что состояние выделено в ассеты, их можно закинуть в префабы, избавляясь от лишних проблем с прокидыванием зависимостей   
// Кроме того, приходится множество вещей проставлять в редакторе, что можно расценивать и как удобный инструмент для дизайнера,
// и как минус, так как это занимает время. Однако, иногда, исправить ошибку без редактирования кода приятно.
[CreateAssetMenu]
public class IntVariable : ScriptableObject
{
    [SerializeField] private int value;

    public UnityEvent OnChange { get; } = new();

    public int GetValue()
    {
        return value;
    }

    public void ApplyChange(int amount)
    {
        if (amount == 0) return;
        value += amount;
        OnChange.Invoke();
    }

    public void SetValue(int newValue)
    {
        if (value == newValue) return;
        value = newValue;
        OnChange.Invoke();
    }
}