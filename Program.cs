using System;

namespace Binary_Search_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Binary Search Tree\n");
            int data;
            bool exit = false;
            BinaryTree binaryTree = new BinaryTree();

            while (true)
            {
                Console.WriteLine("0. Exit");
                Console.WriteLine("1. Insert a node");
                Console.WriteLine("2. In Order Traversal (left => Root => Right)");
                Console.WriteLine("3. PreOrder Traversal (Root -> Left -> Right)");
                Console.WriteLine("4. Post Order Traversal (left -> Right -> Root)");
                Console.WriteLine("5. Find the node by value");
                Console.WriteLine("6. Find the node recursively");
                Console.WriteLine("7. Delete a leaf node");
                Console.WriteLine("8. SoftDelete a Node with one given child");
                Console.WriteLine("9. Display the smallest node");
                Console.WriteLine("10. Display the largest node");
                Console.WriteLine("11. Display number of leaf nodes");
                Console.WriteLine("12. Check if the binary tree is balanced");

                Console.Write("Enter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 0:
                        exit = true;
                        break;
                    case 1:
                        Console.Write("Enter element to be inserted in the Binary Tree: ");
                        data = Convert.ToInt32(Console.ReadLine());
                        binaryTree.Insert(data);
                        break;

                    case 2:
                        binaryTree.InOrderTraversal();
                        break;

                    case 3:
                        binaryTree.PreorderTraversal();
                        break;

                    case 4:
                        binaryTree.PostOrderTraversal();
                        break;

                    case 5:
                        Console.Write("Enter the element to be found: ");
                        data = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine(binaryTree.Find(data) != null ? $"{data} has been found successfully" : $"{data} has not been found!");
                        break;

                    case 6:
                        Console.Write("Enter the element to be found recursively: ");
                        data = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine(binaryTree.FindRecursive(data) != null ? $"element {data} has been found recursively" : $"element {data} has not been found!");
                        break;

                    case 7:
                        Console.Write("Enter the element to be deleted: ");
                        data = Convert.ToInt32(Console.ReadLine());
                        binaryTree.Remove(data);
                        break;

                    case 8:
                        Console.Write("Enter a child to be softly deleted");
                        data = Convert.ToInt32(Console.ReadLine());
                        binaryTree.SoftDelete(data);
                        break;

                    case 9:
                        Console.WriteLine($"Smallest node = {binaryTree.Smallest()}");
                        break;

                    case 10:
                        Console.WriteLine($"Largest node = {binaryTree.Largest()}");
                        break;

                    case 11:
                        Console.WriteLine($"Number of leaf nodes = {binaryTree.NumberOfLeafNodes()}");
                        break;

                    case 12:
                        Console.WriteLine($"Tree height = {binaryTree.Height()}");
                        break;

                    case 13:
                        var bal = binaryTree.IsBalanced() ? "balanced" : "unbalanced";
                        Console.WriteLine($"The binary search tree is: {bal}!");
                        break;

                    default:
                        Console.WriteLine("Wrong choice");
                        break;
                }

                if (exit)
                {
                    break;
                }
            }
        }
    }
}
