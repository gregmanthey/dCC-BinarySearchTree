using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
  class BinarySearchTree
  {
    Node root;
    int count;
    int height;

    public int Height { get => height; }
    public int Count { get => count; }
    public BinarySearchTree()
    {
      count = 0;
      height = 0;
    }

    public void CreateTree()
    {
      Add(72);
      Add(42);
      Add(66);
      Add(30);
      Add(10);
      Add(24);
      Add(22);
      Add(16);
      Add(44);
      Add(12);
      Add(61);
      Add(83);
      Add(6);
      Add(35);
      Add(37);
      Add(55);
      Add(43);
      Add(89);
      Add(98);
      Add(13);
      Add(23);
      Add(32);
      Add(11);
      Add(25);
      Add(330);
    }

    public void Add(int data)
    {
      Node node = new Node(data);
      count++;
      if (root == null)
      {
        root = node;
        height++;
        return;
      }
      PlaceNode(root, node);
    }

    public void PlaceNode(Node current, Node newNode, int numberOfIterations = 0)
    {
      numberOfIterations++;
      if (newNode.data > current.data)
      {
        if (current.rightChild != null)
        {
          PlaceNode(current.rightChild, newNode, numberOfIterations);
        }
        else
        {
          UpdateHeight(numberOfIterations);
          current.rightChild = newNode;
          newNode.parent = current;
        }
      }
      else
      {
        if (current.leftChild != null)
        {
          PlaceNode(current.leftChild, newNode, numberOfIterations);
        }
        else
        {
          UpdateHeight(numberOfIterations);
          current.leftChild = newNode;
          newNode.parent = current;
        }
      }
    }

    public void Display()
    {
      if (root == null)
      {
        Console.WriteLine("Empty tree");
      }
      else
      {
        Display(root);
      }
    }
    public void Display(Node node)
    {
      if (node == null)
      {
        return;
      }

      Console.WriteLine(node.data);
      Display(node.leftChild);
      Display(node.rightChild);
    }

    public void InOrder()
    {
      if (root == null) return;
      InOrder(root);
    }
    public void InOrder(Node node)
    {
      if (node == null) return;
      InOrder(node.leftChild);
      Console.WriteLine(node.data);
      InOrder(node.rightChild);
    }
    public Node FindLeftmostNode(Node current)
    {
      if (current.leftChild == null)
      {
        return current;
      }
      return FindLeftmostNode(current.leftChild);
    }

    public void PostOrder()
    {
      if (root == null) return;
      Node startingNode = FindLeftmostNode(root);
      PrintParents(startingNode);
    }
    public void PreOrder()
    {
      if (root == null)
      {
        Console.WriteLine("Empty tree");
        return;
      }
      PrintLeftChildren(root);
    }
    public void PrintLeftChildren(Node current)
    {
      if (current == null)
      {
        return;
      }
      Console.WriteLine(current.data);
      PrintLeftChildren(current.leftChild);
    }

    public void PrintParents(Node current)
    {
      if (current == null) return;
      Console.WriteLine(current.data);
      PrintParents(current.parent);
    }

    public Node Search(int data)
    {
      if (root == null)
      {
        return null;
      }
      return Search(root, data);
    }
    public Node Search(Node current, int data)
    {
      if (data == current.data)
      {
        return current;
      }
      else if (data > current.data)
      {
        if (current.rightChild != null)
        {
          return Search(current.rightChild, data);
        }
        else
        {
          return null;
        }
      }
      else // data < current.data
      {
        if (current.leftChild != null)
        {
          return Search(current.leftChild, data);
        }
        else
        {
          return null;
        }
      }
    }
    private void UpdateHeight(int number)
    {
      if (number > height)
      {
        height = number;
      }
    }
  }
}
