package main

func main() {
	// r := gin.Default()
	// r.GET("/api/:id", func(c *gin.Context) {
	// 	id := c.Param("id")
	// 	c.JSON(200, gin.H{"id": id})
	// })
	// r.Run(":8888")
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
