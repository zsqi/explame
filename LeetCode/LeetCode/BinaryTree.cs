using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /// <summary>
    /// 二叉树系列
    /// </summary>
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

        public TreeNode FindMax(TreeNode root)
        {
            if (root == null) return null;
            else if (root.right != null) return FindMax(root.right);
            else return root;
        }
        /// <summary>
        /// 第450题：删除二叉搜索树中的节点
        /// </summary>
        /// <param name="root"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public TreeNode DeleteNode(TreeNode root, int key)
        {
            TreeNode Tmp;
            if (root == null) return null;//未找到相应的删除节点
            else if (root.val > key)
            {
                root.left = DeleteNode(root.left, key);
            }
            else if (root.val < key)
                root.right = DeleteNode(root.right, key);
            else
            {
                if (root.left != null && root.right != null)
                {
                    Tmp = FindMax(root.left);
                    root.val = Tmp.val;
                    root.left = DeleteNode(root.left, root.val);
                }
                else
                {
                    if (root.left != null) root = root.left;
                    else root = root.right;
                }
            }
            return root;
        }


        /// <summary>
        /// One step right and then always left
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int Successor(TreeNode root)
        {
            root = root.right;
            while (root.left != null) root = root.left;
            return root.val;
        }

        /// <summary>
        /// One step left and then always right
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int Predecessor(TreeNode root)
        {
            root = root.left;
            while (root.right != null) root = root.right;
            return root.val;
        }
        /// <summary>
        /// 第450题：删除二叉搜索树中的节点
        /// </summary>
        /// <param name="root"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public TreeNode DeleteNode2(TreeNode root, int key)
        {
            if (root == null) return null;

            // delete from the right subtree
            if (key > root.val) root.right = DeleteNode2(root.right, key);
            // delete from the left subtree
            else if (key < root.val) root.left = DeleteNode2(root.left, key);
            // delete the current node
            else
            {
                // the node is a leaf
                if (root.left == null && root.right == null) root = null;
                // the node is not a leaf and has a right child
                else if (root.right != null)
                {
                    root.val = Successor(root);
                    root.right = DeleteNode2(root.right, root.val);
                }
                // the node is not a leaf, has no right child, and has a left child    
                else
                {
                    root.val = Predecessor(root);
                    root.left = DeleteNode2(root.left, root.val);
                }
            }
            return root;
        }

        /// <summary>
        /// 第110题：平衡二叉树
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public bool IsBalanced(TreeNode root)
        {
            if (root == null)
            {
                return true;
            }
            else
            {
                return Math.Abs(Height(root.left) - Height(root.right)) <= 1 && IsBalanced(root.left) && IsBalanced(root.right);
            }
        }

        public int Height(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }
            else
            {
                return Math.Max(Height(root.left), Height(root.right)) + 1;
            }
        }

        public bool IsBalanced2(TreeNode root)
        {
            return Height2(root) >= 0;
        }

        public int Height2(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }
            int leftHeight = Height2(root.left);
            int rightHeight = Height2(root.right);
            if (leftHeight == -1 || rightHeight == -1 || Math.Abs(leftHeight - rightHeight) > 1)
            {
                return -1;
            }
            else
            {
                return Math.Max(leftHeight, rightHeight) + 1;
            }
        }

        /// <summary>
        /// 第222题：完全二叉树的节点个数
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int CountNodes(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }
            int left = CountLevel(root.left);
            int right = CountLevel(root.right);
            if (left == right)
            {
                return CountNodes(root.right) + (1 << left);
            }
            else
            {
                return CountNodes(root.left) + (1 << right);
            }
        }

        private int CountLevel(TreeNode root)
        {
            int level = 0;
            while (root != null)
            {
                level++;
                root = root.left;
            }
            return level;
        }

        /// <summary>
        /// 第814题：二叉树的剪枝
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public TreeNode PruneTree1(TreeNode root)
        {
            return ContainsOne(root) ? root : null;
        }

        public bool ContainsOne(TreeNode node)
        {
            if (node == null) return false;
            bool a1 = ContainsOne(node.left);
            bool a2 = ContainsOne(node.right);
            if (!a1) node.left = null;
            if (!a2) node.right = null;
            return node.val == 1 || a1 || a2;
        }
        /// <summary>
        /// 深度优先搜索，如果不符合返回null，符合的话返回自己
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public TreeNode PruneTree(TreeNode root)
        {
            if (root == null)
                return null;
            root.left = PruneTree(root.left);
            root.right = PruneTree(root.right);
            if (root.left == null && root.right == null)
                if (root.val == 0)
                    return null;
            return root;
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
