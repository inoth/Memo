using System;
using System.Collections.Generic;

namespace AlgorithmicPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static IList<int> InorderTraversal(TreeNode root)
        {
            var nums = new List<int>();
            Inoth(root, nums);
            return nums;
        }
        static void Inoth(TreeNode root, IList<int> res)
        {
            if (root != null)
            {
                if (root.left != null)
                {
                    Inoth(root.left, res);
                }
                res.Add(root.val);
                if (root.right != null)
                {
                    Inoth(root.right, res);
                }
            }
        }

        static TreeNode MergeTrees(TreeNode t1, TreeNode t2)
        {
            if (t1 == null && t2 == null)
            {
                return null;
            }
            if (t1 == null)
            {
                return t2;
            }
            if (t2 == null)
            {
                return t1;
            }
            var tree = new TreeNode(t1.val + t2.val);
            tree.left = MergeTrees(t1.left, t2.left);
            tree.right = MergeTrees(t1.right, t2.right);
            return tree;
        }

        static IList<int> Postorder(Node root)
        {
            if (root == null)
            {
                return null;
            }
            foreach (var item in root.children)
            {
                Postorder(item);
            }
            
        }
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    public class Node
    {
        public int val;
        public IList<Node> children;

        public Node() { }
        public Node(int _val, IList<Node> _children)
        {
            val = _val;
            children = _children;
        }
    }
}
