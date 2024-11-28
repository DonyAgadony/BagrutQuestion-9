using System.Dynamic;

public class Node<T> // <T> = generic
{
    private T value; // The value of the current cell

    private Node<T>? next; // Pointer to the next cell

    public Node(T value)
    {
        this.value = value;
        next = null;
    }

    public Node(T value, Node<T> next)
    {
        this.value = value;
        this.next = next;
    }

    public T GetValue()
    {
        return this.value;
    }

    public void SetValue(T value)
    {
        this.value = value;
    }

    public Node<T>? GetNext()
    {
        return this.next;
    }

    public void SetNext(Node<T>? next)
    {
        this.next = next;
    }

    public bool HasNext()
    {
        return next != null;
    }

    public override string ToString()
    {
        return value!.ToString()!;
    }
}

public static class ListOperations
{
    public static void AddToTail<T>(Node<T>? head, T newvalue)
    {
        if (head == null) throw new ArgumentNullException("Head can't be null value.");

        while (head!.HasNext())
        {
            head = head.GetNext();
        }

        head.SetNext(new Node<T>(newvalue));
    }

    public static string ToString<T>(Node<T>? head)
    {
        string result = "";

        while (head != null)
        {
            result += head.ToString() + ", ";
            head = head.GetNext();
        }

        return result;
    }

    public static int GetLength<T>(Node<T>? head)
    {
        int len = 0;

        while (head != null)
        {
            len++;
            head = head.GetNext();
        }

        return len;
    }

    public static bool Contains<T>(Node<T>? head, T value)
    {
        while (head != null)
        {
            if (head.GetValue()!.Equals(value))
            {
                return true;
            }

            head = head.GetNext();
        }

        return false;
    }

    public static int GetMax(Node<int>? head)
    {
        int max = int.MinValue;
        while (head != null)
        {
            if (head.GetValue() > max)
            {
                max = head.GetValue();
            }
            head = head.GetNext();
        }
        return max;
    }

    public static void Insert<T>(Node<T>? head, T value, int index)
    {
        for (; index > 1; index--)
        {
            head = head!.GetNext();
        }
        var temp = new Node<T>(value);
        temp.SetNext(head!.GetNext());
        head.SetNext(temp);
    }
}
class Program
{
    public static void Main()
    {
        Node<int> first = new(1);
        Node<int> second = new(3);
        Node<int> third = new(5);
        Node<int> fourth = new(3);
        Node<int> fifth = new(9);
        Node<int> sixth = new(4);
        first.SetNext(second);
        second.SetNext(third);
        third.SetNext(fourth);
        fourth.SetNext(fifth);
        fifth.SetNext(sixth);
        guess(first);
    }
    public static Node<int> RemoveInstance(Node<int> first, int x)
    {
        if (first == null)
        {
            return null!;
        }
        Node<int> temp = RemoveInstance(first.GetNext()!, x);
        if (first.GetValue() == x)
        {
            return temp;
        }
        first.SetNext(temp);
        return first;
    }

    public static void guess(Node<int> first)
    {
        if (first != null)
        {
            Node<int> temp = RemoveInstance(first.GetNext()!, first.GetValue());
            first.SetNext(temp);
            guess(first.GetNext()!);
            ListOperations.ToString(first);
        }
    }
}