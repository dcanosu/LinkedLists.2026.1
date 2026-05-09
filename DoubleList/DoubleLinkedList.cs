using Shared;

namespace DoubleList;

public class DoubleLinkedList<T> : ILinkedList<T> where T : IComparable<T>
{
    private Node<T>? _head;
    private Node<T>? _tail;

    public DoubleLinkedList()
    {
        _head = null;
        _tail = null;
    }

    public bool Contains(T data)
    {
        throw new NotImplementedException();
    }

    public void InsertAtBeginning(T data)
    {
        var newNode = new Node<T>(data);
        if (_head == null)
        {
            _head = newNode;
            _tail = newNode;
        }
        else
        {
            newNode.Next = _head;
            _head.Previous = newNode;
            _head = newNode;
        }
    }
    public void InsertAtEnding(T data)
    {
        var newNode = new Node<T>(data);
        if (_tail == null)
        {
            _head = newNode;
            _tail = newNode;
        }
        else
        {
            _tail.Next = newNode;
            newNode.Previous = _tail;
            _tail = newNode;
        }
    }

    public void InsertOrdered(T data)
    {
        var newNode = new Node<T>(data);
        if (_head == null)
        {
            _head = newNode;
            _tail = newNode;
            return;
        }

        
        if (data.CompareTo(_head.Data) <= 0) 
        {
            newNode.Next = _head;
            _head.Previous = newNode;
            _head = newNode;
            return;
        }

        // Insert at the end
        if (data.CompareTo(_tail!.Data) >= 0)
        {
            _tail.Next = newNode;
            newNode.Previous = _tail;
            _tail = newNode;
            return;
        }

        // Insert in the middle
        var current = _head;
        while (current != null)
        {
            if (data.CompareTo(current.Data) <= 0)
            {
                newNode.Next = current;
                newNode.Previous = current.Previous;
                current.Previous!.Next = newNode;
                current.Previous = newNode;
                return;
            }
            current = current.Next;
        }
    }

    public void Remove(T data)
    {
        var current = _head;
        while (current != null)
        {
            if (current.Data!.Equals(data))
            {
                if (current == _head) // Found at the head
                {
                    _head = _head.Next;
                    _head!.Previous = null;
                }
                else if (current == _tail) // Found at the tail
                {
                    _tail = _tail.Previous;
                    _tail!.Next = null;
                }
                else // Found in the middle
                {
                    current.Previous!.Next = current.Next;
                    current.Next!.Previous = current.Previous;
                }
                return;
            }
            current = current.Next;
        }
    }

    public void RemoveAll(T data)
    {
        throw new NotImplementedException();
    }

    public void Reverse()
    {
        throw new NotImplementedException();
    }

    public List<T> GetModes()
    {
        List<T> modes = new List<T>();

        if (_head == null)
        {
            return modes;
        }
        
        int Maxocurrences = 0;
        int currentOcurrences = 0;

        Node<T>? current = _head;
        T? lastValue = _head.Data;

        while (current != null)
        {
            // If the current value is the same as the last value, increment the occurrence count
            if (current.Data!.Equals(lastValue))
            {
                currentOcurrences++;
            }
            else
            {   // If the current value is different from the last value, check if the occurrence count of the last value is greater than the max occurrences found so far
                if (currentOcurrences > Maxocurrences)
                {
                    Maxocurrences = currentOcurrences;
                    modes.Clear();
                    modes.Add(lastValue!);
                }
                else if (currentOcurrences == Maxocurrences && Maxocurrences > 0)
                {
                    modes.Add(lastValue!);
                }
                // Reset the occurrence count for the new value
                lastValue = current.Data;
                currentOcurrences = 1;
            }
            current = current.Next;
        }
        // After the loop, we need to check the last value one more time in case it is the mode
        if (currentOcurrences > Maxocurrences)
        {
            modes.Clear();
            modes.Add(lastValue!);
        }
        else if (currentOcurrences == Maxocurrences && Maxocurrences > 0)
        {
            modes.Add(lastValue!);
        }
        return modes;
    }

    public void SortDescending()
    {
        // If the list is empty or has only one element, it's already sorted
        if (_head == null || _head.Next == null)
        {
            return;
        }

        Node<T>? current = _head;
        Node<T>? temp = null;

        // Traverse the list and swap next and previous pointers
        while (current != null)
        {
            // Swap the next and previous pointers
            temp = current.Previous;
            current.Previous = current.Next;
            current.Next = temp;

            // Move to the next node which is the previous node before swapping, the next node is 'current.Previous' after the swap
            current = current.Previous;
        }

        // Finally, adjust the head and tail pointers
        if (temp != null)        
        {
            _tail = _head;
            _head = temp.Previous;
        }
    }

    override public string ToString()
    {
        var current = _head;
        var result = string.Empty;
        while (current != null)
        {
            result += $"{current.Data} -> ";
            current = current.Next;
        }
        result += "null";
        return result;
    }

    public string ToStringReverse()
    {
        var current = _tail;
        var result = string.Empty;
        while (current != null)
        {
            result += $"{current.Data} -> ";
            current = current.Previous;
        }
        result += "null";
        return result;
    }

    public List<string> GetGraph()
    {
        // This method will create a graph representation of the list where each unique value is represented by a line of stars corresponding to its frequency in the list.
        List<string> graph = new List<string>();

        if (_head == null)
        {
            return graph;
        }

        Node<T>? current = _head;
        T? lastValue = _head.Data;
        int count = 0;

        while (current != null)
        {
            if (current.Data!.Equals(lastValue))
            {
                count++;
            }
            else
            {
                string stars = "";
                for (int i = 0; i < count; i++)
                {
                    stars += "*";
                }
                graph.Add($"{lastValue}: {stars}");

                lastValue = current.Data;
                count = 1;
            }
            current = current.Next;
        }
        // Print the last value
        string finalStarts = "";
        for (int i = 0; i < count; i++)        
        {
            finalStarts += "*";
        }
        graph.Add($"{lastValue}: {finalStarts}");
        return graph;
    }
}