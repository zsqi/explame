using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class BinaryTree
    {
        /// <summary>
        /// 第104题：二叉树的最大深度
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int MaxDepth(TreeNode root)
        {
            if(root == null)
            {
                return 0;
            }
            else
            {
                int leftHeight = MaxDepth(root.left);
                int rightHeight = MaxDepth(root.right);
                return Math.Max(leftHeight, rightHeight) + 1;
            }
        }

        public int MaxDepth2(TreeNode root)
        {
            int result = 0;

            //队列用来放每一层不为null的节点
            Queue<TreeNode> queue = new Queue<TreeNode>();
            //用来临时存放每次更新queue前的上一层所有节点
            Queue<TreeNode> tempQueue = new Queue<TreeNode>();
            if (root != null)
            {
                queue.Enqueue(root);
            }
            while (queue.Count > 0)
            {
                while (queue.Count > 0)
                {
                    tempQueue.Enqueue(queue.Dequeue());
                }
                result++;
                while (tempQueue.Count > 0)
                {
                    //tempQueue不为空则将下一层的节点放入队列
                    var element = tempQueue.Dequeue();
                    if (element.left != null)
                    {
                        queue.Enqueue(element.left);
                    }
                    if (element.right != null)
                    {
                        queue.Enqueue(element.right);
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// 第102题：二叉树的层次遍历
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            var result = new List<IList<int>>();
            if (root == null) return result;

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count != 0)
            {
                var list = new List<int>();
                int count = queue.Count;

                for (int i = 0; i < count; ++i)
                {
                    var node = queue.Dequeue();
                    list.Add(node.val);

                    if (node.left != null) queue.Enqueue(node.left);
                    if (node.right != null) queue.Enqueue(node.right);
                }

                result.Add(list);
            }

            return result;
        }
        /// <summary>
        /// 第98题：验证二叉搜索树
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public bool IsValidBST(TreeNode root)
        {
            return IsValidBST(root, long.MinValue, long.MaxValue);
        }
        public bool IsValidBST(TreeNode node, long lower, long upper)
        {
            if (node == null)
            {
                return true;
            }
            if (node.val <= lower || node.val >= upper)
            {
                return false;
            }
            return IsValidBST(node.left, lower, node.val) && IsValidBST(node.right, node.val, upper);
        }

        /// <summary>
        /// 第700题：二叉搜索树中的搜索
        /// </summary>
        /// <param name="root"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public TreeNode SearchBST(TreeNode root, int val)
        {
            if (root == null)
                return null;
            if (root.val > val)
            {
                return SearchBST(root.left, val);
            }
            else if (root.val < val)
            {
                return SearchBST(root.right, val);
            }
            else
            {
                return root;
            }
        }
    }


    //Definition for a binary tree node.
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

}
