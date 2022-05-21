using Newtonsoft.Json;
using System;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode treeNode = new TreeNode()
            {
                val = 3,
                left = new TreeNode()
                {
                    val = 4,
                    left = new TreeNode() { val = 41 }
                },
                right = new TreeNode()
                {
                    val = 20,
                    left = new TreeNode() { val = 15, left = new TreeNode() { val = 151 } },
                    right = new TreeNode() { val = 7 }
                }
            };
            BinaryTree binTree = new BinaryTree();
            var d=binTree.LevelOrder(treeNode);
            Console.WriteLine(JsonConvert.SerializeObject(d));

        }
    }
}
