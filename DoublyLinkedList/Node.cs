namespace Struct.DoublyLinkedList;

public class Node
{
    public int Data { get; set; }
    public Node? Prev { get; set; }
    public Node? Next { get; set; }
    /*
Initializes a new instance of the Node class with the specified data.
Parameters:
   data:
       The data value to assign to the node.
*/
    public Node(int data)
    {
        Data = data;
        Prev = null;
        Next = null;
    }
}