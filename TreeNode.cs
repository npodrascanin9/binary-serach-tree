using System;

namespace Binary_Search_Tree
{
    internal sealed class TreeNode
    {
        int data;
        public int _data
        {
            get
            {
                return data;
            }
        }

        TreeNode rightNode;

        public TreeNode _rightNode
        {
            get
            {
                return rightNode;
            }
            set
            {
                rightNode = value;
            }
        }

        TreeNode leftNode;
        public TreeNode _leftNode
        {
            get
            {
                return leftNode;
            }
            set
            {
                leftNode = value;
            }
        }

        bool isDeleted;

        public bool _isDeleted
        {
            get
            {
                return isDeleted;
            }
        }

        public TreeNode(int value)
        {
            data = value;
        }

        public void Delete()
        {
            isDeleted = true;
        }

        public TreeNode Find(int value)
        {
            TreeNode currentNode = this;

            while (currentNode != null)
            {
                if (value == currentNode.data && !isDeleted)
                {
                    return currentNode;
                }

                currentNode = value > currentNode.data ? currentNode.rightNode : currentNode.leftNode ;
            }

            return null;
        }

        public TreeNode FindRecursive(int value)
        {
            if (value == data && !isDeleted)
            {
                return this;
            }

            if (value <= data && leftNode != null)
            {
                return leftNode.FindRecursive(value);
            }

            if (value >= data && rightNode != null)
            {
                return rightNode.FindRecursive(value);
            }

            return null;
        }

        public void Insert(int value)
        {
            if (value >= data)
            {
                if (rightNode is null)
                    rightNode = new TreeNode(value);
                rightNode.Insert(value);
            }
            else
            {
                if (leftNode is null)
                    leftNode = new TreeNode(value);
                leftNode.Insert(value);
            }
        }

        public void InOrderTraversal()
        {
            if (leftNode != null)
                leftNode.InOrderTraversal();
            Console.Write(data + " ");

            if (rightNode != null)
            {
                rightNode.InOrderTraversal();
            }
        }

        public void PreOrderTraversal()
        {
            Console.Write(data + " ");

            if (leftNode != null)
            {
                leftNode.PreOrderTraversal();
            }

            if (rightNode != null)
            {
                rightNode.PreOrderTraversal();
            }
        }

        public void PostOrderTraversal()
        {
            if (leftNode != null)
            {
                leftNode.PostOrderTraversal();
            }

            if (rightNode != null)
            {
                rightNode.PostOrderTraversal();
            }

            Console.Write(data + " ");
        }

        public Nullable<int> SmallestValue() =>
            leftNode is null ? data : leftNode.SmallestValue();

        public Nullable<int> LargestValue() =>
            rightNode is null ? data : rightNode.LargestValue();

        public int NumberOfLFNodes()
        {
            if (leftNode is null && rightNode is null)
            {
                return 1;
            }

            var leftLeaves = 0;
            var rightLeaves = 0;

            if (leftNode != null)
            {
                leftLeaves = leftNode.NumberOfLFNodes();
            }

            if (rightNode != null)
            {
                rightLeaves = rightNode.NumberOfLFNodes();
            }

            return leftLeaves + rightLeaves;
        }

        public int HeightRoot()
        {
            if (leftNode is null && rightNode is null)
            {
                return 1;
            }

            var left = 0;
            var right = 0;

            if (leftNode != null)
            {
                left = leftNode.HeightRoot();
            }

            if (rightNode != null)
            {
                right = rightNode.HeightRoot();
            }

            return left > right ? left + 1 : right + 1;
        }

        public bool isBalancedRoot()
        {
            var leftHeight = leftNode != null ? leftNode.HeightRoot() : 0;
            var rightHeight = rightNode != null ? rightNode.HeightRoot() : 0;

            var heightDifference = leftHeight - rightHeight;

            return Math.Abs(heightDifference) > 1 ? false : ((leftNode != null ? leftNode.isBalancedRoot() : true) && (rightNode != null ? rightNode.isBalancedRoot() : true));
        }
    }
}
