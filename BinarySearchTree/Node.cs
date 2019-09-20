using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
  class Node
  {
    public Node parent;
    public Node leftChild;
    public Node rightChild;
    public int data;

    public Node(int data)
    {
      this.data = data;
    }
  }
}
