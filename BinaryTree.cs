using System;

namespace Binary_Search_Tree
{
    internal sealed class BinaryTree
    {
        TreeNode root;

        public TreeNode Find(int data) =>
            root != null ? root.Find(data) : null;

        public TreeNode FindRecursive(int data) =>
            root != null ? root.FindRecursive(data) : null;

        public void Insert(int data)
        {
            if (root != null)
                root.Insert(data);
            root = new TreeNode(data);
        }

        public void InOrderTraversal()
        {
            if (root != null)
            {
                root.InOrderTraversal();
            }
        }

        public void PreorderTraversal()
        {
            if (root != null)
            {
                root.PreOrderTraversal();
            }
        }

        public void PostOrderTraversal()
        {
            if (root != null)
            {
                root.PostOrderTraversal();
            }
        }

        public void Remove(int data)
        {
            TreeNode current = root;
            TreeNode parent = root;
            var isLeftChild = false;

            if (current is null)
            {
                return;
            }

            while (current != null && current._data != data)
            {
                parent = current;
                isLeftChild = data < current._data;

                current = isLeftChild ? current._leftNode : current._rightNode;
            }

            if (current is null)
            {
                return;
            }

            if (current._rightNode is null && current._leftNode is null)
            {
                if (current == root)
                {
                    root = null;
                }
                else
                {
                    if (isLeftChild)
                    {
                        parent._leftNode = null;
                    }
                    else
                    {
                        parent._rightNode = null;
                    }
                }
            }

            else if (current._rightNode == null)
            {
                if (current == root)
                {
                    root = current._leftNode;
                }
                else
                {
                    if (isLeftChild)
                    {
                        parent._leftNode = current._leftNode;
                    }
                    else
                    {
                        parent._rightNode = current._leftNode;
                    }
                }
            }
            else if (current._leftNode is null)
            {
                if (current == root)
                {
                    root = current._rightNode;
                }
                else
                {
                    if (isLeftChild)
                    {
                        parent._leftNode = current._rightNode;
                    }
                    else
                    {
                        parent._rightNode = current._rightNode;
                    }
                }
            }
            else
            {
                TreeNode successor = GetSuccessor(current);

                if (current == root)
                {
                    root = successor;
                }
                else if (isLeftChild)
                {
                    parent._leftNode = successor;
                }
                else
                {
                    parent._rightNode = successor;
                }
            }
        }

        public TreeNode GetSuccessor(TreeNode node)
        {
            TreeNode parentOfSuccessor = node;
            TreeNode successor = node;
            TreeNode current = node._rightNode;

            while (current != null)
            {
                parentOfSuccessor = successor;
                successor = current;
                current = current._leftNode;
            }

            if (successor != node._rightNode)
            {
                parentOfSuccessor._leftNode = successor._rightNode;
                successor._rightNode = node._rightNode;
            }

            successor._leftNode = node._leftNode;
            return successor;
        }

        public void SoftDelete(int data)
        {
            TreeNode toDelete = Find(data);

            if (toDelete != null)
            {
                toDelete.Delete();
            }
        }

        public Nullable<int> Smallest() =>
            root != null ? root.SmallestValue() : null;

        public Nullable<int> Largest() =>
            root != null ? root.LargestValue() : null;

        public int NumberOfLeafNodes() =>
            root != null ? root.NumberOfLFNodes() : 0;

        public int Height() =>
            root != null ? root.HeightRoot() : 0;

        public bool IsBalanced() =>
            root != null ? root.isBalancedRoot() : true;
    }
}
