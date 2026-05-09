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

        
        if (data.CompareTo(_head.Data) < 0) 
        {
            newNode.Next = _head;
            _head.Previous = newNode;
            _head = newNode;
            return;
        }

        // Insert at the end
        if (data.CompareTo(_tail!.Data) > 0)
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
            if (data.CompareTo(current.Data) < 0)
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
}