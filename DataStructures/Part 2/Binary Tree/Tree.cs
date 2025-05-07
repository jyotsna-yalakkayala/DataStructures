using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Part_2.Binary_Tree
{
    public class Tree
    {

        private Node root;
        private class Node {
            public int Value { get; set; }
            public Node leftChild { get; set; }
            public Node rightChild { get; set; }

            public Node(int Value)
            {
                this.Value = Value;
            }
        }
        private void insert(int value) {
            if (root == null) { 
                root = new Node(value);
                return;
            }

            var current = root;

            while (true) {
                if (value < root.Value)
                {
                    if (root.leftChild == null) {
                        root.leftChild = new Node(value);
                        break;
                    }

                    current = root.leftChild;
                }
                else {
                    if (root.rightChild == null) {
                        root.rightChild = new Node(value);
                        break;
                    }

                    current = root.rightChild;
                }
            }
        }

        private bool find(int value) { 
            var current = root;

            while (current != null) {
                if (value < root.Value)
                    current = current.leftChild;
                else if (value > root.Value)
                    current = current.rightChild;
                else
                    return true;
            }

            throw new Exception("The node doesn't exist in the current tree");
        }

        private void traversePreOder(Node root) {
            if (root == null)
                return;

            Console.WriteLine(root.Value);
            traversePreOder(root.leftChild!);
            traversePreOder(root.rightChild!);
        }

        private void traverseInOrder(Node root) { 
            if(root ==  null)
                return;

            traverseInOrder(root.leftChild!);
            Console.WriteLine(root.Value);
            traverseInOrder(root.rightChild!);
        }

        private void traversePostOrder(Node root) { 
            if( root == null)
                return;

            traversePostOrder(root.leftChild!);
            traversePostOrder(root.rightChild!);
            Console.WriteLine(root.Value);
        }

        private int Height(Node node) {
            if(IsLeafNode(node))
                return 0;

            return 1 + Math.Max(Height(node.leftChild!), Height(node.rightChild!));
        }

        private int MinInBinaryTree(Node root) {
            if (IsLeafNode(root))
                return root.Value;

            var left = MinInBinaryTree(root.leftChild!);
            var right =  MinInBinaryTree(root.rightChild!);

            return Math.Min( root.Value ,Math.Min(left, right));
        }

        private int MinInBinarySearchTreeRecursive(Node root) {
            if (root == null)
                throw new ArgumentNullException(nameof(root));

            if(root.leftChild == null)
                return root.Value;

            return MinInBinarySearchTree(root.leftChild!);
        }

        private int MinInBinarySearchTree(Node root) {
            while (root.leftChild != null) { 
                root = root.leftChild;
            }
            return root.Value;
        }

        private bool IsLeafNode(Node node) { 
            return node.leftChild == null && node.rightChild == null;
        }

        private bool Equals(Tree other) { 
            if(other == null)
                return false;

            return equals(other.root, root);
        }

        private bool equals(Node first, Node second) {
            if (first == null && second == null)
                return true;

            if (first != null && second != null)
                return (first.Value == second.Value) &&
                    equals(first.leftChild, second.leftChild) &&
                    equals(first.rightChild, second.rightChild);

            return false;
        }

        private bool isBinarySearchTree(Node root, int min, int max) {
            if (root == null)
                return true;

            if(root.Value < min || root.Value > max)    
                return false;

            return isBinarySearchTree(root.leftChild, min, root.Value - 1) &&
                isBinarySearchTree(root.rightChild, root.Value + 1, max);
        }

        public List<int> GetNodesAtDistance(int distance) { 
            var list = new List<int>();
            GetNodesAtDistance(root, distance, list);
            return list;
        }

        private void GetNodesAtDistance(Node root, int distance, List<int> list) { 
            if(root == null)
                return;

            if (distance == 0) {
                list.Add(root.Value);
                return;
            }

            GetNodesAtDistance(root.leftChild, distance - 1, list);
            GetNodesAtDistance(root.rightChild, distance - 1, list);
        }

        private List<int> LevelOrderTraversal() { 
            var list = new List<int>();

            for (int i = 0; i < Height(root); i++) {
                list.AddRange(GetNodesAtDistance(i));
            }
            return list;
        }

        private int getSize(Node root) { 
            if(root == null)
                return 0;

            return 1 + getSize(root.leftChild) + getSize(root.rightChild);
        }

        private int getNumberOfLeafNodes(Node root) { 
            if(root == null)
                return 0;

            if(root.leftChild == null && root.rightChild == null)
                return 1;

            return getNumberOfLeafNodes(root.leftChild) +
                getNumberOfLeafNodes(root.rightChild);
        }

        private int GetMaxInBinarySearchTree(Node root) { 
            if(root == null)
                throw new ArgumentNullException("root");

            if (root.rightChild == null)
                return root.Value;

            return GetMaxInBinarySearchTree(root.rightChild);
        }

        private bool ContainsInBinarySearchTree(int value, Node root) { 
            if(root == null)
                return false;

            if(root.Value == value)
                return true;

            if (root.Value > value)
                return ContainsInBinarySearchTree(value, root.leftChild);
            else
                return ContainsInBinarySearchTree(value, root.rightChild);
        }

        private bool AreSiblingsInBinaryTree(Node root, int value1, int value2) { 
            if(root == null)
                return false;

            var areSiblings = false;

            if (root.rightChild != null && root.leftChild != null) {
                areSiblings = (root.rightChild.Value == value1 && root.leftChild.Value == value2) ||
                    (root.leftChild.Value == value1 && root.rightChild.Value == value2);                  
            }

            return areSiblings || AreSiblingsInBinaryTree(root.leftChild, value1, value2) ||
                AreSiblingsInBinaryTree(root.rightChild, value1, value2);
        }

        private bool GetAnscestors(Node root, int value, List<int> list) { 
            if(root == null)
                return false;

            if (root.Value == value)
                return true;

            if (GetAnscestors(root.leftChild, value, list) 
                || GetAnscestors(root.rightChild, value, list)) { 
                list.Add(root.Value);
                return true;
            }

            return false;
        }
    }
}
