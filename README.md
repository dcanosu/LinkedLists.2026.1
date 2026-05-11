# Workshop #5 - Data Structures: Doubly Linked Lists

This project implements a generic Doubly Linked List in C# that fulfills the requirements for Workshop #5. The structure is designed to store any comparable data type and manages nodes using dual pointers (`Next` and `Previous`).

## Implemented Requirements

1.  **Ordered Insertion**: Elements are automatically inserted following an ascending order.
2.  **Traversals**: Visualization of the list in both forward (Head to Tail) and backward (Tail to Head) directions.
3.  **Physical Reversal**: The descending sort method physically modifies the node pointers to reverse the list's order.
4.  **Data Analysis**:
    * Calculation of the mode(s) (most frequent elements).
    * Generation of a frequency graph using asterisks.
5.  **Search and Deletion**:
    * Existence check (Contains).
    * Removal of the first occurrence of a value.
    * Removal of all occurrences of a value.

## Project Structure

* `Node<T>`: Class defining the dual-link node.
* `DoubleLinkedList<T>`: Main class containing the data structure logic.
* `Program.cs`: Interactive CLI menu for testing all functionalities.

## Technical Notes

* **Generics**: The class uses `<T>` where `T` must implement `IComparable<T>` to allow sorting and ordered insertion.
* **Memory Management**: All deletions and insertions carefully update the `Previous` and `Next` references to maintain list integrity.

---