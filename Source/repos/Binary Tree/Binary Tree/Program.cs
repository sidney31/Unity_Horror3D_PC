internal class Program
{
    private static void Main(string[] args)
    {
        TreeNode fifth = new TreeNode(5);
        TreeNode fourth = new TreeNode(4);
        TreeNode third = new TreeNode(3);
        TreeNode second = new TreeNode(1, fourth, fifth);
        TreeNode first = new TreeNode(2, second, third);

        InvertTree(first);
    }

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

    public static TreeNode InvertTree(TreeNode root)
    {
        Console.WriteLine(root.left.GetType);
        (root.left, root.right) = (root.right, root.left);
        return root;
    }

}