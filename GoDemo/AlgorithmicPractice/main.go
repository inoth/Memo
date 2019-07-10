package main

func main() {
	print(0)
}

type TreeNode struct {
	Val   int
	Left  *TreeNode
	Right *TreeNode
}

func inorderTraversal(root *TreeNode) []int {
	list := make([]int, 0)
	inoth(root, &list)
	return list
}
func inoth(root *TreeNode, res *[]int) {
	if root != nil {
		if root.Left != nil {
			inoth(root.Left, res)
		}
		*res = append(*res, root.Val)
		if root.Right != nil {
			inoth(root.Right, res)
		}
	}
}

// 合并两个树
func mergeTrees(t1 *TreeNode, t2 *TreeNode) *TreeNode {
	if t1 == nil && t2 == nil {
		return nil
	}
	if t1 == nil {
		return t2
	}
	if t2 == nil {
		return t1
	}
	t1.Val += t2.Val
	t1.Left = mergeTrees(t1.Left, t2.Left)
	t1.Right = mergeTrees(t1.Right, t2.Right)
	return t1
}

// 反转左右树
func invertTree(root *TreeNode) *TreeNode {
	if root == nil {
		return nil
	}
	right, left := invertTree(root.Right), invertTree(root.Left)
	root.Left = right
	root.Right = left
	return root
}

// 二叉树最大层数
func maxDepth(root *TreeNode) int {
	if root == nil {
		return 0
	} else {
		lh, rh := maxDepth(root.Left), maxDepth(root.Right)
		return InothMax(lh, rh) + 1 // 加一很重要
	}
}
func InothMax(a int, b int) int {
	if a > b {
		return a
	}
	return b
}

// 后序遍历
