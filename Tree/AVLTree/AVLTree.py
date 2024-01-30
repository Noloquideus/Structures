class AVLNode:
    def __init__(self, key):
        self.key = key
        self.left = None
        self.right = None
        self.height = 1


class AVLTree:
    def _height(self, node):
        if not node:
            return 0
        return node.height

    def _update_height(self, node):
        if not node:
            return 0
        node.height = 1 + max(self._height(node.left), self._height(node.right))

    def _balance_factor(self, node):
        if not node:
            return 0
        return self._height(node.left) - self._height(node.right)

    def _right_rotate(self, y):
        x = y.left
        T2 = x.right

        x.right = y
        y.left = T2

        self._update_height(y)
        self._update_height(x)

        return x

    def _left_rotate(self, x):
        y = x.right
        T2 = y.left

        y.left = x
        x.right = T2

        self._update_height(x)
        self._update_height(y)

        return y

    def _balance(self, node, key):
        self._update_height(node)
        balance = self._balance_factor(node)

        # Left Heavy
        if balance > 1 and key < node.left.key:
            return self._right_rotate(node)

        # Right Heavy
        if balance < -1 and key > node.right.key:
            return self._left_rotate(node)

        # Left-Right Heavy
        if balance > 1 and key > node.left.key:
            node.left = self._left_rotate(node.left)
            return self._right_rotate(node)

        # Right-Left Heavy
        if balance < -1 and key < node.right.key:
            node.right = self._right_rotate(node.right)
            return self._left_rotate(node)

        return node

    def _insert(self, node, key):
        if not node:
            return AVLNode(key)

        if key < node.key:
            node.left = self._insert(node.left, key)
        elif key > node.key:
            node.right = self._insert(node.right, key)
        else:
            return node  # Duplicate keys are not allowed

        return self._balance(node, key)

    def insert(self, key):
        self.root = self._insert(self.root, key)

    def inorder_traversal(self):
        result = []
        self._inorder_traversal(self.root, result)
        return result

    def _inorder_traversal(self, node, result):
        if node:
            self._inorder_traversal(node.left, result)
            result.append(node.key)
            self._inorder_traversal(node.right, result)


# Пример использования
avl_tree = AVLTree()
avl_tree.insert(10)
avl_tree.insert(5)
avl_tree.insert(15)
avl_tree.insert(3)
avl_tree.insert(7)

print("Inorder traversal:", avl_tree.inorder_traversal())
